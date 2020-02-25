using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IRunes.Models
{
    public class Albums
    {
        public Albums()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tracks = new HashSet<Tracks>();
        }

        public string Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cover { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<Tracks> Tracks { get; set; }

    }
}
