using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [Table("Modelo")]
    public class Modelo
    {

        public Modelo()
        {

        }
        public int Id{ get; set; }
        public string ModeloCarro{ get; set; }
        public virtual Carro Carro { get; set; }
    }
}