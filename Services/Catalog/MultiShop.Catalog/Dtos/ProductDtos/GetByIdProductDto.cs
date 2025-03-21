namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal PoductPrice { get; set; }
        public string PoductImageUrl { get; set; }
        public string PoductDescription { get; set; }
        public string CategoryID { get; set; }
    }
}
