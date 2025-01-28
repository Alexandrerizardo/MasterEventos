using MasterEventos.Domain;
using MasterEventos.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;


namespace MasterEventos.Persistence.Interfaces
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly MasterEventosContext _context;
        public GeralPersistence(MasterEventosContext context)
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}