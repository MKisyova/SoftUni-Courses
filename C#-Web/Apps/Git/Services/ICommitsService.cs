using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create (string repositoryId, string creatorId, string description);

        IEnumerable<AllViewModel> GetAll(string creatorId);

        void Delete (string id);
    }
}
