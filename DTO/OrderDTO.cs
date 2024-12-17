namespace VinylSeliing.DTO
{
    public class OrderDTO
    {
        public uint OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string VinylTitle { get; set; }
        public string VinylAuthor { get; set; }
        public decimal VinylPrice { get; set; }
        public string UserName { get; set; }
    }
}