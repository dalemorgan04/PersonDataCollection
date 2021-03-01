using System.ComponentModel.DataAnnotations.Schema;

namespace PersonDataCollection.Models
{
    public class Address
    {
        //public int ClientId { get; set; }
        public Client Client{ get; set; }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
    }
}