using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Models;

public class Users
{
    [Key]
    public int UserId {get;set;}
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    //public int Coins { get; set; } = 0;
    /*
    public Users()
    {
        Age = 0;
        Start_condition = 0;
        Coins = 0;
    }
    */
}
