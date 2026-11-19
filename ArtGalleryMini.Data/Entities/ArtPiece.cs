using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data.Enums;

namespace ArtGalleryMini.Data.Entities
{
    public class ArtPiece
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
        public string Description { get; set; }

        public Author Author { get; set; }

        public ArtType ArtType { get; set; }

        public DateOnly CreationDate { get; set; }

        public  Guid? PurchaseId{ get; set; }

        public Purchase? Purchase { get; set; }
        
    }
}
