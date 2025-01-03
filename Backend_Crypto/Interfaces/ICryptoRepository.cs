using Backend_Crypto.Data;
using Backend_Crypto.Models;

namespace Backend_Crypto.Interfaces
{
    public interface ICryptoRepository
    {
        ICollection<Crypto> GetCrypto();
        Crypto? GetCrypto(int idCrypto);
        bool CryptoExist(int idCrypto);
        decimal GetPrixCrypto(int idCrypto);
        bool CreateCrypto(CryptoCreateData crypto);
        Crypto? findByName(string name);
        Crypto? findBySymbole(string symbole);
        bool updateCrypto(Crypto crypto);
        bool removeCrypto(Crypto crypto);
        bool Save();
    }
}
