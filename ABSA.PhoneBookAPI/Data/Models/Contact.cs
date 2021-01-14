using System;
using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Data.Models
{
    /// <summary>
    ///     Represents the contact.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Contact
    {   
        /// <summary>
        ///     Gets or sets a <see cref="int"/> representing primary key.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the contact's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the contact's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the contact's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the contact's email address.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the contact's mobile number.
        /// </summary>
        public string MobileNumber { get; set; }
        
        /// <summary>
        ///     Get or set a <see cref="DateTime"/> representing the date and time logged for when the contact was created.
        /// </summary>
        public DateTime DateTimeCreated { get; set; }
    }
}