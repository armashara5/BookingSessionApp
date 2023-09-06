
using ApplicationLayer.RepositoriesContracts.ApplicationModels;

namespace ApplicationLayer.ServicesContracts
{
    public interface IInstructorService
    {
        Task<string> CreateInstructorAsync(InstructorAppModel instructor);
        Task<InstructorAppModel> GetInstuctorByIdAsync(string instructorId);
        Task<IEnumerable<InstructorAppModel>> GetInstuctorsAsync();
    }


}

