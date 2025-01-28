namespace MasterEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public required string Local { get; set; }
        public required DateTime? DataEvento { get; set; }
        public required string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public required string Lote { get; set; }
        public required string ImageURL { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public required IEnumerable<Lote> Lotes { get; set; }
        public required IEnumerable<RedeSocial> RedesSociais { get; set; }
        public required IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}