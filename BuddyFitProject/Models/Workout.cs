﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuddyFitProject.Models;

public class Workout
{
  
    public string Pushups { get; set; }
    public string Situps { get; set; }
    public string Plank { get; set; } 
    public string JumpingJacks { get; set; }
    public string Running { get; set; } 
    public string Squats { get;set; }

    public DateTime LoggedAt { get; set; } = DateTime.Now;

}
