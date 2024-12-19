namespace BuddyFitProject.Data.Models
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
        public int Stamina_bar { get; set; }
        public string Clothing { get; set; }

        public DateTime Food_bar_tlc { get; set; }
        public DateTime Health_bar_tlc { get; set; }
        public int Evolution { get; set; }
      
    }
}
