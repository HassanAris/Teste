using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using teste.Models;
using teste.Serviços;

namespace teste.Controllers
{
    public class CarroController : Controller
    {
        public ActionResult Index()
        {
            var model = new ModeloVM();
            var carroService = new CarroService();
            model.Carro = carroService.Lista();
            return View(model);
        }

        public ActionResult Listar(int idCarro)
        {
            var carroService = new ModeloService();
            var resultado = carroService.Lista(idCarro).OrderBy(x => x.ModeloCarro);
            var json = Json(new
            {
                data = resultado
            },
            JsonRequestBehavior.AllowGet);

            return json;
        }

        public JsonResult ListarPeca(int idModelo)
        {
            var pecaService = new PecaService();
            var resultado = pecaService.Lista(idModelo).OrderBy(x => x.QTD);
            
            var json = Json(new
            {
                data = resultado
            },
            JsonRequestBehavior.AllowGet);

            return json;
        }

        public ActionResult VisualizarModelo(int idModelo)
        {
            ViewBag.IdModelo = idModelo;
            return View();
        }

        public async Task<JsonResult> Mensagem(int idPeca, string mensagem)
        {
            var menssagem = new Mensageria();
            var messageriaService = new SendGridService();
            var result = new JsonResult();
            var pecaService = new PecaService();
            bool sucesso = false;
            var nomePeca = pecaService.NomePeca(idPeca);
            menssagem.Assunto = "Disponibilidade da Peça: " + nomePeca;
            menssagem.Mensagem = mensagem;
            menssagem.IdPeca = idPeca;

            //email temporario
            var destinatario = "jahiwe4221@seacob.com";

            sucesso = await messageriaService.DispararEmail(menssagem, destinatario);

            result.Data = new GenericTypes.AjaxResponse<int>
            {
                Ok = sucesso,
                MessageTitle = sucesso ? "Sucesso" : "Atenção",
                Message = sucesso ? "Mensagem enviada com sucesso" : "Ocorreu um erro durante o processo de envio de email, tente novamente mais tarde"
            };

            return result;
        }

        public ActionResult _ConteudoModal(int idPeca)
        {
            ViewBag.IdPeca = idPeca;
            return PartialView();
        }

    }
}
