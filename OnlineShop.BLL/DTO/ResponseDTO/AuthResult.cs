using System.Collections.Generic;

namespace OnlineShop.BLL.DTO.ResponseDTO
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
