using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using InfrastructureLayer.DbModels;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly InfrastructureDbContext _dbContext;

        public StudentRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateStudent(StudentAppModel studentAppModel)
        {
            var studentDbModel = new StudentDbModel { Email = studentAppModel.Email, Id = studentAppModel.Id, Name = studentAppModel.Name };
            await _dbContext.Students.AddAsync(studentDbModel);
            await _dbContext.SaveChangesAsync();
            return studentDbModel.Id;
        }

        public async Task<StudentAppModel> GetStudentByIdAsync(string studentId)
        {
           var studentDbModel = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId);
            if (studentDbModel == null)
            {
                throw new Exception("Student not found");
            }
            return new StudentAppModel { Email = studentDbModel.Email, Name = studentDbModel.Name  , Id = studentDbModel.Id};
        }

       
    }

}
