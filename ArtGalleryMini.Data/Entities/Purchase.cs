using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Data.Entities
{
    public class Purchase
    {
        public Guid Id { get; set; }

        public Guid ArtPieceId { get; set; }

        public Guid VisitorId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public double FinalPrice { get; set; }
        public ArtPiece ArtPiece { get; set; }
        public Visitor Visitor { get; set; } 

    }
}
