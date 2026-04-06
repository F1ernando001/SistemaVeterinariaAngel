using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Genero
    {
        [Key]
        public int IDGenero { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }
        
    }
}
