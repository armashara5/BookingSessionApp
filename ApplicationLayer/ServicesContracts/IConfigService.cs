namespace ApplicationLayer.ServicesContracts
{
    public interface IConfigService
    {
        Task ApplyMigrations();
        Task ResetDb();
    }

}

