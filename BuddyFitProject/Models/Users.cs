using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Models;

public class Users
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Start_condition { get; set; }   
    public int Coins { get; set; } 

    public Users()
    {
        Age = 0;
        Start_condition = 0;
        Coins = 0;
    }
}
