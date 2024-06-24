using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.DTO.ResponseDTO
{
    public class OrdersResponseDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<UsersResponseDTO> Users { get; set; }
    }
}
 