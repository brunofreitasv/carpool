namespace Carpool.Domain.Core
{
    public class DomainException : Exception
    {
        public DomainException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
