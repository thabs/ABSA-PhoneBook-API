using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ABSA.PhoneBookAPI.Models;
using ABSA.PhoneBookAPI.Data.Models;
using ABSA.PhoneBookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Contact>))]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _contactService.GetAllContactsAsync();
            return Ok(result);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        public async Task<IActionResult> CreateContact(
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

            var result = await _contactService.AddContactAsync(contact);
            return Ok(result);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        public async Task<IActionResult> UpdateContact([FromQuery] int? id,
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

            var result = await _contactService.UpdateContactAsync(contact);
            return Ok(result);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        public async Task<IActionResult> DeleteContact(
            [FromQuery] int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var result = await _contactService.DeleteContactByIdAsync(id.GetValueOrDefault());
            return Ok(result);
        }
    }
}
