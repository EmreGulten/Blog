using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entity.DTOs.Email
{
    public class EmailSendDto
    {
        [DisplayName("İsminiz")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(60, ErrorMessage = "{0} alanı en fazla {1} karekterden oluşmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karekterden oluşmalıdır.")]
        public string Name { get; set; }
        [DisplayName("E-Posta Adresiniz")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(100, ErrorMessage = "{0} alanı en fazla {1} karekterden oluşmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} karekterden oluşmalıdır.")]
        public string Email { get; set; }
        [DisplayName("Konu")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(125, ErrorMessage = "{0} alanı en fazla {1} karekterden oluşmalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karekterden oluşmalıdır.")]

        public string Phone { get; set; }
        public string Subject { get; set; }
        [DisplayName("Mesajınız")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [MaxLength(1500, ErrorMessage = "{0} alanı en fazla {1} karekterden oluşmalıdır.")]
        [MinLength(20, ErrorMessage = "{0} alanı en az {1} karekterden oluşmalıdır.")]
        public string Message { get; set; }
    }
}
