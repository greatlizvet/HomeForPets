using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeForPets.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Form> Forms { get; set; }

        public Category()
        {
            Forms = new List<Form>();
        }
    }
}