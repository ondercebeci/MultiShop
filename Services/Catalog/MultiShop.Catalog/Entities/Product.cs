using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal PoductPrice { get; set; }
        public string  PoductImageUrl { get; set; }
        public string  PoductDescription { get; set; }
        public string  CategoryID { get; set; }
        [BsonIgnore]
        public Category  Category { get; set; }
    }
}

