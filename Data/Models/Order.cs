namespace VinylSeliing.Data.Models
{
    public class Order
    {
        public uint Id { get; set; }
        public DateTime OrderDate { get; set; }
        public uint VinylId { get; set; }
        public Vinyl Vinyl { get; set; }
        public uint UserId { get; set; }
        public User User { get; set; }
        public Order()
        {
            OrderDate = DateTime.UtcNow;
        }
        
    }
    
}

