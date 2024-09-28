using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PC2.Models
{
     [Table("t_banco")]
    public class Bancos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set;}
        public string? NombreTitular {get; set;}
        public string? TipoCuenta {get; set;}
        public decimal SaldoInicial { get; set; }
        public string? Email {get; set;}
    }
}