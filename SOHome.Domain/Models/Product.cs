namespace SOHome.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public int? Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
