using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryMini.Data.Entities
{
    public class Visitor
    {
        public Guid Id{ get; set; }

        public string FirstName{ get; set; }

        public string LastName { get; set; }

        public string Email{ get; set; }

        public List<Purchase> PurchaseList { get; set; } = new List<Purchase>();
    }
}
