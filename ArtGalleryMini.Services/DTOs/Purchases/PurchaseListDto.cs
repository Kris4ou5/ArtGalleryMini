using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Services.DTOs.Purchases
{
    public class PurchaseListDto
    {
        public Guid ArtPieceId { get; set; }
        public Guid VisitorId { get; set; }

        public string ArtPieceTitle { get; set; }
        public string VisitorName { get; set; }

        public DateTime PurchaseDate { get; set; }
        public double FinalPrice { get; set; }
    }
}
