using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MasterEventos.API.Data;
using MasterEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MasterEventos.API.Controllers
{
    [Route("api/[controller]")]
    public class PalestranteController : ControllerBase
    {
        private readonly DataContext _context;

        public PalestranteController(DataContext context)
        {
          _context = context;
        }

        [HttpGet]

        public IEnumerable<Palestrante> GetaAll(){
            return _context.Palestrantes;
        }

        [HttpGet("{id}")]

        public Palestrante GetByID(int id)
        {
            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return _context.Palestrantes.FirstOrDefault(Palestrante => Palestrante.PalestranteId == id);
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }
    }
}