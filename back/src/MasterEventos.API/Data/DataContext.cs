using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEventos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterEventos.API.Data
{
    public class DataContext : DbContext
    {
        //criamos um constructor para passar as opçoes do DBcontext como argumentos
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        //com essa propriedade a gente cria a tabela no banco utilizando o ef
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes {get; set;}
    }
}