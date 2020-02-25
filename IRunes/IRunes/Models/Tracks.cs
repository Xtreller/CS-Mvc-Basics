using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IRunes.Models
{
   public class Tracks
    {
        public Tracks()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        public string Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string AlbumId { get; set; }
        public Albums Album { get; set; }
    }
}
