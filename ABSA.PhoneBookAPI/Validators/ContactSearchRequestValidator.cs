using ABSA.PhoneBookAPI.Models;
using FluentValidation;

namespace ABSA.PhoneBookAPI.Validators
{
    public class ContactSearchRequestValidator : AbstractValidator<ContactSearchRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactSearchRequestValidator"/> class.
        /// </summary>
        public ContactSearchRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty(); 
        }
    }
}