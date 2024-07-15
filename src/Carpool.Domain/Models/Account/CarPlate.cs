using Carpool.Domain.Core;
using Carpool.Domain.Core.Models;
using System.Text.RegularExpressions;

namespace Carpool.Domain.Models.Account
{
    public class CarPlate : IValueObject
    {
        private readonly string value;

        public CarPlate(string carPlate)
        {
            if (!string.IsNullOrEmpty(carPlate) && !ValidateCarPlate(carPlate))
                throw new DomainException("Invalid car plate");

            value = carPlate;
        }

        public string Value => value;

        private bool ValidateCarPlate(string carPlate) => !string.IsNullOrEmpty(carPlate) && Regex.IsMatch(carPlate, @"^[A-Z]{3}[0-9]{4}$");
    }
}