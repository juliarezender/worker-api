using System.ComponentModel.DataAnnotations;

namespace Domain.Modelos
{
    public class Colaborador
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
