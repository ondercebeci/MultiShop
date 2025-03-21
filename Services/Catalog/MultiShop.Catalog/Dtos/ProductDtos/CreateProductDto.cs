namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal PoductPrice { get; set; }
        public string PoductImageUrl { get; set; }
        public string PoductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}
