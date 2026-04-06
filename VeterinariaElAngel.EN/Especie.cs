using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Especie
    {
        [Key]
        public int IDEspecie { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [StringLength(50)]
        public string NombreEspecie { get; set; }
    }
}
