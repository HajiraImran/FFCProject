using FFCProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FFCProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // DTO to send user data safely (no password)
        public class UserDto
        {
            public string Email { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Designation { get; set; }
            public string ContactNumber { get; set; }
            public string Address { get; set; }
            public string PostalCode { get; set; }
            public string PermanentAddress { get; set; }
            // add other safe properties as needed
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return NotFound();

            var userDto = new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Designation = user.Designation,
                ContactNumber = user.ContactNumber,
                Address = user.Address,
                PostalCode = user.PostalCode,
                PermanentAddress = user.PermanentAddress
            };

            return Ok(userDto);
        }
    }
}
