using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerContactForm.Data;

namespace ServerContactForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactData>>> GetContactData()
        {
            return Ok(await _context.ContactData.Include(p => p.Messages).ToListAsync());
        }

        [HttpPost("{themesMessagesDataId}")]
        public async Task<ActionResult<List<ContactData>>> CreateContactData(ContactData cdata, int themesMessagesDataId)
        {
            bool key = false;
            var contactsList = _context.ContactData.Include(p => p.Messages).ToList();
            if (contactsList == null)
            {
                return BadRequest("Нет данных");
            }
            else
            {
                foreach (var item in contactsList)
                {
                    if (item.Phone == cdata.Phone && item.Email == cdata.Email)
                    {
                        MessagesData message = new()
                        {
                            Text = cdata.Messages.Last().Text,
                            ContactDataId = item.Id,
                            ThemesMessagesDataId = themesMessagesDataId
                        };
                        _context.MessagesData.Add(message);
                        key = true;
                        break;
                    }
                }

                if (!key)
                {
                    _context.ContactData.Add(cdata);
                }
                await _context.SaveChangesAsync();
                return Ok(await _context.ContactData.Include(p => p.Messages).ToListAsync());
            }
        }
    }
}