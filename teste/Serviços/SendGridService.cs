using IncentivoCurtoPrazo.Util.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using teste.DAL;
using teste.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace teste.Serviços
{
    public class SendGridService : IDisposable
    {
        private GenericRepository<Mensageria, TesteConnectionString> Repository { get; set; }

        public SendGridService()
        {
            Repository = new GenericRepository<Mensageria, TesteConnectionString>();
        }

        public SendGridService(TesteConnectionString context)
        {
            Repository = new GenericRepository<Mensageria, TesteConnectionString>(context);
        }

        private static string apiKey = "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";

        public async Task<bool> DispararEmail(Mensageria menssagem, string email)
        {
            bool sucessoEmail = true;

            sucessoEmail = Salvar(menssagem);

            sucessoEmail = await EnviarEmailAsync(menssagem, email);

            return sucessoEmail;
        }

        public static async Task<bool> EnviarEmailAsync(Mensageria menssagem, string email)
        {
            var sender = new EmailAddress("hassanarisneto@gmail.com");
            var client = new SendGridClient(apiKey);
            var destinatarios = new List<EmailAddress>();
            destinatarios.Add(new EmailAddress(email));
            //para esta montando a mensagem remetente, destino, assunto, mensagem, string vazia, false
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(sender, destinatarios, menssagem.Assunto, "", menssagem.Mensagem, false);
            try
            {
                if (!String.IsNullOrEmpty(menssagem.Mensagem) && !String.IsNullOrEmpty(menssagem.Assunto))
                {
                    var response = await client.SendEmailAsync(msg);
                    return (int)response.StatusCode <= 203 ? true : false;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public TesteConnectionString GetContext()
        {
            return this.Repository.GetContext();
        }

        public bool Salvar(Mensageria mensagem)
        {
            bool sucesso = false;

            var menssageria = new Mensageria();
            menssageria.Assunto = mensagem.Assunto;
            menssageria.Mensagem = mensagem.Mensagem;
            menssageria.IdPeca = mensagem.IdPeca;

            sucesso = Repository.Insert(menssageria);
            return sucesso;
        }

        public void Dispose()
        {
            this.Repository.Dispose();
        }
    }
}