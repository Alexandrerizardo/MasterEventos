using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEventos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> _evento = new Evento[]
        {
              new Evento(){
                    EventoId = 1,
                    Tema = "Aprendendo Angular e C#",
                    Local = "São Paulo",
                    Lote = "1° Lote",
                    QtdPessoas = 250,
                    DataEvento =  DateTime.Now.AddDays(2).ToString(),
                    ImageURL = "foto.png"
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Aprendendo TypeScript",
                    Local = "Rio de Janeiro",
                    Lote = "1° Lote",
                    QtdPessoas = 120,
                    DataEvento =  DateTime.Now.AddDays(10).ToString(),
                    ImageURL = "foto2.png"
                },
                 new Evento(){
                    EventoId = 3,
                    Tema = "Aprendendo Python",
                    Local = "Florianópolis",
                    Lote = "1° Lote",
                    QtdPessoas = 520,
                    DataEvento =  DateTime.Now.AddDays(20).ToString(),
                    ImageURL = "foto3.png"
                }

        };
        public EventoController()
        {
        }

        [HttpGet]

        public IEnumerable<Evento> GetAll()
        {
           return _evento;
        }

       [HttpGet("{id}")]

        public IEnumerable<Evento> GetByID(int id)
        {
           return _evento.Where(Evento => Evento.EventoId == id);
        }

    }
}