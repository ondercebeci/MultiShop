using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal PoductPrice { get; set; }
        public string PoductImageUrl { get; set; }
        public string PoductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}
