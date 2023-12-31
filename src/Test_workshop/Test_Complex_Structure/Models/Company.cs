﻿namespace Test_Complex_Structure.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
