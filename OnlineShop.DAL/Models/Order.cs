public class Order
{
    public int OrderId { get; set; }
    public string Status { get; set; } // Pending, Completed, Cancelled
    public int UserId { get; set; }
    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
