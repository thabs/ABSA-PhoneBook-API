using ABSA.PhoneBookAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Test.Validators
{
    [ExcludeFromCodeCoverage]
    public class ContactSearchRequestValidatorTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public IEnumerator<object[]> GetEnumerator()
        {
            // Valid contact search request
            yield return new object[]
            {
                true,
                new ContactSearchRequest
                {
                    Email = "john.doe@email.com"
                },
            };

            // No parameters in the request
            yield return new object[]
            {
                false,
                new ContactSearchRequest()
            };

            // Invalid Email address
            yield return new object[]
            {
                false,
                new ContactSearchRequest
                {
                    Email = "invalid email"
                }
            };
        }
    }
}