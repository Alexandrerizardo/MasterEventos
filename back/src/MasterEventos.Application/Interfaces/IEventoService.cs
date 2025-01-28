using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEventos.Domain;

namespace MasterEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento modelEvento);
        Task<Evento> UpdateEventos(int EventoId, Evento modelEvento);
        Task<bool> DeleteEventos(int EventoId);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int Id, bool includePalestrantes = false);
    }
}