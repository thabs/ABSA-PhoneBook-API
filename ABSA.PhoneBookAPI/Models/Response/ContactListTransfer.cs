using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Models.Response
{
    /// <summary>
    ///     Represents the phone book contacts transfer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ContactListTransfer
    {
        /// <summary>
        ///     Gets or sets a <see cref="List{Contact}" /> representing the phone book contacts.
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}