

using ApplicationLayer.RepositoriesContracts.ApplicationModels;

namespace ApplicationLayer.RepositoriesContracts
{
    public interface IInstructorRepository
    {
        Task<InstructorAppModel> GetInstuctorByIdAsync(string instructorId);
        Task<IEnumerable<InstructorAppModel>> GetAllInstructorsAsync();
        Task<string> CreateInstructorAsync(InstructorAppModel instructor);
    }
}
