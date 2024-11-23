using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Models;

public class WorkoutSessions
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ExerciseId { get; set; }
    public int Minutes { get; set; }
    public int Reward { get; set; }
    public DateTime Timestamp { get; set; }

}
