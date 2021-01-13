using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using ABSA.PhoneBookAPI.Models;
using ABSA.PhoneBookAPI.Data.Models;
using ABSA.PhoneBookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABSA.PhoneBookAPI.Controllers
{
    /// <summary>
    ///     Provides a controller for managing contacts.
    /// </summary>
    [Route("contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        ///     Creates a new contact.
        /// </summary>
        /// <param name="request">
        ///     A <see cref="ContactRequest" /> representing the request object.
        /// </param>
        /// <returns>
        ///     A <see cref="Contact" /> representing the new created contact.
        /// </returns>
        [HttpPost("create")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        public async Task<ActionResult<Contact>> CreateContact(
            [FromBody] ContactRequest request)
        {
            var contact = new Contact
            {
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                DateTimeCreated =  new DateTime()
            };

            return await _contactService.AddContactAsync(contact);
        }
    }
}
