﻿namespace Test_One_To_Many.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }  // компания пользователя
    }
}
