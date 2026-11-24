using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Data.Entities
{
    public class Visitor
    {
        [Key]
        public Guid Id{ get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName{ get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email{ get; set; }

        public List<Purchase> PurchaseList { get; set; } = new List<Purchase>();
    }
}
