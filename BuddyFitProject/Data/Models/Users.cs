using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Data.Models;

public class Users
{
    public int Id {get;set;}
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Gender { get; set; } = "new";
    public string Start_condition { get; set; } = "new";
    public int Coins { get; set; } = 0;
    public string Resetcode { get; set; } = "Empty";
    public string Validatecode { get; set; } = "Empty";

    
}
