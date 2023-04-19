using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerContactForm.Data;

namespace ServerContactForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesMessagesController : ControllerBase
    {
        private readonly DataContext _context;

        public ThemesMessagesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThemesMessagesData>>> GetThemesData()
        {
            return Ok(await _context.ThemeMessagesData.Include(p => p.Messages).ToListAsync());
        }
    }
}
