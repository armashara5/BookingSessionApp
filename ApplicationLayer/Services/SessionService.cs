using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using ApplicationLayer.ServicesContracts;
using DomainLayer.Aggregates;
using DomainLayer.Entities;
using DomainLayer.Exceptions;
using DomainLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DayOfWeek = DomainLayer.ValueObjects.DayOfWeek;

namespace ApplicationLayer.Services
{
    public class SessionService : ISessionService
    {
        private readonly IBookingRules _bookingRules;
        private readonly ISessionRepository _sessionRepository;
        private readonly IInstructorRepository _instructorRepository;

        public SessionService(IBookingRules bookingRules, ISessionRepository sessionRepository, IInstructorRepository instructorRepository)
        {
            _bookingRules = bookingRules;
            _sessionRepository = sessionRepository;
            _instructorRepository = instructorRepository;
        }

        public async Task<int> BookSession(string instructorId, string studentId, DateTime startTime, int lengthHours, int lengthMinutes)
        {
            DayOfWeek dayOfWeek = new DayOfWeek { Value = (int)startTime.DayOfWeek };
            var existedInstuctor = await _instructorRepository.GetInstuctorByIdAsync(instructorId);

            Instructor domainInstructor = GetDomainInstructor(existedInstuctor);
            TimeOfDay sessionTime = new TimeOfDay { Hours = startTime.Hour, Minutes = startTime.Minute };

            if (!_bookingRules.IsInstructorAvailable(domainInstructor, dayOfWeek, sessionTime))
                throw new InstructorNotAvailableException("Instructor not available");

            if (_bookingRules.IsInstructorBooked(domainInstructor, startTime, sessionTime))
                throw new InstructorAlreadyBookedException("Cannot book session");

            var session = new SessionAppModel
            {
                StudentId = studentId,
                InstructorId = instructorId,
                StartDate = startTime,
                LengthInMinutes = (lengthHours * 60) + lengthMinutes,
            };

            await _sessionRepository.CreateSessionAsync(session);
            return session.Id;
        }

        private Instructor GetDomainInstructor(InstructorAppModel instructor)
        {
            return new Instructor
            {
                Email = instructor.Email,
                Name = instructor.Name,
                Availabilities = instructor.Availabilities != null ? instructor.Availabilities.Select(x => new Availability
                {
                    DayOfWeek = new DayOfWeek { Value = x.DayOfWeek },
                    EndTime = new TimeOfDay { Hours = x.EndTimeHours, Minutes = x.EndTimeMinutes },
                    StartTime = new TimeOfDay { Hours = x.StartTimeHours, Minutes = x.StartTimeMinutes },
                }).ToList() : new List<Availability>(),
                Sessions = instructor.Sessions != null ? instructor.Sessions
                .Select(s => new Session { Length = new TimeOfDay { Hours = s.LengthInMinutes / 60, Minutes = s.LengthInMinutes % 60 }, StartDate = s.StartDate })
                .ToList() : new List<Session>(),
            };
        }
    }

}