using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                var viewModelNotLoggedIn = this.repositoriesService.GetAllPublic();
                return this.View(viewModelNotLoggedIn, "All");
            }
            var viewModel = this.repositoriesService.GetAll();
            return this.View(viewModel, "All");
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            bool isPublic = true;

            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Name should be between 3 and 10 characters.");
            }

            if (repositoryType == "Private")
            {
                isPublic = false;
            }
            var ownerId = this.GetUserId();
            this.repositoriesService.Create(ownerId, name, isPublic);
            return this.Redirect("/Repositories/All");
        }
    }
}
