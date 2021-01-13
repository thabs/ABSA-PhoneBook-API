using ABSA.PhoneBookAPI.Models.Request;
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
            RuleFor(x => x.MobileNumber).NotEmpty().Matches("^[0-9]*$").WithMessage("Must contain only numbers"); 
        }
    }
}