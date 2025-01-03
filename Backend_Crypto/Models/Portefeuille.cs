using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Models
{
    public class Portefeuille
    {
        public int IdPortefeuille { get; set; }
        public int IdUser { get; set; }

        [DefaultValue(0)]
        public double Fond { get; set; } = 0;
        public ICollection<Transaction> Transac { get; set; } = new List<Transaction>();
        public ICollection<StockPortefeuille> Stock { get; set; } = new List<StockPortefeuille>();
    }
}
