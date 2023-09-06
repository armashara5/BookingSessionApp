using ApplicationLayer.RepositoriesContracts;
using ApplicationLayer.ServicesContracts;

namespace ApplicationLayer.Services
{
    public class ConfigService : IConfigService
    {

        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository config)
        {
            _configRepository = config;
        }

        public async Task ApplyMigrations()
        {
            await _configRepository.ApplyMigrations();
        }


        public async Task ResetDb()
        {
            await _configRepository.ResetDb();
        }
    }




}