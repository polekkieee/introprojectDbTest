using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Models;

public class User
{
    [Key]
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    //public int Coins { get; set; } = 0;

}
