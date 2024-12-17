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
        this.UserService = UserService; //Dependency injection of the userservice
    }

    public async Task<string> ChangePasswordAsync(string username, string resetCode, string newPassword, string email) //Logic to change the password
    {
        try
        {
            if (string.IsNullOrEmpty(newPassword)) //When the new password is empty
            {
                return "Password cannot be empty.";
            }

            Users user = UserService.GetUserByUsernameAndEmail(username, email);

            if (user == null) //When the new user isn't found
            {
                return $"User '{username}' not found.";
            }

            if (user.Resetcode != resetCode) //When the resetcode is invalid
            {
                return "Invalid reset code.";
            }

            user.Password = newPassword; //Updates the user's password
            UserService.UpdateUser(user); //Saves the new password into the database
            return "Password reset successfully."; 
        }
        catch (DbUpdateException dbEx) //Handles database update errors
        {
            return $"Error updating password: {dbEx.InnerException?.Message ?? dbEx.Message}";
        }
        catch (Exception ex) //Handles other errors
        {
            return $"Unexpected error: {ex.Message}"; 
        }
    }

    public string SetResetCode(string username, string email) //Logic to save the resetcode into the database
    {
        string resetcode = GenerateRandomCode();
        Users user = UserService.GetUserByUsernameAndEmail(username, email);
        user.Resetcode = resetcode;
        UserService.UpdateUser(user); //Saves the resetcode into the database
        return resetcode;
    }

    private string GenerateRandomCode() //Logic to generate a random resetcode
    {
        const string chars = "0123456789";
        Random random = new();
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}