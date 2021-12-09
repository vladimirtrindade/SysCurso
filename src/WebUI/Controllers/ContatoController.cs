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
        private readonly ITelefoneDAO _telefoneDAO;


        public ContatoController(IContatoDAO contatoDAO, IMapper mapper, ITelefoneDAO telefoneDAO)
        {
            _contatoDAO = contatoDAO;
            _mapper = mapper;
            _telefoneDAO = telefoneDAO;
        }

        public IActionResult Index()
        {
            var lstContatoDTO = _contatoDAO.Consultar();
            var lstContatoViewModel = new List<ContatoViewModel>();

            foreach(var contatoDTO in lstContatoDTO)
            {
                lstContatoViewModel.Add(_mapper.Map<ContatoViewModel>(contatoDTO));
            }

            return View(lstContatoViewModel);
        }

        public IActionResult Details(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO);

            var lstTelefoneDTO = _telefoneDAO.ConsultarPorContato(id);

            foreach(var telefoneDTO in lstTelefoneDTO)
            {
                contatoViewModel.LstTelefoneViewModel.Add(_mapper.Map<TelefoneViewModel>(telefoneDTO));
            }

            return View(contatoViewModel);
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
            _contatoDAO.Criar(contatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);
            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO);

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