namespace BuddyFitProject.Models
{
    public class Pets
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int Food_bar { get; set; }
        public int Health_bar { get; set; }
    }
}
