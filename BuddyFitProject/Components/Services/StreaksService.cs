////using BuddyFitProject.Components.Pages;
////using BuddyFitProject.Data.Models;
////using Microsoft.VisualBasic;
////using System.Runtime.InteropServices;

//namespace BuddyFitProject.Components.Services
//{
//    public class StreakService
//    {
//        public class PlayerStreak
//        {
//            public int CurrentStreak { get; set; }
//            public DateTime LastStreakDate { get; set; }
//            public int LastReward { get; set; }
//        }


//        public int CalculateStreakReward(int Streakday)
//        {
//            return Math.Min(100 + (Streakday - 1) * 100, 500);
//        }

//        public void UpdateStreak(PlayerStreak playerStreak)
//        {
//            DateTime today = DateTime.UtcNow.Date;

//            if (playerStreak.LastStreakDate == today.AddDays(-1))
//            {
//                playerStreak.CurrentStreak++;
//            }

//            else if (playerStreak.LastStreakDate < today.AddDays(-1))
//            {
//                playerStreak.CurrentStreak = 1;
//            }

//            int reward = CalculateStreakReward(playerStreak.CurrentStreak);
//            playerStreak.LastReward = reward;

//            GrantCoinsToPlayer(playerStreak, reward);
//        }

//        public void GrantCoinsToPlayer(PlayerStreak playerStreak, int reward)
//        {
//            playerStreak.Player.Coins += reward;

//            Console.WriteLine($"Streak Day: {playerStreak.CurrentStreak}");
//            Console.WriteLine($"Reward: {reward} coins granted.");
//        }

//        public void OnPlayerLogin(PlayerStreak playerStreak)
//        {
//            UpdateStreak(playerStreak);
//        }
//    }
        
//}
