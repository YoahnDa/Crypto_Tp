using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Dto
{
    public class CryptoUpdateDto
    {
        public int IdCrypto { get; set; }

        [Required(ErrorMessage = "Le symbole est obligatoire")]
        public string Symbole { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; } = string.Empty;
    }
}
