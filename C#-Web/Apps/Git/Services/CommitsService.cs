using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string repositoryId, string creatorId, string description)
        {
            var commit = new Commit
            {
                Description = description,
                CreatorId = creatorId,
                RepositoryId = repositoryId,
                CreatedOn = DateTime.UtcNow,
            };
            this.db.Commits.Add(commit);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var commit = this.db.Commits.Where(x => x.Id == id).FirstOrDefault();
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<AllViewModel> GetAll()
        {
            var commits = this.db.Commits.Select(x => new AllViewModel
            {
                Description = x.Description,
                Repository = x.Repository.Name,
                CreatedOn = DateTime.UtcNow,
            }).ToList();

            return commits;
        }
    }
}
