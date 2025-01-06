using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterEventos.API.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public required string Local { get; set; }
        public required string DataEvento { get; set; }
        public required string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public required string Lote { get; set; }
        public required string ImageURL { get; set; }

    }
}