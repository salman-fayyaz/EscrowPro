using EscrowPro.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EscrowPro.Infrastructure.Data
{
    public class EscrowProContext : DbContext
    {
        public EscrowProContext(DbContextOptions<EscrowProContext> dbContextOptions):base(dbContextOptions){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<Buyer>Buyers { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Product> Products {  get; set; }

        public DbSet<Escrow> Escrows { get; set; }

        public DbSet<Dispute> Disputes { get; set; }    

    }
}
