using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BuddyFitProject.Data;
using BuddyFitProject.Data.Models;
using System.Text;

public class ResetPasswordService
{
    private readonly BuddyFitDbContext _context;

    public ResetPasswordService(BuddyFitDbContext context)
    {
        _context = context;
    }

    public async Task<string> ChangePasswordAsync(string username, int resetCode, string newPassword)
    {
        try
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                return "Password cannot be empty.";
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return $"User '{username}' not found.";
            }

            if (user.Resetcode != resetCode)
            {
                return "Invalid reset code.";
            }

            // Hash the new password
            user.Password = HashPassword(newPassword);

            // Save changes
            await _context.SaveChangesAsync();
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