using ApplicationLayer.RepositoriesContracts.ApplicationModels;

namespace PresentationSecureApi.Models
{

    public class StudentVM
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }

}
