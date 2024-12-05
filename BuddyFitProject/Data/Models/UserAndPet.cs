namespace BuddyFitProject.Data.Models
{
    public class UserAndPet
    {
        public Users User { get; set; } = new Users();
        public Pets Pet { get; set; } = new Pets();
        public bool cat { get; set; } = false;
        public bool bear { get; set; } = false;
        public bool bunny { get; set; } = false;
    }
}
