using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.Services;
using ApplicationLayer.ServicesContracts;
using DomainLayer.Aggregates;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISessionService, SessionService>();
            serviceCollection.AddScoped<IInstructorService, InstructorService>();
            serviceCollection.AddScoped<IConfigService, ConfigService>();
            serviceCollection.AddScoped<IStudentService, StudentService>();


            //Domain dependencies registration
            serviceCollection.AddScoped<IBookingRules, BookingRules>();

            return serviceCollection;
        }
    }
}
