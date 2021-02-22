using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teste.Models
{
    public class Peca
    {
        public Peca() { 
        }
        public int Id{ get; set; }
        public string NomePeca { get; set; }
        public int QTD { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}