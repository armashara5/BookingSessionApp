

using ApplicationLayer.RepositoriesContracts.ApplicationModels;

namespace ApplicationLayer.RepositoriesContracts
{
    public interface ISessionRepository
    {
        Task<int> CreateSessionAsync(SessionAppModel session);
    }
    
}
