

using ApplicationLayer.RepositoriesContracts.ApplicationModels;

namespace ApplicationLayer.RepositoriesContracts
{
    public interface IStudentRepository
    {
        Task<string> CreateStudent(StudentAppModel studentAppModel);
        Task<StudentAppModel> GetStudentByIdAsync(string studentId);
    }
}
