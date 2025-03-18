using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {

        private readonly WebAppDB _context;

        // binding
        public ClaimsController(WebAppDB dbcontext)
        {
            _context = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return "> Get method called";
        }

    }
}
