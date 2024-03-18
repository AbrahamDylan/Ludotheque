using Ludotheque.EvenementLocation.Models;

namespace Ludotheque.EvenementLocation.Services {
    
    public interface IEvenementService
    {
        Task<List<Evenement?>> GetEvenement(string EventId);

        Task<Evenement> AddEvenement(Evenement evenement);
    }

}