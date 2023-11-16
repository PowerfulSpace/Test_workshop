namespace Test_Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        // навигационное свойство
        public Company Manufacturer { get; set; }
    }
}
