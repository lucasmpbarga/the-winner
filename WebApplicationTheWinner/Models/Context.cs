using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationTheWinner.Models
{
    public class Context : DbContext
    {
        public DbSet<Time> Times { get; set; }
    }
}