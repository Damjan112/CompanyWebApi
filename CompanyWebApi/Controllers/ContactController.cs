using CompanyWebApi.Models;
using CompanyWebApi.Models.Dto;
using CompanyWebApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
       

        [HttpGet("contactsWithCompanyAndCountry")]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContacts();
            return Ok(contacts);
        }
        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> GetAllContactsWithIdAndName()
        {
            var contacts = await _contactService.GetAllContactsWithIdAndName();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            var contact = await _contactService.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact([FromBody] Contact contact)
        {
            var createdContact = await _contactService.CreateContact(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.ContactId }, createdContact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, [FromBody] Contact contact)
        {
            var updatedContact = await _contactService.UpdateContact(id, contact);

            if (updatedContact == null)
            {
                return NotFound();
            }

            return Ok(updatedContact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContact(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("filter")]
        public async Task<ActionResult<List<Contact>>> FilterContacts(int? companyId, int? countryId)
        {
            var contacts = await _contactService.FilterContacts(companyId, countryId);
            return Ok(contacts);
        }
    }
}
