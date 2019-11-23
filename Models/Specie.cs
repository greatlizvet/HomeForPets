using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeForPets.Models
{
    public class Specie
    {
        public int SpecieID { get; set; }
        public string SpecieName { get; set; }

        public virtual ICollection<Form> Forms { get; set; }

        public Specie()
        {
            Forms = new List<Form>();
        }
    }
}