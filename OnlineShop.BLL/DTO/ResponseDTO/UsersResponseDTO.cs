﻿namespace OnlineShop.BLL.DTO.ResponseDTO
{
    public class UsersResponseDTO
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public OrdersResponseDTO Orders { get; set; }
    }
}
 
