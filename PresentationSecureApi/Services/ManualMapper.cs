using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using Microsoft.AspNetCore.Identity;
using PresentationSecureApi.Models;

namespace PresentationSecureApi.Services
{
    public static class ManualMapper
    {
        internal static InstructorAppModel GetInstructorAppModel(IdentityUser user)
        {
            if(string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentNullException("User name or email is empty");
            return new InstructorAppModel { Email = user.Email, Name = user.UserName , Id = user.Id};
        }

        internal static IEnumerable<InstructorVM> GetInstuctorsVM(IEnumerable<InstructorAppModel> instructorsAppModel)
        {
           var result =  instructorsAppModel.Select(x => new InstructorVM
            {
                Email = x.Email,
                Name = x.Name,
                Id = x.Id,
                Availabilities = x.Availabilities?.Select(a => new AvailabilityVM { DayOfWeek = a.DayOfWeek, EndTimeHours = a.EndTimeHours, EndTimeMinutes = a.EndTimeHours, StartTimeHours = a.StartTimeHours, StartTimeMinutes = a.StartTimeHours }).ToList(),
                Sessions = x.Sessions?.Select(s => new SessionVM
                {
                    Id = s.Id,
                    InstructorId = s.InstructorId,
                    LengthInMinutes = s.LengthInMinutes,
                    StartDate = s.StartDate,
                    StudentId = s.StudentId
                }).ToList()
            });
            return result;
        }

        internal static StudentAppModel GetStudentAppModel(StudentVM student)
        {
            return new StudentAppModel { Email = student.Email, Name = student.Name, Id = student.Id };
        }
        internal static StudentAppModel GetStudentAppModel(IdentityUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.UserName))
                throw new ArgumentNullException("User name or email is empty");
            return new StudentAppModel { Email = user.Email, Name = user.UserName, Id = user.Id };
        }
        internal static StudentVM GetStudentVm(StudentAppModel student)
        {
            return new StudentVM { Email = student.Email, Name = student.Name, Id = student.Id };
        }
    }
}
