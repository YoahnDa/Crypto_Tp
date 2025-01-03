using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Data
{
    public class CryptoCreateData
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le crypto a besoin de symbole")]
        public string symbole { get; set; } = string.Empty;

        [Required(ErrorMessage="Prix initial invalide")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix initial doit être supérieur à 0.")]
        public double prixInitiale { get; set; }  

    }
}
