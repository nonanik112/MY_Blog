using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgramerBlog.Entities.Dtos
{
   public class UserLoginDto
    {
        [DisplayName("E-Posta Adresi")] // Burada name alanının veya farklı alanın ne yazması istiyorsak onu belirlediğimiz alan
        [Required(ErrorMessage = "{0} Adı girmelisiniz.")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden küçük olmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")] // Burada name alanının veya farklı alanın ne yazması istiyorsak onu belirlediğimiz alan
        [Required(ErrorMessage = "{0} Adı girmelisiniz.")]
        [MaxLength(50, ErrorMessage = "{0} {1} Karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden küçük olmamalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
