namespace ABSA.PhoneBookAPI.Models
{
    /// <summary>
    ///     Represents one the contact details.
    /// </summary>
    public class Contact
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