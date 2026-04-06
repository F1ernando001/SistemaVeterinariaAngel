using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Rol
    {
        [Key]
       public int IDRol { get; set; }

       [Required(ErrorMessage = "El campo de rol es obligatorio")]
       [StringLength(50, MinimumLength = 3)]
       public string TipoRol { get; set; }

       [Required(ErrorMessage = "El estado es obligatorio")]
        
       public bool Estado { get; set; }
    }
}
