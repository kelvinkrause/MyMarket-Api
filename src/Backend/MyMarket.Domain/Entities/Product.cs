namespace MyMarket.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set;} = string.Empty;

        public decimal Price { get; set; } = 0;
        public int StockQuantity { get; set; } = 0;

        public string Category { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
    }
}
