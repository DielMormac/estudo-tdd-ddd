using System.Web.Mvc;
using Marcos.EstudoTddDdd.Web.App.Servidor.Dominio.Servicos;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Fabricas;
using Marcos.EstudoTddDdd.Web.App.Servidor.Infraestrutura.Repositorios;

namespace Marcos.EstudoTddDdd.Web.Controllers
{
    public class InscricaoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Pacotes = new ServicoDeConsultaDePacotes(FabricaUnidadeDeTrabalho.Criar, new Pacotes()).ConsultarTodos();
            return View("Index");
        }

        public ActionResult ConsultarPacote(int idDoPacote)
        {
            return Json(new ServicoDeConsultaDePacotes(FabricaUnidadeDeTrabalho.Criar, new Pacotes()).ConsultarPorId(idDoPacote), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CalcularInscricao(
            int pacoteSelecionado,
            int[] atividadesSelecionadas)
        {
            var precoDaInscricao = new ServicoParaCalcularPrecoDaInscricao(new ServicoDeConsultaDePacotes(FabricaUnidadeDeTrabalho.Criar, new Pacotes()))
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