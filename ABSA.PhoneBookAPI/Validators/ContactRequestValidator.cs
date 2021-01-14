using ABSA.PhoneBookAPI.Models;
using FluentValidation;

namespace ABSA.PhoneBookAPI.Validators
{
    public class ContactRequestValidator : AbstractValidator<ContactRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactRequestValidator"/> class.
        /// </summary>
        public ContactRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.MobileNumber).NotEmpty().Matches(@"^((?:\+27|27)|0)(\d{2})-?(\d{3})-?(\d{4})$").WithMessage("Must contain only numbers"); 
        }
    }
}