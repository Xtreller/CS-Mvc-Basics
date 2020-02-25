using IRunes.Models;
using IRunes.ViewModels.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, string cover)
        {

            var album = new Albums
            {
                Name = name,
                Cover = cover,
                Price = 0.0M
            };
            this.db.Albums.Add(album);
            this.db.SaveChanges();

        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
           var allAlbums = this.db.Albums.Select(x => new AlbumInfoViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return allAlbums;
        }

        public AlbumDetailsViewModel GetDetails(string Id)
        {
            var album = this.db.Albums
                 .Where(a => a.Id == Id)
                 .Select(a => new AlbumDetailsViewModel
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Cover = a.Cover,
                     Price = a.Price,
                     Tracks = a.Tracks.Select(t => new TrackInfoViewModel
                     {
                         Id = t.Id,
                         Name = t.Name
                     })
                 }).FirstOrDefault();
            return album;
        }





        }
}
