using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Data.Models;

public class Users
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Age { get; set; } = 0;
    public string Gender { get; set; }
    public string Start_condition { get; set; }
    public int Coins { get; set; } = 0;
    public int ResetCode { get; set; }

}
