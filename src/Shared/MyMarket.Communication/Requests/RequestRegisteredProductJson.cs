namespace MyMarket.Communication.Requests
{
    public class RequestRegisteredProductJson
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public string Category { get; set; }
        public string Barcode { get; set; }

    }
}
