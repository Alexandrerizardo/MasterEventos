using MasterEventos.Application.Interfaces;
using MasterEventos.Domain;
using MasterEventos.Persistence.Interfaces;

namespace MasterEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistence _geralPersist;
        public readonly IEventosPersistence _eventosPersist;

        public EventoService(IGeralPersistence geralPersist, IEventosPersistence eventosPersist)
        {
            _eventosPersist = eventosPersist;
            _geralPersist = geralPersist;
        }

        public async Task<Evento> AddEventos(Evento modelEvento)
        {
            try
            {
                _geralPersist.Add<Evento>(modelEvento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventosPersist.GetEventoByIdAsync(modelEvento.Id, false);
                }

#pragma warning disable CS8603 
                return null;
#pragma warning restore CS8603 
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<bool> DeleteEventos(int EventoId)
        {
            try
            {
                var evento = await _eventosPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null) throw new Exception("Evento para deletar não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }
        public async Task<Evento> UpdateEventos(int EventoId, Evento modelEvento)
        {
           try
            {
                var evento = await _eventosPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null) throw new Exception("Evento para Atualizar não encontrado.");

                modelEvento.Id = evento.Id;

                _geralPersist.Update(modelEvento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventosPersist.GetEventoByIdAsync(modelEvento.Id, false);
                }

#pragma warning disable CS8603 
                return null;
#pragma warning restore CS8603 
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersist.GetAllEventoAsync(includePalestrantes);
#pragma warning disable CS8603 
                if (eventos == null) return null;
#pragma warning restore CS8603 

                return eventos;    
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventosPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
#pragma warning disable CS8603 
                if (eventos == null) return null;
#pragma warning restore CS8603 
                
                return eventos;    
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int Id, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersist.GetEventoByIdAsync(Id, includePalestrantes);
#pragma warning disable CS8603 
                if (eventos == null) return null;
#pragma warning restore CS8603 
                
                return eventos;    
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

    }
}