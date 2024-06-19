using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public class AgendamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_agendamento { get; set; }

        [Required]
        public string Cpf_Cliente { get; set; }

        [Required]
        public int cod_procedimento { get; set; }

        [Required]
        public int id_profissional { get; set; }

        [Required]
        public DateTime horario_agendamento { get; set; }

        // Propriedades de navegação para os relacionamentos
        [ForeignKey("cod_procedimento")]
        public virtual ProcedimentoModel procedimento { get; set; }

        [ForeignKey("id_profissional")]
        public virtual ProfissionalModel nome_profissional { get; set; }


        public AgendamentoModel()
        {
        }
    }
}
