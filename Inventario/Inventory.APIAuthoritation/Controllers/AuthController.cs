using Inventory.Persistence.Interfaces;
using Inventory.DTOs.Auth;
using Inventory.Entities;

namespace Inventory.APIAuthoritation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        
    }
}