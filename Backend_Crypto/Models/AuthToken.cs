using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Crypto.Models
{
    public class AuthToken
    {
        public int IdToken { get; set; }

        //[Required(ErrorMessage = "Le token est invalide")]
        [Column(TypeName = "TEXT")]
        public string Token { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Date d'expiration obligatoire")]
        public DateTime DateExpiration { get; set; }

        [Required]
        public bool IsUsed { get; set; } = false;
        public int IdTransaction { get; set; }
        public Transaction Transac { get; set; } = new Transaction();
    }
}
