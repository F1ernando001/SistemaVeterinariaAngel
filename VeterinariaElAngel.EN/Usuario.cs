using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo de nombre es obligatorio")]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; } 

        [Required(ErrorMessage = "El campo de apellido es obligatorio")]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50)]
        public string Correo { get; set; }

        [Required(ErrorMessage ="El campo de contraseña es obligatorio")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(8)]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "EL DUI es obligatorio")]
        [StringLength(10)]
        public int DUI { get; set; }

        [StringLength(50)]
        public string? Direccion { get; set; }
    }
}
