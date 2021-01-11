using ABSA.PhoneBookAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ABSA.PhoneBookAPI.Test.Validators
{
    [ExcludeFromCodeCoverage]
    public class ContactRequestValidatorTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public IEnumerator<object[]> GetEnumerator()
        {
            // Valid contact request
            yield return new object[]
            {
                true,
                new ContactRequest
                {
                    Title = "Dr",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    MobileNumber = "0721234567"
                },
            };

            // No parameters in the request
            yield return new object[]
            {
                false,
                new ContactRequest()
            };

            // Invalid Email address
            yield return new object[]
            {
                false,
                new ContactRequest
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "invalid email",
                    MobileNumber = "0721234567"
                }
            };

            // Invalid Mobile number
            yield return new object[]
            {
                false,
                new ContactRequest
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    MobileNumber = "invalid mobile number"
                }
            };
        }
    }
}