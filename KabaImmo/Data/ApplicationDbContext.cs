using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KabaImmo.Data;

namespace KabaImmo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Societe>()
                .HasMany(e => e.Contacts)
                .WithOne(e => e.Societe)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            builder.Entity<Societe>()
                .HasMany(e => e.Adresses)
                .WithOne(e => e.Societe)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            builder.Entity<Societe>()
                .HasMany(e => e.PieceIdentite)
                .WithOne(e => e.Societe)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            builder.Entity<Societe>()
                .HasMany(e => e.Banques)
                .WithOne(e => e.Societe)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            builder.Entity<Societe>()
                .HasMany(e => e.Immeuble)
                .WithOne(e => e.Societe)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);


            builder.Entity<Immeuble>()
                .HasOne(e => e.Adresse)
                .WithOne(e => e.Immeuble)
                .HasForeignKey<Adresse>(e => e.Id)
                .IsRequired(false);

            builder.Entity<Immeuble>()
                .HasMany(e => e.Contacts)
                .WithOne(e => e.Immeuble)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            builder.Entity<Immeuble>()
                .HasMany(e => e.Lot)
                .WithOne(e => e.Immeuble)
                .HasForeignKey(e => e.Id)
                .IsRequired(true);

            builder.Entity<Immeuble>()
                .HasMany(e => e.Equipements)
                .WithOne(e => e.Immeuble)
                .HasForeignKey(e => e.Id)
                .IsRequired(true);

            builder.Entity<Banque>()
                .HasOne(e => e.Adresse)
                .WithOne(e => e.Banque)
                .HasForeignKey<Banque>(e => e.Id)
                .IsRequired(false);


            builder.Entity<Lot>()
                .HasMany(e => e.Equipements)
                .WithOne(e => e.Lot)
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            base.OnModelCreating(builder);
        }

        public DbSet<Societe> Societe { get; set; }
        public DbSet<Immeuble> Immeuble { get; set; }
        public DbSet<Adresse> Adresse { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<PieceIdentite> PieceIdentite { get; set; }
        public DbSet<Banque> Banque { get; set; }
        public DbSet<KabaImmo.Data.Lot> Lot { get; set; }
    }
}