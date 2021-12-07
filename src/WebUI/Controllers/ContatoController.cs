using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        List<Contato> lstContato = new List<Contato>();

        public ContatoController()
        {
            lstContato.Add(new Contato() { Id = 1, Nome = "vla", Sobrenome = "Dimir", Email = "vla@dimir.com" });
            lstContato.Add(new Contato() { Id = 2, Nome = "con", Sobrenome = "Suelo", Email = "con@suelo.com" });
        }

        public IActionResult Details(int id)
        {
            var contato = lstContato.Find(contato => contato.Id == id);
            return View(contato);
        }
        public IActionResult Index()
        {
            return View(lstContato);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato model)
        {

            return View();
        }
    }
}