using System.ComponentModel.DataAnnotations;

namespace NewCardNumber.Models
{

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(19)]
        public string CardNumber { get; set; }
    }
}