namespace MasterEventos.Persistence.Interfaces
{
    public interface IGeralPersistence
    {
        void Add<T>(T Entidade) where T: class;
        void Update<T>(T Entidade) where T: class;
        void Delete<T>(T Entidade) where T: class;
        void DeleteRange<T>(T[] Entidade) where T: class;
        Task<bool> SaveChangesAsync();

    }
}