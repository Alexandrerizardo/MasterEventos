using MasterEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace MasterEventos.Persistence.Contexto
{
    public class MasterEventosContext : DbContext
    {
        //criamos um constructor para passar as opçoes do DBcontext como argumentos
        public MasterEventosContext(DbContextOptions<MasterEventosContext> options) : base(options){}

        //com essa propriedade a gente cria a tabela no banco utilizando o ef
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes {get; set;}
        public DbSet<Lote> Lotes {get; set;}
        public DbSet<PalestranteEvento> PalestrantesEventos {get; set;}
        public DbSet<RedeSocial> RedesSociais {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }
    }
}