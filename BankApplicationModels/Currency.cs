﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Models
{
    [Table("Currencies")]
    public class Currency
    {
        [Key]
        [Required]
        [StringLength(4)]
        [Column(TypeName = "varchar")]
        public string CurrencyCode { get; set; }

        [Required]

        public decimal ExchangeRate { get; set; }

        [Required]
        [RegularExpression("^[01]+$")]
        public bool IsActive { get; set; }

        [Required]
        [StringLength(12)]
        [Column(TypeName = "varchar")]
        public string BankId { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        public string DefaultCurrencyCode = "INR";

        public short DefaultCurrencyExchangeRate = 1;
    }
}
