using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Models.Request
{
    /// <summary>
    ///     Represents the contact search request.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactSearchRequest
    {
        /// <summary>
        ///     Gets or sets a <see cref="string" /> representing the email address.
        /// </summary>
        public string Email { get; set; }
    }
}