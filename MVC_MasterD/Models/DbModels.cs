using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_MasterD.Models
{
    public class Spot
    {
        public int SpotId { get; set; }
        [Required,Display(Name ="Spot Name")]
        public string SpotName { get; set; }

        //nev
        public ICollection<BookingEntry> BookingEntries { get; set; } = new List<BookingEntry>();
    }

    public class Client
    {
        public int ClientId { get; set; }
        [Required, Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required,Display(Name ="Birth Date"),DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:yy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        public bool MaritalStatus { get; set; }

        public ICollection<BookingEntry> BookingEntries { get; set; } = new List<BookingEntry>();
    }
    public class BookingEntry
    {
        public int BookingEntryId { get; set; }
        [ForeignKey("Spot")]
        public int SpotId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }


        //nev
        public Spot Spot { get; set; }
        public Client Client { get; set; }
    }
    public class TravelDbContext:DbContext
    {
        public DbSet<Spot>   Spots { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BookingEntry> BookingEntries { get; set; }

    }
}