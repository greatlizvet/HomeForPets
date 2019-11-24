using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeForPets.Models
{
    public class Form
    {
        public int FormID { get; set; }

        [Display(Name = "Название анкеты")]
        [Required]
        public string FormName { get; set; }
        
        public DateTime CreateDate { get; set; }
        public bool Enable { get; set; }

        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Возраст")]
        public string Age { get; set; }

        public int ProfileID { get; set; }
        //public virtual Profile Profile { get; set; }

        [Display(Name = "Категория")]
        [Required]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Вид")]
        [Required]
        public int SpecieID { get; set; }
        public virtual Specie Species { get; set; }

        [Display(Name = "Изображения")]
        public virtual ICollection<Image> Images { get; set; }

        public Form()
        {
            Images = new List<Image>();
            Enable = true;
        }
    }
}