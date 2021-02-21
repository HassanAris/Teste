using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teste.Models
{

    public class ModeloVM
    {
        public List<Peca> PecaCarro { get; set; }
        public List<Modelo> ModeloCarro { get; set; }
        public Carro[] Carro { get; set; }
    }

    public class ListarVM<T>
    {
        public T[] Itens { get; set; }
        public int Total { get; set; }
        public int TotalFiltrado { get; set; }
    }

    public class AjaxResponse<T>
    {
        public bool Ok { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}