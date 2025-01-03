using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Models
{
    public enum TypeTransaction
    {
        Achat = 1,
        Vente = 2,
        Depot = 3,
        Retrait = 4
    }

    public enum Status
    {
        Waiting = 1,
        Valid = 2,
        Annuler = 3
    }
    public class Transaction
    {
        public int IdTransaction { get; set; }

        [Required]
        public TypeTransaction Type { get; set; }

        [Required]
        public Status State { get; set; } = Status.Waiting;
        public DateTime DateTransaction { get; set; } = DateTime.UtcNow;
        public int IdPortefeuille { get; set; }
        public Ordre? Ordre { get; set; }
        public Portefeuille PortefeuilleOwner { get; set; } = new Portefeuille();
        public ICollection<AuthToken> TokenAuth { get; set; } = new List<AuthToken>();
    }
}
