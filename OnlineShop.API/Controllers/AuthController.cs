using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.DTO.RequestDTO.UsersRequestDTO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO model)
        {
            var result = await _authService.RegisterAsync(model);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
        {
            var result = await _authService.LoginAsync(model);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Hello, Minimal API with JWT Authentication!");
        }

        [HttpGet("admin")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminOnly()
        {
            return Ok("Hello, Admin!");
        }

        [HttpGet("user")]
        [Authorize(Policy = "UserOnly")]
        public IActionResult UserOnly()
        {
            return Ok("Hello, User!");
        }

        [HttpGet("unprotected")]
        [AllowAnonymous]
        public async Task<IActionResult> Unprotected()
        {
            // Пример отправки запроса к защищенному эндпоинту с добавлением JWT из куки в заголовок

            var httpClient = new HttpClient();
            var jwtFromCookie = _httpContextAccessor.HttpContext.Request.Cookies["jwt"];
            if (jwtFromCookie != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtFromCookie);
            }

            // Замените URL на ваш защищенный эндпоинт
            var apiUrl = "http://localhost:5032/api/auth/user"; // Пример URL защищенного эндпоинта

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            else
            {
                return BadRequest("Failed to access protected endpoint.");
            }
        }
    }
}
