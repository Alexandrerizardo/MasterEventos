using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterEventos.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string URL { get; set; }
        public int? EventoId { get; set; }
        public required Evento Evento { get; set; }
        public int? PalestranteId { get; set; }
        public required Palestrante Palestrante { get; set; }
    }
}