
using System.ComponentModel.DataAnnotations;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        [Required]
        [MinLength(3,ErrorMessage = "Insira um nome com no mínimo 3 caracteres.")]
        public string Nome { get; set; }
    }
}
