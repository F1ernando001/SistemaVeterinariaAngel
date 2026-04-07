using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Expediente
    {
        [Key]
        public int IDExpediente { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int IDUsuario { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int IdMascota { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int IDRaza { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int IDEspecie { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50)]
        public string NumeroExpediente { get; set; }
        public DateOnly FechaNacimiento { get; set; }

    }
}
