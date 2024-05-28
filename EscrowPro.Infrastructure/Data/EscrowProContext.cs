using EscrowPro.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EscrowPro.Infrastructure.Data
{
    public class EscrowProContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public EscrowProContext(DbContextOptions<EscrowProContext> options) : base(options){}

        public EscrowProContext() { }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Escrow> Escrows { get; set; }

        public DbSet<Dispute> Disputes { get; set; }

        public DbSet<BuyerForm> BuyerForms { get; set; }

        public DbSet<SellerForm> SellerForms {  get; set; }

        public DbSet<Login>Logins { get; set; }
    }
}
