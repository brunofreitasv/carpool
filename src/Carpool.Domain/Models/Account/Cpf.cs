using Carpool.Domain.Core;
using Carpool.Domain.Core.Models;
using System.Text.RegularExpressions;

namespace Carpool.Domain.Models.Account
{
    public class Cpf : IValueObject
    {
        private const int CPF_LENGTH = 11;
        private const int FACTOR_FIRST_DIGIT = 10;
        private const int FACTOR_SECOND_DIGIT = 11;

        private readonly string value;

        public Cpf(string rawCpf)
        {
            if (!ValidateCpf(rawCpf))
                throw new DomainException("Invalid cpf");

            value = rawCpf;
        }

        public string Value => value;

        private static bool ValidateCpf(string rawCpf)
        {
            if (string.IsNullOrEmpty(rawCpf))
            {
                return false;
            }

            string cpf = RemoveNonDigits(rawCpf);

            if (cpf.Length != CPF_LENGTH)
            {
                return false;
            }

            if (AllDigitsTheSame(cpf))
            {
                return false;
            }

            int digit1 = CalculateDigit(cpf, FACTOR_FIRST_DIGIT);
            int digit2 = CalculateDigit(cpf, FACTOR_SECOND_DIGIT);

            string actualDigit = ExtractActualDigit(cpf);
            return actualDigit == $"{digit1}{digit2}";
        }

        private static string RemoveNonDigits(string cpf)
        {
            return Regex.Replace(cpf, @"\D", "");
        }

        private static bool AllDigitsTheSame(string cpf)
        {
            char firstDigit = cpf[0];
            return cpf.All(digit => digit == firstDigit);
        }

        private static int CalculateDigit(string cpf, int factor)
        {
            int total = 0;
            foreach (char digit in cpf.ToCharArray())
            {
                if (factor > 1)
                {
                    int digitint = int.Parse(digit.ToString());
                    total += digitint * factor--;
                }
            }

            int remainder = total % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }

        private static string ExtractActualDigit(string cpf)
        {
            return cpf.Substring(9);
        }
    }
}