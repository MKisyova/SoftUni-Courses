﻿using Suls.Data;
using System;
using System.Linq;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            int problemPoints = this.db.Problems.Where(x => x.Id == problemId)
                .Select(x => x.Points).FirstOrDefault();

            var submission = new Submission
            {
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                AchievedResult = (ushort)this.random.Next(0, problemPoints + 1),
                CreatedOn = DateTime.UtcNow,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
