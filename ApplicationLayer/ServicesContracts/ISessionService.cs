
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using DomainLayer.ValueObjects;

namespace ApplicationLayer.ServicesContracts
{

    public interface ISessionService
    {
        Task<int> BookSession(string instructorId, string studentId, DateTime startTime, int lengthHours, int lengthMinutes);
    }
    
        
}

