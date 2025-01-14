using MasterEventos.API.Data;
using MasterEventos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]

        public IEnumerable<Evento> GetAll()
        {
           return _context.Eventos;
        }

       [HttpGet("{id}")]

        public Evento GetByID(int id)
        {
            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return _context.Eventos.FirstOrDefault(Evento => Evento.EventoId == id);
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }
    }
}