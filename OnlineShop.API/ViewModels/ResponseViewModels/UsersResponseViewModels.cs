namespace OnlineShop.API.ViewModels.ResponseViewModels
{
    public class UsersResponseViewModels
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public OrdersResponseViewModels Orders { get; set; }
    }
}
