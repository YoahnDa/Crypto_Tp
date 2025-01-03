using System.ComponentModel;

namespace Backend_Crypto.Models
{
    public class StockPortefeuille
    {
        public Portefeuille PorteFeuilleOwn { get; set; } = new Portefeuille();
        public int IdPorteFeuille { get; set; }
        public int IdCrypto { get; set; }
        public Crypto CryptoIn { get; set; } = new Crypto();

        [DefaultValue(0)]
        public double Stock { get; set; } = 0;
    }
}
