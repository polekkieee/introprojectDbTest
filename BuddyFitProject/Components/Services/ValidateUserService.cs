using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BuddyFitProject.Data;
using BuddyFitProject.Data.Models;
using BuddyFitProject.Components.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ValidateUserService
{
    private readonly BuddyFitDbContext _context;
    UserService UserService;
    public ValidateUserService(UserService UserService)
    {
        this.UserService = UserService;
    }

    public async Task<string> ChangePasswordAsync(string username, string resetCode, string newPassword, string email)
    {
        try
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                return "Password cannot be empty.";
            }

            Users user = UserService.GetUserByUsernameAndEmail(username, email);

            if (user == null)
            {
                return $"User '{username}' not found.";
            }

            if (user.Resetcode != resetCode)
            {
                return "Invalid reset code.";
            }

            user.Password = newPassword;
            UserService.UpdateUser(user);
            return "Password reset successfully.";
        }
        catch (DbUpdateException dbEx)
        {
            return $"Error updating password: {dbEx.InnerException?.Message ?? dbEx.Message}";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }

    public string SetResetCode(string username, string email)
    {
        string resetcode = GenerateRandomCode();
        Users user = UserService.GetUserByUsernameAndEmail(username, email);
        user.Resetcode = resetcode;
        UserService.UpdateUser(user);
        return resetcode;
    }

    private string GenerateRandomCode()
    {
        const string chars = "0123456789";
        Random random = new();
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    /// <summary>
    /// Hashes a password using SHA-256.
    /// </summary>
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}