using IRunes.Services;
using IRunes.ViewModels.Albums;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
        private IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumService)
        {
            this.albumsService = albumService;
        }

        public HttpResponse All()
        {
            var ViewModel = new AllAlbumsViewModel
            {
                Albums = this.albumsService.GetAll()
            };
            return this.View(ViewModel);
        }
        
        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel input)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name should be between 4 and 20 symbols.");
            }
            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Error("Cover is empty!");
            }
            this.albumsService.Create(input.Name, input.Cover);
            return this.Redirect("/Albums/All");
        }
        public HttpResponse Details(string id)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = this.albumsService.GetDetails(id);

            return this.View(viewModel);
        }

    }
}
