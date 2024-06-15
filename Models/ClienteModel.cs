using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace teste.Models;

public class ClienteModel
{
    [Key]
    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [JsonPropertyName("Cpf_Cliente")]
    public string Cpf_Cliente { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [JsonPropertyName("Nome_Cliente")]
    public string Nome_Cliente { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [JsonPropertyName("Telefone")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
    [JsonPropertyName("Logradouro")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo Número é obrigatório.")]
    [JsonPropertyName("Numero")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
    [JsonPropertyName("Bairro")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
    [JsonPropertyName("Cidade")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O campo UF é obrigatório.")]
    [JsonPropertyName("Uf")]
    public string Uf { get; set; }

    [Required(ErrorMessage = "O campo Complemento é obrigatório.")]
    [JsonPropertyName("Complemento")]
    public string Complemento { get; set; }

    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    [JsonPropertyName("Cep")]
    public string Cep { get; set; }

    public ClienteModel()
    {    
    }
}
