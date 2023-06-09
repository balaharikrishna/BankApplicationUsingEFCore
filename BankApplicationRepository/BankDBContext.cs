﻿using BankApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Repository
{
    public class BankDBContext : DbContext
    {
        public BankDBContext(DbContextOptions<BankDBContext> options) : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<TransactionCharge> TransactionCharges { get; set; }
        public DbSet<ReserveBankManager> ReserveBankManagers { get; set; }
        public DbSet<HeadManager> HeadManagers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Currency>()
                .Property(c => c.ExchangeRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
            .Property(t => t.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Credit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
            .Property(t => t.Debit)
                .HasPrecision(19, 4);
        }
    }
}
