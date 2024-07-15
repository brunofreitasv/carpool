using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Carpool.Application.DTOs.Account.Inputs;
using Carpool.Application.DTOs.Account.Outputs;

namespace Carpool.API.Tests
{
    [TestFixture]
    public class AccountTests
    {
        private readonly string _ApiBaseUrl = "http://localhost:41993";
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task SignupAsync_InvalidCpf_ReturnsInvalidCpf()
        {
            var input = new SignupInput { Name = "Valid Name", Email = $"test{Guid.NewGuid()}@example.com", Cpf = "123456789" };
            var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_ApiBaseUrl}/signup", content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.UnprocessableEntity));

            var result = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());

            Assert.That(result, Is.EqualTo("Invalid cpf"));
        }

        [Test]
        public async Task SignupAsync_Passenger_ReturnsSuccess()
        {
            var input = new SignupInput
            {
                Name = "Valid Name",
                Email = $"test{Guid.NewGuid()}@example.com",
                Cpf = "97456321558",
                IsPassenger = true
            };

            var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var signupResponse = await _client.PostAsync($"{_ApiBaseUrl}/signup", content);

            Assert.That(signupResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var accountId = JsonConvert.DeserializeObject<string>(await signupResponse.Content.ReadAsStringAsync());

            Assert.IsNotNull(accountId);

            var getAccountResponse = await _client.GetAsync($"{_ApiBaseUrl}/accounts/{accountId}");

            Assert.That(getAccountResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var outputAccout = JsonConvert.DeserializeObject<AccountResult>(await getAccountResponse.Content.ReadAsStringAsync());

            Assert.IsNotNull(outputAccout);
            Assert.That(outputAccout.Name, Is.EqualTo(input.Name));
            Assert.That(outputAccout.Email, Is.EqualTo(input.Email));
            Assert.That(outputAccout.Cpf, Is.EqualTo(input.Cpf));
        }
    }
}
