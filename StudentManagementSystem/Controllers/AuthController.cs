using BLL.IService;
using DAL.Entities;
using DAL.ModelVM.AuthVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        //[Authorize(Roles ="Teacher")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(registerModel);
            return Ok(result);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var result = await _authService.LoginAsync(loginUser);
            return Ok(result);
        }
    }
}
