using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgramerBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")] // Burada name alanının veya farklı alanın ne yazması istiyorsak onu belirlediğimiz alan
        [Required(ErrorMessage ="{0} Adı girmelisiniz.")]
        [MaxLength(70,ErrorMessage ="{0} {1} Karakterden büyük olmamalıdır.")]
        [MinLength(3,ErrorMessage = "{0} {1} Karakterden az olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")] // Burada name alanının veya farklı alanın ne yazması istiyorsak onu belirlediğimiz alan
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden az olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")] // Burada name alanının veya farklı alanın ne yazması istiyorsak onu belirlediğimiz alan
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden az olmamalıdır.")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")] // Burada name alanının veya farklı alanın ne yazması istiyorsak onu belirlediğimiz alan
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }


    }
}
