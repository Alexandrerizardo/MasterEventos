using MasterEventos.Domain;
using MasterEventos.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;


namespace MasterEventos.Persistence.Interfaces
{
    public class PalestrantesPersistence : IPalestrantesPersistence
    {
        private readonly MasterEventosContext _context;
        public PalestrantesPersistence(MasterEventosContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entidade) where T : class
        {
            _context.Add(Entidade);
        }

        public void Delete<T>(T Entidade) where T : class
        {
            _context.Remove(Entidade);
        }

        public void DeleteRange<T>(T[] Entidades) where T : class
        {
            _context.RemoveRange(Entidades);
        }
        public void Update<T>(T Entidade) where T : class
        {
            _context.Update(Entidade);
        }


        ////////////////////////////TASKS////////////////////////////////////

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower()
                .Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int Id, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                .Where(e => e.Id == Id);

            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return await query.FirstOrDefaultAsync();
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(P => P.Id)
                .Where(p => p.Nome.ToLower()
                .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int Id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.PalestrantesEventos);

            if (includeEventos)
            {
                query = query.Include(p => p.PalestrantesEventos)
                             .ThenInclude(pe => pe.Evento);
            }

            query.OrderBy(p => p.Id)
                 .Where(p => p.Id == Id);

            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return await query.FirstOrDefaultAsync();
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

    }
}