using Backend_Crypto.Models;
using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Dto
{
    public class CryptoDto
    {
        public int IdCrypto { get; set; }

        [Required(ErrorMessage = "Le symbole est obligatoire")]
        public string Symbole { get; set; } = string.Empty;

        [Required(ErrorMessage ="Le nom est obligatoire")]
        public string Nom { get; set; } = string.Empty;
        public ICollection<HistoriqueDto> Historiques { get; set; } = new List<HistoriqueDto>();
    }
}
