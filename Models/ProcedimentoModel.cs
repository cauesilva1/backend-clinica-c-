using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public class ProcedimentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cod_procedimento { get; set; }

        public string procedimento { get; set; }

        public string valor { get; set; }

        public string tipo { get; set; }

        public ProcedimentoModel()
        {
        }
    }
}
