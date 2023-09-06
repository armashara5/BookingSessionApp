using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using ApplicationLayer.ServicesContracts;
using DomainLayer.Entities;

namespace ApplicationLayer.Services
{
    public class InstructorService : IInstructorService
    {

        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<string> CreateInstructorAsync(InstructorAppModel instructor)
        {
            var result = await _instructorRepository.CreateInstructorAsync(instructor);
            return result;
        }

        public async Task<InstructorAppModel> GetInstuctorByIdAsync(string instructorId)
        {
            var result  = await _instructorRepository.GetInstuctorByIdAsync(instructorId);
            return result;
        }

        public async Task<IEnumerable<InstructorAppModel>> GetInstuctorsAsync()
        {
            var result = await _instructorRepository.GetAllInstructorsAsync();
            return result;
        }
    }
}