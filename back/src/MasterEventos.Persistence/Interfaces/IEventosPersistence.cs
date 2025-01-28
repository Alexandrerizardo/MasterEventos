using MasterEventos.Domain;

namespace MasterEventos.Persistence.Interfaces
{
    public interface IEventosPersistence
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int Id, bool includePalestrantes = false);

    }
}