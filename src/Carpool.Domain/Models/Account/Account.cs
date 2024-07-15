using Carpool.Domain.Core.Models;

namespace Carpool.Domain.Models.Account
{
    public class Account : IAggregateRoot
    {
        public Account(Guid accountId, string name, string email, string cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            Id = accountId;
            Name = new Name(name);
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            CarPlate = new CarPlate(carPlate);
            IsPassenger = isPassenger;
            IsDriver = isDriver;
        }

        public static Account Create(string name, string email, string cpf, string carPlate, bool isPassenger, bool isDriver)
        {
            return new Account(Guid.NewGuid(), name, email, cpf, carPlate, isPassenger, isDriver);
        }

        public Guid Id { get; set; }
	    public Name Name { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }
        public CarPlate CarPlate { get; set; }
        public bool? IsPassenger { get; set; }
        public bool? IsDriver { get; set; }
    }
}
