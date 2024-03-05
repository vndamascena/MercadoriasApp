using System.ComponentModel.DataAnnotations;

namespace MercadoriasApp.Services.Model
{
    public class MercadoriasPutRequestModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da mercadoria.")]
        public Guid? Id { get; set; }
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{8,100}$", ErrorMessage = "Por favor, informe um nome válido de 8 a 100 caracteres.")]

        [Required(ErrorMessage = "Por favor, informe o nome da mercadoria.")]
        public string? Nome { get; set; }
        [Range(0, 999999, ErrorMessage = "Por favor, informe o preço entre {1}    e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço da mercadoria.")]
        public decimal? Preco { get; set; }
        [Range(0, 9999, ErrorMessage = "Por favor, informe a quantidade entre {1} e {2}.")]

        [Required(ErrorMessage = "Por favor, informe a quantidade da mercadoria.")]

        public int? Quantidade { get; set; }


        [Required(ErrorMessage = "Por favor, informe o id da categoria.")]
        public Guid? CategoriaId { get; set; }


        [Required(ErrorMessage = "Por favor, informe o id do fornecedor.")]
        public Guid? FornecedorId { get; set; }

    }
}

