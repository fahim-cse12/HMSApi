using HMSApi.Dto;
using HMSApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(ILogger<AccountController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("RegisterUser")]
        public async Task<object> RegisterUser([FromBody] RegisterDto model)
        {
            try
            {
                var user = new AppUser() { FullName = model.FullName, Email = model.Email, UserName = model.Email, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return await Task.FromResult("User has been registered successfully");
                }
                return await Task.FromResult(string.Join(",", result.Errors.Select(x => x.Description).ToArray()));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }

        }

        [HttpGet("GetAllUser")]
        public async Task<object> GetAllUser()
        {
            try
            {
                var users = _userManager.Users.Select(x => new UserDto(x.FullName, x.Email, x.UserName, x.DateCreated));

                return await Task.FromResult(users);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.email, model.password, false, false);
                    if (result.Succeeded) 
                    {
                        return await Task.FromResult("Login Successfully");
                    }
                }

                return await Task.FromResult("Invalid Email or Password");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }

        }

    }
}
