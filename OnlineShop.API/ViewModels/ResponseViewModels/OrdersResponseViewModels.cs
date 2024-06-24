namespace OnlineShop.API.ViewModels.ResponseViewModels
{
    public class OrdersResponseViewModels
    {
        public int Id { get; set; }
        public string Status { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<UsersResponseViewModels> Users { get; set; } 
    }
}
