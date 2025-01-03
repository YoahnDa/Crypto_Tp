using Backend_Crypto.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Crypto.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AuthToken> Tokens { get; set; }
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<HistoriquePrix> Historiques { get; set; }
        public DbSet<Ordre> Ordres { get; set; }
        public DbSet<Portefeuille> Portefeuilles { get; set; }
        public DbSet<StockPortefeuille> Stocks { get; set; }
        public DbSet<Transaction> Transac { get; set; }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Crypto>()
                .HasKey(c => c.IdCrypto);
            modelBuilder.Entity<Crypto>()
                .HasIndex(c => c.Symbole)
                .IsUnique();
            modelBuilder.Entity<Crypto>()
                .HasIndex(c => c.Nom)
                .IsUnique();

            modelBuilder.Entity<Portefeuille>()
                .HasKey(p => p.IdPortefeuille);

            modelBuilder.Entity<Portefeuille>()
                .HasIndex(c => c.IdUser)
                .IsUnique();

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.IdTransaction);
            modelBuilder.Entity<Transaction>()
                .Property(t => t.DateTransaction)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.PortefeuilleOwner)
                .WithMany(a => a.Transac)
                .HasForeignKey(t => t.IdPortefeuille)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthToken>()
                .HasKey(a => a.IdToken);
            modelBuilder.Entity<AuthToken>()
                .Property(a => a.Token)
                .HasColumnType("TEXT");
            modelBuilder.Entity<AuthToken>()
                .HasOne(a => a.Transac)
                .WithMany(c => c.TokenAuth)
                .HasForeignKey(a => a.IdTransaction)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ordre>()
                .HasKey(o => o.IdOrdre);
            modelBuilder.Entity<Ordre>()
                .Property(o => o.Type)
                .HasConversion<string>();
            modelBuilder.Entity<Ordre>()
                .Property(o => o.State)
                .HasConversion<string>();
            modelBuilder.Entity<Ordre>()
                .HasOne(o => o.Transac)
                .WithOne(t => t.Ordre)
                .HasForeignKey<Ordre>(o => o.IdTransaction)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HistoriquePrix>()
                .HasKey(p => p.IdHistorique);
            modelBuilder.Entity<HistoriquePrix>()
                .Property(t => t.DateChange)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<HistoriquePrix>()
                .HasOne(h => h.CryptoChange)
                .WithMany(c => c.Historiques)
                .HasForeignKey(h => h.idCrypto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StockPortefeuille>()
                .HasKey(p => new { p.IdPorteFeuille , p.IdCrypto });
            modelBuilder.Entity<StockPortefeuille>()
                .HasOne(p => p.PorteFeuilleOwn)
                .WithMany(s => s.Stock)
                .HasForeignKey(p => p.IdPorteFeuille)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<StockPortefeuille>()
                .HasOne(c => c.CryptoIn)
                .WithMany(s => s.StockClient)
                .HasForeignKey(c => c.IdCrypto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
