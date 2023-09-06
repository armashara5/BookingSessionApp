using ApplicationLayer.RepositoriesContracts;
using InfrastructureLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISessionRepository, SessionRepository>();
            serviceCollection.AddScoped<IInstructorRepository, InstructorRepository>();
            serviceCollection.AddScoped<IConfigRepository, ConfigRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();

            return serviceCollection;

        }
    }
}
