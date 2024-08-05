namespace BGC.Common.Catalog.Models
{
    public class Rating
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Scale { get; set; }
        public decimal Value { get; set; }
    }
}
