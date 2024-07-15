using Carpool.Application.Abstractions.Commands.Account;
using Carpool.Application.Abstractions.Queries;
using Carpool.Application.Abstractions.Repositories;
using Carpool.Application.Commands.Account;
using Carpool.Application.DTOs.Account.Inputs;
using Carpool.Data.InMemory.Queries;
using Carpool.Data.InMemory.Repositories;
using Carpool.Domain.Core;
using Carpool.Gateway.Mailer;

namespace Carpool.Integration.Tests
{
    [TestFixture]
    public class SignupTests
    {
        private IAccountRepository accountRepository;
        private ISignupCommand signupCommand;
        private IAccountQueries accountQueries;

        [SetUp]
        public void Setup()
        {
            var context = new Data.InMemory.Context();
            accountRepository = new AccountInMemoryRepository(context);
            signupCommand = new SignupCommand(accountRepository, new MailerGatewayFake());
            accountQueries = new AccountInMemoryQueries(context);
        }

        [Test]
        public void SignupAsync_InvalidName_ReturnsInvalidName()
        {
            // Arrange
            var input = new SignupInput { Name = "InvalidName", Email = "test@example.com" };

            // Act
            var ex = Assert.ThrowsAsync<DomainException>(async () => await signupCommand.Execute(input));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid name"));
        }

        [Test]
        public void SignupAsync_InvalidEmail_ReturnsInvalidEmail()
        {
            // Arrange
            var input = new SignupInput { Name = "Valid Name", Email = "invalid-email" };

            // Act
            var ex = Assert.ThrowsAsync<DomainException>(async () => await signupCommand.Execute(input));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid email"));
        }

        [Test]
        public void SignupAsync_InvalidCpf_ReturnsInvalidCpf()
        {
            // Arrange
            var input = new SignupInput { Name = "Valid Name", Email = "test@example.com", Cpf = "123456789" };

            // Act
            var ex = Assert.ThrowsAsync<DomainException>(async () => await signupCommand.Execute(input));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid cpf"));
        }

        [Test]
        public void SignupAsync_InvalidCarPlate_ReturnsInvalidCarPlate()
        {
            // Arrange
            var input = new SignupInput { Name = "Valid Name", Email = "test@example.com", Cpf = "97456321558", IsDriver = true, CarPlate = "123ABC" };

            // Act
            var ex = Assert.ThrowsAsync<DomainException>(async () => await signupCommand.Execute(input));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid car plate"));
        }

        [Test]
        public async Task SignupAsync_Passenger_ReturnsSuccess()
        {
            // Arrange
            var input = new SignupInput
            {
                Name = "Valid Name",
                Email = "test@example.com",
                Cpf = "97456321558",
                IsPassenger = true
            };

            // Act
            var result = await signupCommand.Execute(input);

            // Assert
            Assert.IsNotNull(result.AccountId);

            // Act
            var outputAccout = await accountQueries.GetAccont(result.AccountId);

            // Assert
            Assert.IsNotNull(outputAccout);
            Assert.That(outputAccout.Name, Is.EqualTo(input.Name));
            Assert.That(outputAccout.Email, Is.EqualTo(input.Email));
            Assert.That(outputAccout.Cpf, Is.EqualTo(input.Cpf));
        }

        [Test]
        public async Task SignupAsync_Driver_ReturnsSuccess()
        {
            // Arrange
            var input = new SignupInput
            {
                Name = "Valid Name",
                Email = "test@example.com",
                Cpf = "97456321558",
                CarPlate = "AAA9999",
                IsDriver = true
            };

            // Act
            var result = await signupCommand.Execute(input);

            // Assert
            Assert.IsNotNull(result.AccountId);

            // Act
            var outputAccout = await accountQueries.GetAccont(result.AccountId);

            // Assert
            Assert.IsNotNull(outputAccout);
            Assert.That(outputAccout.Name, Is.EqualTo(input.Name));
            Assert.That(outputAccout.Email, Is.EqualTo(input.Email));
            Assert.That(outputAccout.Cpf, Is.EqualTo(input.Cpf));
            Assert.That(outputAccout.CarPlate, Is.EqualTo(input.CarPlate));
        }

        [Test]
        public async Task SignupAsync_AccountAlreadyExists_ReturnsAlreadyExists()
        {
            // Arrange
            var input = new SignupInput
            {
                Name = "Valid Name",
                Email = "test@example.com",
                Cpf = "97456321558",
                IsPassenger = true
            };

            // Act
            await signupCommand.Execute(input);
            var ex = Assert.ThrowsAsync<Application.ApplicationException>(async () => await signupCommand.Execute(input));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Account already exists"));

        }
    }
}
