using Carpool.Domain.Core;
using Carpool.Domain.Core.Models;
using System.Text.RegularExpressions;

namespace Carpool.Domain.Models.Account
{
    public sealed class Email : IValueObject
    {
        private readonly string value;

        public Email(string email)
        {
            if (!ValidateEmail(email))
                throw new DomainException("Invalid email");

            value = email;
        }

        public string Value => value;

        private bool ValidateEmail(string email) => !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^(.+)@(.+)$");
    }
}