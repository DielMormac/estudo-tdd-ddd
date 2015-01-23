using System.Web.Mvc;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Servicos;

namespace QualityDigital.TesteMarcos.Web.Controllers
{
    public class InscricaoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Pacotes = new ServicoDeConsultaDePacotes().ConsultarTodos();
            return View("Index");
        }

        public ActionResult ConsultarPacote(int idDoPacote)
        {
            return Json(new ServicoDeConsultaDePacotes().ConsultarPorId(idDoPacote), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CalcularInscricao(
            int pacoteSelecionado,
            int[] atividadesSelecionadas)
        {
            var precoDaInscricao = new ServicoParaCalcularPrecoDaInscricao(new ServicoDeConsultaDePacotes())
                .Calcular(pacoteSelecionado, atividadesSelecionadas);

            return Json(precoDaInscricao, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConfirmarInscricao(
            string nomeDoParticipante,
            string dataDeDascimentoDoParticipante,
            string telefoneDoParticipante,
            int pacoteSelecionado,
            string[] atividadesSelecionadas
            )
        {
            return Index();
        }
    }
}