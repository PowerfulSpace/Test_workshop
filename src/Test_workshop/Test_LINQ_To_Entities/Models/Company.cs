﻿namespace Test_LINQ_To_Entities.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
