using IncentivoCurtoPrazo.Util.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teste.DAL;
using teste.Models;

namespace teste.Serviços
{
    public class ModeloService : IDisposable
    {
        private GenericRepository<Modelo, TesteConnectionString> Repository { get; set; }

        public ModeloService()
        {
            Repository = new GenericRepository<Modelo, TesteConnectionString>();
        }

        public ModeloService(TesteConnectionString context)
        {
            Repository = new GenericRepository<Modelo, TesteConnectionString>(context);
        }

        public List<Modelo> Lista(int idCarro)
        {
            return Repository.Get(x => x.Carro.Id == idCarro).ToList();
        }

        public TesteConnectionString GetContext()
        {
            return this.Repository.GetContext();
        }

        public void Dispose()
        {
            this.Repository.Dispose();
        }
    }
}