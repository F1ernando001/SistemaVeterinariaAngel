using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio")]
        [StringLength(50, MinimumLength = 6)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estado de la mascota es obligatorio")]
        public bool Estado { get; set; }
    }
}
