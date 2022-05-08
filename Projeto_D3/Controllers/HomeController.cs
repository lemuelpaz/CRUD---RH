using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_D3.Interface;
using Projeto_D3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Projeto_D3.Controllers
{
    public class HomeController : Controller
    {

        IHomeService teste;
        public HomeController(IHomeService _teste)
        {
            teste = _teste;
        }       


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Lista()
        {
            IEnumerable<Cadastro> Varia = teste.GetMonitorar();
            return View(Varia);
        }

        [HttpPost]  
        public IActionResult Create(Cadastro CD) 
        {
            teste.AddCadastro(CD.Nome, CD.CRM);
            return View("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
