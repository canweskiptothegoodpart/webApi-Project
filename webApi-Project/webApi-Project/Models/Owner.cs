namespace webApi_Project.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Gym { get; set; }

        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }

    }

}
