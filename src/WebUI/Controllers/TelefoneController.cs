using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DAO;
using DTO;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly ITelefoneDAO _telefoneDAO;
        private readonly IMapper _mapper;
        public TelefoneController(ITelefoneDAO telefoneDAO, IMapper mapper)
        {
            _telefoneDAO = telefoneDAO;
            _mapper = mapper;
        }

        public IActionResult Create(int id)
        {
            var telefoneViewModel = new TelefoneViewModel(){ ContatoId = id };

            return View(telefoneViewModel);
        }

        [HttpPost]
        public IActionResult Create(TelefoneViewModel telefoneViewModel)
        {
            var telefoneDTO = _mapper.Map<TelefoneDTO>(telefoneViewModel);

            _telefoneDAO.Criar(telefoneDTO);

            return RedirectToAction("Details", "Contato", new { id = telefoneViewModel.ContatoId });
        }

        public IActionResult Delete(int contatoId, int id)
        {
            _telefoneDAO.Excluir(id);

            return RedirectToAction("Details", "Contato", new { id = contatoId });
        }

        public IActionResult Update(int id)
        {
            var telefoneDTO = _telefoneDAO.Consultar(id);

            var telefoneViewModel = _mapper.Map<TelefoneViewModel>(telefoneDTO);

            return View(telefoneViewModel);
        }

        [HttpPost]
        public IActionResult Update(TelefoneViewModel telefoneViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var telefoneDTO = _mapper.Map<TelefoneDTO>(telefoneViewModel);

            _telefoneDAO.Atualizar(telefoneDTO);

            return RedirectToAction("Details", "Contato", new { id = telefoneViewModel.ContatoId });
        }
    }
}