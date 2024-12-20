namespace BuddyFitProject.Data.Models
{
    public class Achievements
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition_Type { get; set; }
        public int Condition_Value { get; set; }
        public string Reward_Type { get; set; }
        public string Reward_Value { get; set; }
    }
}
