using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Data.Entities
{
    public class Purchase
    {
        [Key]
        [ForeignKey(nameof(ArtPiece))]
        public Guid ArtPieceId { get; set; }

        [Required]
        [ForeignKey(nameof(Visitor))]
        public Guid VisitorId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double FinalPrice { get; set; }
        public ArtPiece ArtPiece { get; set; }
        public Visitor Visitor { get; set; } 

    }
}
