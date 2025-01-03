using Backend_Crypto.Data;
using Backend_Crypto.Interfaces;
using Backend_Crypto.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Crypto.Repository
{
    public class CryptoRepository : ICryptoRepository
    {
        private readonly DataContext _context;
        public CryptoRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Crypto> GetCrypto()
        {
            var cryptos = _context.Cryptos
                          .Include(c => c.Historiques.OrderByDescending(h => h.DateChange)) 
                          .OrderByDescending(p => p.IdCrypto)
                          .ToList();
            return cryptos ?? new List<Crypto>();
        }
        public Crypto? GetCrypto(int idCrypto)
        {
            return _context.Cryptos.Include(c => c.Historiques.OrderByDescending( h=>h.DateChange))
                .FirstOrDefault(c => c.IdCrypto == idCrypto);
        }
        public bool CryptoExist(int idCrypto)
        {
            return _context.Cryptos.Any(p => p.IdCrypto == idCrypto);
        }

        public decimal GetPrixCrypto(int idCrypto)
        {
            return 0;
        }

        public bool CreateCrypto(CryptoCreateData crypto)
        {
            var newCrypto = new Crypto()
            {
                Nom = crypto.name,
                Symbole = crypto.symbole,
            };

            var prixInitiale = new HistoriquePrix()
            {
                CryptoChange = newCrypto,
                PrixCrypto = crypto.prixInitiale
            };

            _context.Add(newCrypto);
            _context.Add(prixInitiale);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Crypto? findByName(string name)
        {
            return _context.Cryptos.Include(c => c.Historiques.OrderByDescending(h => h.DateChange))
                            .FirstOrDefault(c => c.Nom == name);
        }

        public Crypto? findBySymbole(string symbole)
        {
            return _context.Cryptos.Include(c => c.Historiques.OrderByDescending(h => h.DateChange))
                .FirstOrDefault(c => c.Symbole == symbole);
        }

        public bool updateCrypto(Crypto crypto)
        {
            _context.Update(crypto);
            return Save();
        }

        public bool removeCrypto(Crypto crypto)
        {
            _context.Remove(crypto);
            return Save();
        }
    }
}
