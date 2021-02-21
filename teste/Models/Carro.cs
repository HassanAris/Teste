using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [Table("Carro")]
    public class Carro
    {
        public int Id { get; set; }
        public string MarcaCarro { get; set; }

    }
}