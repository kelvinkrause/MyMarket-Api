namespace MyMarket.Communication.Response
{
    public class ResponseRegisteredProductJson
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public string Category { get; set; }
        public string Barcode { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
