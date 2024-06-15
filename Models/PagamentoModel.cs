using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public class PagamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pagamento { get; set; }

        [Required]
        public string Cpf_Cliente { get; set; }

        [Required]
        public int id_agendamento { get; set; }

        [Required]
        public string forma_pagamento { get; set; }

        [Required]
        public string ValorPago { get; set; }

        [Required]
        public DateTime data_pagamento { get; set; }



        public PagamentoModel()
        {
        }
    }
}
