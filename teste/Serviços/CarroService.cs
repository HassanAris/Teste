using IncentivoCurtoPrazo.Util.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teste.DAL;
using teste.Models;

namespace teste.Serviços
{
    public class CarroService : IDisposable
    {
        private GenericRepository<Carro, TesteConnectionString> Repository { get; set; }

        public CarroService()
        {
            Repository = new GenericRepository<Carro, TesteConnectionString>();
        }

        public CarroService(TesteConnectionString context)
        {
            Repository = new GenericRepository<Carro, TesteConnectionString>(context);
        }

        public Carro[] Lista()
        {
            return Repository.Get();
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