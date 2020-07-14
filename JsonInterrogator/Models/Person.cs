using System;

namespace JsonInterrogator.Models
{
    public class Person
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public Name Name { get; set; }
        public string EyeColor { get; set; }
        public string FavoriteFruit { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
}