﻿using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var creatorId = this.GetUserId();
            var viewModel = this.commitsService.GetAll(creatorId);
            return this.View(viewModel, "All");
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CommitToRepositoryViewModel
            {
                Id = id,
                Name = this.repositoriesService.GetNameById(id),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateViewModel model)
        {
            if (string.IsNullOrEmpty(model.Description) || (model.Description.Length < 5))
            {
                return this.Error("Description should be at least 5 characters.");
            }
            var creatorId = this.GetUserId();
            this.commitsService.Create(model.Id, creatorId, model.Description);
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.commitsService.Delete(id);
            return this.Redirect("/Commits/All");
        }
    }
}
