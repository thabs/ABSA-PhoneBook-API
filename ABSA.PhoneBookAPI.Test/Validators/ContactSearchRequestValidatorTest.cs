using ABSA.PhoneBookAPI.Models;
using ABSA.PhoneBookAPI.Validators;
using Xunit;

namespace ABSA.PhoneBookAPI.Test.Validators
{
    /// <summary>
    ///     Provides tests for <see cref="ContactSearchRequestValidator"/>.
    /// </summary>
    public class ContactSearchRequestValidatorTest
    {
        /// <summary>
        ///     A <see cref="ContactSearchRequestValidator"/> representing an instance of the class being tested.
        /// </summary>
        private readonly ContactSearchRequestValidator _instance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactSearchRequestValidatorTest"/> class.
        /// </summary>
        public ContactSearchRequestValidatorTest()
        {
            _instance = new ContactSearchRequestValidator();
        }

        // <summary>
        ///     Tests that <see cref="ContactSearchRequestValidator.Validate()"/> produces an appropriate validation result.
        /// </summary>
        /// <param name="sourceIsValid">
        ///     A <see cref="bool" /> representing the test data result.
        /// </param>
        /// <param name="sourceModel">
        ///     A <see cref="ContactSearchRequest"/> representing the test data.
        /// </param>
        [Theory]
         [ClassData(typeof(ContactSearchRequestValidatorTestData))]
        public void ValidateReturnsValidationResult(bool sourceIsValid, ContactSearchRequest sourceModel)
        {
            var actual = _instance.Validate(sourceModel);
            Assert.Equal(sourceIsValid, actual.IsValid);
        }
    }
}