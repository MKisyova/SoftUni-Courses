using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(string ownerId, string name, bool repositoryType);

        IEnumerable<RepositoriesAllViewModel> GetAll();

        IEnumerable<RepositoriesAllViewModel> GetAllPublic();

        string GetNameById(string id);


    }
}
