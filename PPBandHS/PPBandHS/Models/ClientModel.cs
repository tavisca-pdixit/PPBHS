using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPBandHS.Models
{
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Contact  { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }

    public class ClientsContext : DbContext
    {
        public DbSet<ClientModel> Clients { get; set; }
    }

}