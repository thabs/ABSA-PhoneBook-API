using ABSA.PhoneBookAPI.Models.Request;
using ABSA.PhoneBookAPI.Validators;
using Xunit;

namespace ABSA.PhoneBookAPI.Test.Validators
{
    /// <summary>
    ///     Provides tests for <see cref="ContactRequestValidator" />.
    /// </summary>
    public class ContactRequestValidatorTest
    {
        /// <summary>
        ///     A <see cref="ContactRequestValidator"/> representing an instance of the class being tested.
        /// </summary>
        private readonly ContactRequestValidator _instance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactRequestValidatorTest"/> class.
        /// </summary>
        public ContactRequestValidatorTest()
        {
            _instance = new ContactRequestValidator();
        }

        // <summary>
        ///     Tests that <see cref="ContactRequestValidator.Validate()"/> produces an appropriate validation result.
        /// </summary>
        /// <param name="sourceIsValid">
        ///     A <see cref="bool" /> representing the test data result.
        /// </param>
        /// <param name="sourceModel">
        ///     A <see cref="ContactRequest"/> representing the test data.
        /// </param>
        [Theory]
        [ClassData(typeof(ContactRequestValidatorTestData))]
        public void ValidateReturnsValidationResult(bool sourceIsValid, ContactRequest sourceModel)
        {
            var actual = _instance.Validate(sourceModel);
            Assert.Equal(sourceIsValid, actual.IsValid);
        }
    }
}