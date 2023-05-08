﻿// <auto-generated />
using BankApplication.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(BankDBContext))]
    partial class BankDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankApplicationModels.Bank", b =>
                {
                    b.Property<string>("BankId")
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("BankApplicationModels.Branch", b =>
                {
                    b.Property<string>("BranchId")
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<string>("BankId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<string>("BranchAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("BranchPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("BranchId");

                    b.HasIndex("BankId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("BankApplicationModels.Currency", b =>
                {
                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(4)
                        .HasColumnType("varchar");

                    b.Property<string>("BankId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<decimal>("ExchangeRate")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CurrencyCode");

                    b.HasIndex("BankId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("BankApplicationModels.Customer", b =>
                {
                    b.Property<string>("AccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<short>("AccountType")
                        .HasColumnType("Smallint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Balance")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<short>("Gender")
                        .HasColumnType("Smallint");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("PassbookIssueDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<short>("Role")
                        .HasColumnType("Smallint");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("AccountId");

                    b.HasIndex("BranchId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankApplicationModels.HeadManager", b =>
                {
                    b.Property<string>("AccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<string>("BankId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<short>("Role")
                        .HasColumnType("Smallint");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("AccountId");

                    b.HasIndex("BankId");

                    b.ToTable("HeadManagers");
                });

            modelBuilder.Entity("BankApplicationModels.Manager", b =>
                {
                    b.Property<string>("AccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<short>("Role")
                        .HasColumnType("Smallint");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("AccountId");

                    b.HasIndex("BranchId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("BankApplicationModels.ReserveBankManager", b =>
                {
                    b.Property<string>("AccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<short>("Role")
                        .HasColumnType("Smallint");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("AccountId");

                    b.ToTable("ReserveBankManagers");
                });

            modelBuilder.Entity("BankApplicationModels.Staff", b =>
                {
                    b.Property<string>("AccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<short>("Role")
                        .HasColumnType("Smallint");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)");

                    b.HasKey("AccountId");

                    b.HasIndex("BranchId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BankApplicationModels.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Balance")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<decimal>("Credit")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("CustomerAccountId")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<string>("CustomerBankId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<string>("CustomerBranchId")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Debit")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("FromCustomerAccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<string>("FromCustomerBankId")
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<string>("FromCustomerBranchId")
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<string>("ToCustomerAccountId")
                        .HasMaxLength(17)
                        .HasColumnType("varchar");

                    b.Property<string>("ToCustomerBankId")
                        .HasMaxLength(12)
                        .HasColumnType("varchar");

                    b.Property<string>("ToCustomerBranchId")
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<string>("TransactionDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasMaxLength(23)
                        .HasColumnType("varchar");

                    b.Property<short>("TransactionType")
                        .HasColumnType("Smallint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankApplicationModels.TransactionCharge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BranchId")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar");

                    b.Property<short>("ImpsOtherBank")
                        .HasColumnType("Smallint");

                    b.Property<short>("ImpsSameBank")
                        .HasColumnType("Smallint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<short>("RtgsOtherBank")
                        .HasColumnType("Smallint");

                    b.Property<short>("RtgsSameBank")
                        .HasColumnType("Smallint");

                    b.HasKey("Id");

                    b.HasIndex("BranchId")
                        .IsUnique();

                    b.ToTable("TransactionCharges");
                });

            modelBuilder.Entity("BankApplicationModels.Branch", b =>
                {
                    b.HasOne("BankApplicationModels.Bank", "Bank")
                        .WithMany("Branches")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankApplicationModels.Currency", b =>
                {
                    b.HasOne("BankApplicationModels.Bank", "Bank")
                        .WithMany("Currencies")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankApplicationModels.Customer", b =>
                {
                    b.HasOne("BankApplicationModels.Branch", "Branch")
                        .WithMany("Customers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankApplicationModels.HeadManager", b =>
                {
                    b.HasOne("BankApplicationModels.Bank", "Bank")
                        .WithMany("HeadManagers")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("BankApplicationModels.Manager", b =>
                {
                    b.HasOne("BankApplicationModels.Branch", "Branch")
                        .WithMany("Managers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankApplicationModels.Staff", b =>
                {
                    b.HasOne("BankApplicationModels.Branch", "Branch")
                        .WithMany("Staffs")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankApplicationModels.Transaction", b =>
                {
                    b.HasOne("BankApplicationModels.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BankApplicationModels.TransactionCharge", b =>
                {
                    b.HasOne("BankApplicationModels.Branch", "Branch")
                        .WithOne("TransactionCharges")
                        .HasForeignKey("BankApplicationModels.TransactionCharge", "BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankApplicationModels.Bank", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("Currencies");

                    b.Navigation("HeadManagers");
                });

            modelBuilder.Entity("BankApplicationModels.Branch", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Managers");

                    b.Navigation("Staffs");

                    b.Navigation("TransactionCharges");
                });

            modelBuilder.Entity("BankApplicationModels.Customer", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
