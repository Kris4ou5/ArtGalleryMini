using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Data.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public List<ArtPiece> ArtPieces { get; set; } = new List<ArtPiece>();
    }
}
