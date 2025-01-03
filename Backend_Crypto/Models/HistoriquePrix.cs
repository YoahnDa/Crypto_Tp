using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Models
{
    public class HistoriquePrix
    {
        public int IdHistorique { get; set; }

        [Required(ErrorMessage ="Prix invalide")]
        public double PrixCrypto { get; set; }

        [Required]
        public DateTime DateChange { get; set; } = DateTime.UtcNow;
        public int idCrypto { get; set; }
        public Crypto CryptoChange { get; set; } = new Crypto();
    }
}
