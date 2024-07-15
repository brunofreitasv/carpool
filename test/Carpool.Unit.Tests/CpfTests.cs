using Carpool.Domain.Core;
using Carpool.Domain.Models.Account;

namespace Carpool.Unit.Tests
{
    [TestFixture]
    public class CpfTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("97456321558")]
        [TestCase("71428793860")]
        [TestCase("87748248800")]
        public void ShouldValidateValidCpf(string cpf)
        {
            Assert.DoesNotThrow(() => new Cpf(cpf));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("123456")]
        [TestCase("12345678901234567890")]
        [TestCase("11111111111")]
        public void ShouldValidateInvalidCpf(string cpf)
        {
            var ex = Assert.Throws<DomainException>(() => new Cpf(cpf));
            Assert.That(ex.Message, Is.EqualTo("Invalid cpf"));
        }
    }
}
