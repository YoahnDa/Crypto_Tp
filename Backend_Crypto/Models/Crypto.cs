using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Models
{
    public class Crypto
    {
        public int IdCrypto { get; set; }

        //[Required(ErrorMessage = "Le symbole est obligatoire")]
        public string Symbole { get; set; } = string.Empty;

        //[Required(ErrorMessage ="Le nom est obligatoire")]
        public string Nom { get; set; } = string.Empty;
        public ICollection<HistoriquePrix> Historiques { get; set; } = new List<HistoriquePrix>();
        public ICollection<StockPortefeuille> StockClient { get; set; } = new List<StockPortefeuille>();

    }
}
