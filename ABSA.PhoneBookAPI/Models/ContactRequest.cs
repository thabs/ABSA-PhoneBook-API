using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Models
{
    /// <summary>
    ///     Represents the contact request.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactRequest
    {
        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the email address.
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        ///     Gets or sets a <see cref="string"/> representing the mobile number.
        /// </summary>
        public string MobileNumber { get; set; }
    }
}