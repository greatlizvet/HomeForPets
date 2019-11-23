using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeForPets.Models
{
    public class Form
    {
        public int FormID { get; set; }
        public string FormName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Enable { get; set; }
        public string Description { get; set; }
        public string Age { get; set; }

        public int ProfileID { get; set; }
        //public virtual Profile Profile { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int SpecieID { get; set; }
        public virtual Specie Species { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public Form()
        {
            Images = new List<Image>();
            Enable = true;
        }
    }
}