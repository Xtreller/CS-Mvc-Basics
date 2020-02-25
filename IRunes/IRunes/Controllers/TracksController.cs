using IRunes.Services;
using IRunes.ViewModels.Tracks;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private ITracksService trackService;

        public TracksController(ITracksService trackService)
        {
            this.trackService = trackService;
        }
        public HttpResponse Create(string albumId)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var ViewModel = new CreateViewModel { AlbumId = albumId };
            return this.View(ViewModel);
        }
        [HttpPost]
        public HttpResponse Create(TrackCreateInputModel input)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Track Name should be between 4 and 20 symbols!");
            }
            if (input.Price < 0)
            {
                return this.Error("Price should be positivie number!");
            }
            this.trackService.Create(input.AlbumId, input.Name, input.Link, input.Price);
            return this.Redirect("/Albums/Details?id=" + input.AlbumId);
        }

        public HttpResponse Details(string trackId)
        {
            if (!IsUserLoggedIn())
            {
                return this.Error("/Users/Login");
            }
            var viewModel = this.trackService.GetDetails(trackId);

            return this.View(viewModel);
        }
    }
}
