using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace teste.Models
{
    [Table("Mensageria")]
    public class Mensageria
    {
        public int Id { get; set; }
        public string Assunto  { get; set; }
        public string Mensagem  { get; set; }
        public int IdPeca { get; set; }
    }
}