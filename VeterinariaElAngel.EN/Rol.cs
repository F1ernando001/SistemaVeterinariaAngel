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
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El campo de rol es obligatorio")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Tipo de Rol")]
        public string TipoRol { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }


        public List<Usuario> Usuarios { get; set; }
    }
}
