using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAO;
using DTO;
using WebUI.Models;
using AutoMapper;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoDAO _contatoDAO;
        private readonly IMapper _mapper;
        
        public ContatoController(IContatoDAO contatoDAO, IMapper mapper)
        {
            _contatoDAO = contatoDAO;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var lstContatoDTO = _contatoDAO.Consultar();
            var lstContatoViewModel = new List<ContatoViewModel>();

            foreach(var contatoDTO in lstContatoDTO)
            {
                lstContatoViewModel.Add(_mapper.Map<ContatoViewModel>(contatoDTO));
            }

            // foreach(var dto in lstContatoDTO)
            // {
            //     lstContato.Add(new ContatoViewModel()
            //     {
            //         Id = dto.Id,
            //         Nome = dto.Nome,
            //         Sobrenome = dto.Sobrenome,
            //         Email = dto.Email
            //     });
            // }
            return View(lstContatoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ContatoViewModel contatoViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoViewModel);
            // var ContatoDTO = new ContatoDTO
            // {
            //     Nome = contatoViewModel.Nome,
            //     Sobrenome = contatoViewModel.Sobrenome,
            //     Email = contatoViewModel.Email
            // };

            _contatoDAO.Criar(contatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO);
            // var contato = new ContatoViewModel()
            // {
            //     Id = contatoDTO.Id,
            //     Nome = contatoDTO.Nome,
            //     Sobrenome = contatoDTO.Sobrenome,
            //     Email = contatoDTO.Email
            // };
            return View(contatoViewModel);
        }

        public IActionResult Update(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO);
            // var contatoViewModel = new ContatoViewModel()
            // {
            //     Id = contatoDTO.Id,
            //     Nome = contatoDTO.Nome,
            //     Sobrenome = contatoDTO.Sobrenome,
            //     Email = contatoDTO.Email
            // };

            return View(contatoViewModel);
        }

        [HttpPost]
        public IActionResult Update(ContatoViewModel contatoViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoViewModel);

            // var contatoDTO = new ContatoDTO
            // {
            //     Id = contatoViewModel.Id,
            //     Nome = contatoViewModel.Nome,
            //     Sobrenome = contatoViewModel.Sobrenome,
            //     Email = contatoViewModel.Email
            // };

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