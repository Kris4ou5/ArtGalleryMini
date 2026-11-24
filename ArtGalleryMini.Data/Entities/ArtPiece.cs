using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data.Enums;

namespace ArtGalleryMini.Data.Entities
{
    public class ArtPiece
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;


        [Required]
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public Author Author { get; set; }

        [Required]
        [EnumDataType(typeof(ArtType))]
        public ArtType ArtType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly CreationDate { get; set; }

        public Purchase? Purchase { get; set; }
        
    }
}
