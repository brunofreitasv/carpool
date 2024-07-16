using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carpool.Data.Entities
{
    [Table(nameof(Account))]
    public class Account
    {
        [Key, Required]
        public virtual Guid AccountId { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Email { get; set; }
        [Required]
        public virtual string Cpf { get; set; }
        public virtual string CarPlate { get; set; }
        [Required]
        public virtual bool IsPassenger { get; set; }
        [Required]
        public virtual bool IsDriver { get; set; }
    }
}
