using System.ComponentModel.DataAnnotations;

namespace Backend_Crypto.Models
{
    public enum TypeOrdre
    {
        Achat = 1,
        Vente = 2
    }
    public class Ordre
    {
        public int IdOrdre { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Le prix doit être plus grand que 0.")]
        //[Required(ErrorMessage = "Le prix unitaire est nécéssaire")]
        public double PrixUnitaire { get; set; }

        [Required(ErrorMessage = "Quantité incorrecte")]
        public double AmountCrypto { get; set; }

        //[Required(ErrorMessage = "Type d'ordre introuvable")]
        public TypeOrdre Type { get; set; }
        public Status State { get; set; } = Status.Waiting;
        public int? IdTransaction { get; set; }
        public Transaction? Transac { get; set; }

    }
}
