using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string MiniCurriculo { get; set; }
        public required string ImagemURL { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public required IEnumerable<RedeSocial> RedesSociais { get; set; }
        public required IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}