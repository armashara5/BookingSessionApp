using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.RepositoriesContracts
{
    public interface IConfigRepository
    {
        Task ApplyMigrations();
        Task ResetDb();
    }
}
