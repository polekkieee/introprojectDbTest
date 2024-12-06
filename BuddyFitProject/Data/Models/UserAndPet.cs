namespace BuddyFitProject.Data.Models
{
    public class UserAndPet
    {
        public Users User { get; set; } = new Users();
        public Pets Pet { get; set; } = new Pets();
        public enum TypesOfPets {Bear, Bunny, Cat }
    }
}
