using System.Collections.Generic;
using DAO;
using DTO;
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

        public IActionResult Index()
        {
            var dao = new ContatoDAO();
            var lstContatoDTO = dao.Consultar();
            var lstContato = new List<Contato>();

            foreach(var dto in lstContatoDTO)
            {
                lstContato.Add(new Contato()
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Sobrenome = dto.Sobrenome,
                    Email = dto.Email
                });
            }
            return View(lstContato);
        }

        public IActionResult Details(int id)
        {
            var contatoDAO = new ContatoDAO();
            var contatoDTO = contatoDAO.Consultar(id);

            var contato = new Contato()
            {
                Id = contatoDTO.Id,
                Nome = contatoDTO.Nome,
                Sobrenome = contatoDTO.Sobrenome,
                Email = contatoDTO.Email
            };
            return View(contato);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            var contatoDTO = new ContatoDTO
            {
                Nome = contato.Nome,
                Sobrenome = contato.Sobrenome,
                Email = contato.Email
            };

            var contatoDAO = new ContatoDAO();
            contatoDAO.Criar(contatoDTO);

            return View();
        }

        public IActionResult Update(int id)        
        {
            var contatoDAO = new ContatoDAO();
            var contatoDTO = contatoDAO.Consultar(id);

            var contato = new Contato()
            {
                Id = contatoDTO.Id,
                Nome = contatoDTO.Nome,
                Sobrenome = contatoDTO.Sobrenome,
                Email = contatoDTO.Email
            };

            return View(contato);
        }


        [HttpPost]
        public IActionResult Update(Contato contato)
        {
            var contatoDTO = new ContatoDTO
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Sobrenome = contato.Sobrenome,
                Email = contato.Email
            };

            var contatoDAO = new ContatoDAO();
            contatoDAO.Atualizar(contatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var contatoDAO = new ContatoDAO();
            contatoDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}