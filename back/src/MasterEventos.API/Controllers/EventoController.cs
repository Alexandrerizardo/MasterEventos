using MasterEventos.Persistence;
using MasterEventos.Domain;
using Microsoft.AspNetCore.Mvc;
using MasterEventos.Persistence.Contexto;
using MasterEventos.Application;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MasterEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _eventoService;
        public EventoController(EventoService eventoService) 
        {
            _eventoService = eventoService;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventoAsync(true);
                if (eventos == null) return NotFound("Nenhum evento encontrado. ");

                return Ok(eventos);
                
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar eventos. Erro: {err}");
            }
        }

       [HttpGet("{id}")]

        public async Task<IActionResult> GetEventoByID(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);
                if(evento == null) return NotFound("O evento não foi encontrado!");

                return Ok(evento);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar evento. Erro: {err}");
            }
        }

        [HttpGet("{tema}/tema")]

        public async Task<IActionResult> GetEventoByTema(string tema)
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if(eventos == null) return NotFound($"Não foi possível encontrar os eventos com o tema: {tema}");

                return Ok(eventos);
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os eventos. Erro: {err}");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if (evento == null) return BadRequest("Erro ao adicionar evento.");

                return Ok(evento);    
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar novo evento. Erro: {err}");
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEventos(id, model);
                if (evento == null) return BadRequest("Erro ao atualizar evento.");

                return Ok(evento);    
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar novo evento. Erro: {err}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                    return await _eventoService.DeleteEventos(id) ? 
                    Ok("Deletado") : 
                    BadRequest("Evento não deletado");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar novo evento. Erro: {err}");
            }
        }
    }
}