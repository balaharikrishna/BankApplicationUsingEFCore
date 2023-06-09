﻿using BankApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Required]
        //[StringLength(17)]
        //[Column(TypeName = "varchar")]
        //public string CustomerAccountId { get; set; }

        [Required]
        [StringLength(12)]
        [Column(TypeName = "varchar")]
        public string CustomerBankId { get; set; }

        [Required]
        [StringLength(18)]
        [Column(TypeName = "varchar")]
        public string CustomerBranchId { get; set; }

        [StringLength(12)]
        [Column(TypeName = "varchar")]
        public string FromCustomerBankId { get; set; }

        [StringLength(12)]
        [Column(TypeName = "varchar")]
        public string ToCustomerBankId { get; set; }

        [StringLength(18)]
        [Column(TypeName = "varchar")]
        public string FromCustomerBranchId { get; set; }

        [StringLength(18)]
        [Column(TypeName = "varchar")]
        public string ToCustomerBranchId { get; set; }

        [StringLength(17)]
        [Column(TypeName = "varchar")]
        public string FromCustomerAccountId { get; set; }

        [Required]
        [StringLength(23)]
        [Column(TypeName = "varchar")]
        public string TransactionId { get; set; }

        [Required]
        [Range(1, 4)]
        [Column(TypeName = "Smallint")]
        public TransactionType TransactionType { get; set; }

        [StringLength(17)]
        [Column(TypeName = "varchar")]
        public string ToCustomerAccountId { get; set; }

        [Required]
        [StringLength(14)]
        [Column(TypeName = "varchar")]
        public string TransactionDate { get; set; }

        [Required]
        public decimal Debit { get; set; }

        [Required]
        public decimal Credit { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        [StringLength(17)]
        [Column(TypeName = "varchar")]
        public string AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Customer Customer { get; set; }
    }
}
