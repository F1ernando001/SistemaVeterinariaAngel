using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El campo de nombre es obligatorio")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo de apellido es obligatorio")]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo de contraseña es obligatorio")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [StringLength(8, MinimumLength = 8)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo de DUI es obligatorio")]
        [StringLength(10, MinimumLength = 10)]
        public string DUI { get; set; }

        public string? Dirección { get; set; }

        // Relación con Rol
        public Rol Rol { get; set; }

        // Campo auxiliar
        public int top_Aux { get; set; }
    }
}
