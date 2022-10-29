using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemService problemService, ISubmissionsService submissionsService)
        {
            this.problemService = problemService;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemService.GetNameById(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters.");
            }
            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);

            return this.Redirect("/");
        }
    }
}
