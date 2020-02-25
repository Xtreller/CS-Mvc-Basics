using IRunes.Models;
using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string albumId,string name, string link, decimal price)
        {
            var track = new Tracks
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price
            };
            this.db.Tracks.Add(track);
            var allTracksPricesSum = this.db.Tracks
                .Where(x => x.AlbumId == albumId)
                .Sum(x => x.Price) + price;
               var album = this.db.Albums.Find(albumId);
            album.Price = allTracksPricesSum * 0.87m;
            this.db.SaveChanges();
        }

        public TrackDetailsViewModel GetDetails(string id)
        {
            var track = this.db.Tracks
                .Where(t => t.Id == id)
                .Select(t => new TrackDetailsViewModel
                {
                    Name = t.Name,
                    Link =t.Link,
                    Price = t.Price,
                    AlbumId = t.AlbumId
                }).FirstOrDefault();
            return track;
        }
    }
}
