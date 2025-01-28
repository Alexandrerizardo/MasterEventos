using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterEventos.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public required Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public required Evento Evento { get; set; }
    }
}