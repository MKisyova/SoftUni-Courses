using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string ownerId, string name, bool repositoryType)
        {
            var repository = new Repository 
            {
                Name = name, 
                IsPublic = repositoryType,
                OwnerId = ownerId,
            };
            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoriesAllViewModel> GetAll()
        {
            var repositories = this.db.Repositories.Select(x => new RepositoriesAllViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = DateTime.UtcNow,
                CommitsCount = x.Commits.Count(),
                Id = x.Id
            }).ToList();

            return repositories;
        }

        public IEnumerable<RepositoriesAllViewModel> GetAllPublic()
        {
            var repositories = this.db.Repositories.Where(x => x.IsPublic == true)
                .Select(x => new RepositoriesAllViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = DateTime.UtcNow,
                CommitsCount = x.Commits.Count(),
                Id = x.Id
            }).ToList();

            return repositories;
        }

        //public string GetById(string id)
        //{
        //    return this.db.Repositories
        //        .Where(x => x.Id == id)
        //        .Select(x => x.Id)
        //        .FirstOrDefault();
        //}

        public string GetNameById(string id)
        {
            return this.db.Repositories
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }
    }
}
