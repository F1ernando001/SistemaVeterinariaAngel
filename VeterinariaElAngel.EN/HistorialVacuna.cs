using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class HistorialVacuna
    {
        [Key]
        public int IDHistorialVacuna { get; set; }

        [Required]
        public int IDExpediente { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(100)]
        public string NombreVacuna { get; set; }

        [Required]
        public DateOnly FechaVacuna { get; set; }

    }
}
