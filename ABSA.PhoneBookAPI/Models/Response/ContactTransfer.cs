using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Models.Response
{
    /// <summary>
    ///     Represents the contact transfer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactTransfer
    {
        /// <summary>
        ///     Gets or sets a <see cref="Contact" /> representing the phone book contact.
        /// </summary>
        public Contact Contact { get; set;}
    }
}