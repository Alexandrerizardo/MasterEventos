using MasterEventos.Domain;

namespace MasterEventos.Persistence.Interfaces
{
    public interface IPalestrantesPersistence
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int Id, bool includeEventos = false);
    }
}