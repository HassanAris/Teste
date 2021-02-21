using IncentivoCurtoPrazo.Util.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using teste.DAL;
using teste.Models;

namespace teste.Serviços
{
    public class PecaService : IDisposable
    {
        private GenericRepository<Peca, TesteConnectionString> Repository { get; set; }

        public PecaService()
        {
            Repository = new GenericRepository<Peca, TesteConnectionString>();
        }

        public PecaService(TesteConnectionString context)
        {
            Repository = new GenericRepository<Peca, TesteConnectionString>(context);
        }

        public List<Peca> Lista(int idModelo)
        {
            return Repository.Get(x => x.Modelo.Id == idModelo).ToList();
        }

        public string NomePeca(int idPeca)
        {
            var teste = Repository.Get(x => x.Id == idPeca).Select(y => y.NomePeca).FirstOrDefault();
            return Repository.Get(x => x.Id == idPeca).Select(y => y.NomePeca).FirstOrDefault(); 
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