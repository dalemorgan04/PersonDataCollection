using System;

namespace PersonDataCollection.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}