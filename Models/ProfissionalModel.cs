using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models;

public class ProfissionalModel
{ 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id_profissional { get; set; }

    public string nome_profissional { get; set; }

    public string especialidade { get; set; }

    public ProfissionalModel()
    {
    }

}
