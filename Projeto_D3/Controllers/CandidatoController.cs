using Microsoft.AspNetCore.Mvc;
using Projeto_D3.Interface;
using Projeto_D3.Models;

namespace Projeto_D3.Controllers
{
    public class CandidatoController : Controller
    {
        
        ICandService CAND;
        public CandidatoController(ICandService _candida)
        {
            CAND = _candida;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Creates(Candidato CC)
        {
            CAND.Adicionar(CC.NomeCand, CC.Telefone, CC.Localizacao, CC.Nivel, CC.Tecnologia);
            return View("Privacy");
        }


    }
}
