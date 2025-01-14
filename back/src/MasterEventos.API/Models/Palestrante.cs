using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterEventos.API.Models
{
    public class Palestrante
    {
        public int PalestranteId { get; set; }
        public required string Nome { get; set; }
        public int Idade { get; set; }
        public required string Email { get; set; }
        public required string Linkedin { get; set; }

    }
}