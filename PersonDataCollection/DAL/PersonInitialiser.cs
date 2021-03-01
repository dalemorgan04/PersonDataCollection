using PersonDataCollection.Models;
using System;

namespace PersonDataCollection.DAL
{
    public class PersonInitialiser : System.Data.Entity.DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            context.Database.Delete();
            context.Database.Create();

            context.Clients.Add(
                new Client()
                {
                    Forename = "Dale",
                    Surname = "Morgan",
                    DateOfBirth = DateTime.Now,
                    Address = new Address()
                    {
                        Postcode = "AB1234",
                        Street = "4"
                    }
                }
                );
            context.Staff.Add(
                new Staff()
                {
                    Forename = "Joe",
                    Surname = "Bloggs",
                    DateOfBirth = DateTime.Now
                }
                );
            context.SaveChanges();
        }
    }
}