using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAO;
using DTO;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private IContatoDAO _contatoDAO;
        
        public ContatoController(IContatoDAO contatoDAO)
        {
            _contatoDAO = contatoDAO;
        }
        public IActionResult Index()
        {
            var lstContatoDTO = _contatoDAO.Consultar();
            var lstContato = new List<ContatoViewModel>();

            foreach(var dto in lstContatoDTO)
            {
                lstContato.Add(new ContatoViewModel()
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Sobrenome = dto.Sobrenome,
                    Email = dto.Email
                });
            }
            return View(lstContato);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ContatoViewModel contato)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var ContatoDTO = new ContatoDTO
            {
                Nome = contato.Nome,
                Sobrenome = contato.Sobrenome,
                Email = contato.Email
            };

            _contatoDAO.Criar(ContatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

            var contato = new ContatoViewModel()
            {
                Id = contatoDTO.Id,
                Nome = contatoDTO.Nome,
                Sobrenome = contatoDTO.Sobrenome,
                Email = contatoDTO.Email
            };
            return View(contato);
        }

        public IActionResult Update(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

            var contato = new ContatoViewModel()
            {
                Id = contatoDTO.Id,
                Nome = contatoDTO.Nome,
                Sobrenome = contatoDTO.Sobrenome,
                Email = contatoDTO.Email
            };

            return View(contato);
        }

        [HttpPost]
        public IActionResult Update(ContatoViewModel contato)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var contatoDTO = new ContatoDTO
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Sobrenome = contato.Sobrenome,
                Email = contato.Email
            };

            _contatoDAO.Atualizar(contatoDTO);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _contatoDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}