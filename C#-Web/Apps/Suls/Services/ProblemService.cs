﻿using Suls.Data;
using Suls.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Services
{
    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, ushort points)
        {
            var problem = new Problem { Name = name, Points = points };
            this.db.Problems.Add(problem);
            db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new HomePageProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            }).ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            var problem = this.db.Problems.FirstOrDefault(x => x.Id == id);
            return problem?.Name;
        }

        public ProblemViewModel GetById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        CreatedOn = s.CreatedOn,
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                }).FirstOrDefault();
        }
    }
}
