using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public  class Raza
    {
        [Key]
        public int IDRaza { get; set; }

        [Required(ErrorMessage ="El nombre de la raza es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; } 
    }
}
