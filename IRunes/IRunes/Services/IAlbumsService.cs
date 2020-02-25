using IRunes.ViewModels.Albums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services
{
   public interface IAlbumsService
    {
        void Create(string name, string cover);
        IEnumerable<AlbumInfoViewModel> GetAll();

       AlbumDetailsViewModel GetDetails(string Id);
    }
}
