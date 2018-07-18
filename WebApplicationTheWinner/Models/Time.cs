using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTheWinner.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public int Fase { get; set; }
        public string Nome { get; set; }
    }
}