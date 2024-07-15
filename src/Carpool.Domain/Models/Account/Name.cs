using Carpool.Domain.Core;
using Carpool.Domain.Core.Models;

namespace Carpool.Domain.Models.Account
{
    public class Name : IValueObject
    {
        private readonly string value;

        public Name(string name)
        {
            if (!ValidateName(name))
                throw new DomainException("Invalid name");

            value = name;
        }

        public string Value => value;

        private bool ValidateName(string name) => !string.IsNullOrEmpty(name) && name.Split(' ').Length == 2;
    }
}