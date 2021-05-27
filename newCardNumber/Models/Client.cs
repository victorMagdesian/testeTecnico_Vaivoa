using System.ComponentModel.DataAnnotations;

namespace NewCardNumber.Models
{

    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Parametro é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Este Parametro é obrigatório, deve conter um caracter sendo ele: 'v' para Visa ou 'm' para Mastercard")]
        [MaxLength(1, ErrorMessage = "Este campo deve conter um caracter sendo ele: 'v' para Visa ou 'm' para Mastercard ")]
        [MinLength(1, ErrorMessage = "Este campo deve conter um caracter sendo ele: 'v' para Visa ou 'm' para Mastercard")]
        public string CardBrand { get; set; }

        public Card Card { get; set; }
    }

}