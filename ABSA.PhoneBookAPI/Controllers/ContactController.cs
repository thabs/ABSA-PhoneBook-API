using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        ///     Gets all contacts.
        /// </summary>
        /// <returns>
        ///     A <see cref="List{Contact}" /> representing the list of contacts.
        /// </returns>
        [HttpGet("all")]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return await _contactService.GetAllContactsAsync();
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
                DateTimeCreated =  DateTime.Now
            };

            return await _contactService.AddContactAsync(contact);
        }

        /// <summary>
        ///     Updates a contact.
        /// </summary>
        /// <param name="request">
        ///     A <see cref="ContactRequest" /> representing the request object.
        /// </param>
        /// <returns>
        ///     A <see cref="Contact" /> representing the updated contact.
        /// </returns>
        [HttpPut("update")]
        public async Task<ActionResult<Contact>> UpdateContact([FromQuery] int? id,
            [FromBody] ContactRequest request)
        {
            if(id == null)
            {
                return NotFound();
            }

            var contact = new Contact
            {
                Id = id.GetValueOrDefault(),
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MobileNumber = request.MobileNumber,
                DateTimeCreated =  DateTime.Now
            };

            return await _contactService.UpdateContactAsync(contact);
        }

        /// <summary>
        ///     Creates a new contact.
        /// </summary>
        /// <param name="id">
        ///     A <see cref="int" /> representing the request id.
        /// </param>
        /// <returns>
        ///     A <see cref="Contact" /> representing the deleted contact.
        /// </returns>
        [HttpPost("delete")]
        public async Task<ActionResult<Contact>> DeleteContact(
            [FromQuery] int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            return await _contactService.DeleteContactByIdAsync(id.GetValueOrDefault());
        }
    }
}
