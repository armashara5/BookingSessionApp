using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using InfrastructureLayer.DbModels;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly InfrastructureDbContext _dbContext;

        public InstructorRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateInstructorAsync(InstructorAppModel instructor)
        {
            var instructorDbModel = new InstructorDbModel { Email = instructor.Email, Id = instructor.Id, Name = instructor.Name };
            try
            {

            await _dbContext.Instructors.AddAsync(instructorDbModel);
            await _dbContext.SaveChangesAsync();
            return instructorDbModel.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<InstructorAppModel>> GetAllInstructorsAsync()
        {
            try
            {
                var result = await _dbContext.Instructors.Select(x => GetInstructorAppModel(x)).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<InstructorAppModel> GetInstuctorByIdAsync(string instructorId)
        {
            var instructorDbModel = await _dbContext.Instructors
                .Include(a => a.Availabilities)
                .Include(s => s.Sessions)
                .FirstAsync(x => x.Id == instructorId);
            InstructorAppModel result = GetInstructorAppModel(instructorDbModel);

            return result;
        }

        private static InstructorAppModel GetInstructorAppModel(InstructorDbModel instructorDbModel)
        {
            return new InstructorAppModel
            {
                Id = instructorDbModel.Id,
                Email = instructorDbModel.Email,
                Name = instructorDbModel.Name,
                Availabilities = instructorDbModel.Availabilities?
                .Select(x => new AvailabilityAppModel
                {
                    DayOfWeek = x.DayOfWeek,
                    EndTimeHours = x.EndTimeHours,
                    EndTimeMinutes = x.EndTimeHours,
                    StartTimeHours = x.StartTimeHours,
                    StartTimeMinutes = x.StartTimeHours
                })
                .ToList(),
                Sessions = instructorDbModel.Sessions?
                .Select(s => new SessionAppModel { InstructorId = instructorDbModel.Id, LengthInMinutes = s.LengthInMinutes, StartDate = s.StartDate })
                .ToList(),
            };
        }
    }

}
