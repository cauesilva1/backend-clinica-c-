using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models;

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
    public DateTime HorarioAgendado { get; internal set; }

    public AgendamentoModel()
        {
        }
    }
