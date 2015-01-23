using System.Web.Mvc;
using QualityDigital.TesteMarcos.Web.App.Servidor.Dominio.Servicos;
using QualityDigital.TesteMarcos.Web.App.Servidor.Infraestrutura.Fabricas;
using QualityDigital.TesteMarcos.Web.Infraestrutura.Repositorios;

namespace QualityDigital.TesteMarcos.Web.Controllers
{
    public class InscricaoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Pacotes = new ServicoDeConsultaDePacotes(() => FabricaUnidadeDeTrabalho.Criar(), new Pacotes()).ConsultarTodos();
            return View("Index");
        }

        public ActionResult ConsultarPacote(int idDoPacote)
        {
            return Json(new ServicoDeConsultaDePacotes(() => FabricaUnidadeDeTrabalho.Criar(), new Pacotes()).ConsultarPorId(idDoPacote), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CalcularInscricao(
            int pacoteSelecionado,
            int[] atividadesSelecionadas)
        {
            var precoDaInscricao = new ServicoParaCalcularPrecoDaInscricao(new ServicoDeConsultaDePacotes(() => FabricaUnidadeDeTrabalho.Criar(), new Pacotes()))
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