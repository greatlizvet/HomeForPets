using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeForPets.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Form> Forms { get; set; }

        public Image()
        {
            Forms = new List<Form>();
        }
    }
}