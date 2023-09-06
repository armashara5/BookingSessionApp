
using ApplicationLayer.RepositoriesContracts.ApplicationModels;

namespace ApplicationLayer.ServicesContracts
{
    public interface IStudentService
    {
        Task<string> CreateStudentAsync(StudentAppModel studentAppModel);
        Task<StudentAppModel> GetStudentByIdAsync(string studentId);
    }

}

