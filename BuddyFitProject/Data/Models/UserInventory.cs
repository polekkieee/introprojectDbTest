﻿namespace BuddyFitProject.Data.Models
{
    public class UserInventory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
