using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Services.DTOs.Purchases
{
    public class PurchaseCreateDto
    {
        [Required]
        public Guid ArtPieceId { get; set; }

        [Required]
        public Guid VisitorId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double FinalPrice { get; set; }
    }
}
