using ApplicationLayer.RepositoriesContracts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly InfrastructureDbContext _dbContext;

        public ConfigRepository(InfrastructureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ApplyMigrations()
        {

            var migrator = _dbContext.Database.GetService<IMigrator>();
           await migrator.MigrateAsync();
        }

        public async Task ResetDb()
        {
            // Delete the existing database
            await _dbContext.Database.EnsureDeletedAsync();

            // Create a new empty database
            await _dbContext.Database.EnsureCreatedAsync();

            var migrator = _dbContext.Database.GetService<IMigrator>();
            await migrator.MigrateAsync();
        }
    }
}
