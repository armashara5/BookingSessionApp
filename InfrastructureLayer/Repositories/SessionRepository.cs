using ApplicationLayer;
using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using DomainLayer.Entities;
using InfrastructureLayer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly InfrastructureDbContext _dbContext;

        public SessionRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateSessionAsync(SessionAppModel session)
        {
            var sessionDbModel = new SessionDbModel {StartDate = session.StartDate, LengthInMinutes = session.LengthInMinutes, InstructorId = session.InstructorId, StudentId = session.StudentId };
            try
            {
            await _dbContext.Sessions.AddAsync(sessionDbModel);
            await _dbContext?.SaveChangesAsync();
            return sessionDbModel.Id;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }

}
