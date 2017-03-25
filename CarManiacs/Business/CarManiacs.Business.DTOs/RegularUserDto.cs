namespace CarManiacs.Business.DTOs
{
    public class RegularUserDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }
        
        public string CurrentCar { get; set; }
        
        public string FavoriteCar { get; set; }
    }
}
