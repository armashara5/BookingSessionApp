using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using ApplicationLayer.ServicesContracts;
using DomainLayer.Entities;

namespace ApplicationLayer.Services
{
    public class StudentService : IStudentService
    {
       
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<string> CreateStudentAsync(StudentAppModel studentAppModel)
        {
          var createdId =  await _studentRepository.CreateStudent(studentAppModel);
            return createdId;
        }

        public async Task<StudentAppModel> GetStudentByIdAsync(string studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            return student;
        }
    }




}