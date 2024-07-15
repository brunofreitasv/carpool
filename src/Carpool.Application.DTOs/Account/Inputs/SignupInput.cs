namespace Carpool.Application.DTOs.Account.Inputs
{
    public class SignupInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string CarPlate { get; set; }
        public bool? IsPassenger { get; set; }
        public bool? IsDriver { get; set; }
    }
}
