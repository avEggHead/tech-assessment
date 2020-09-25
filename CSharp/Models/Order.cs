namespace CSharp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public OrderStatus Status { get; set; }

        public enum OrderStatus
        {
            Inactive = 0,
            Active = 1,
        }
    }
}
