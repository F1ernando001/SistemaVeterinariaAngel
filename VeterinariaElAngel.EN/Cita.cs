using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [DataType(DataType.Time)]
        public DateTime HoraCita { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [DataType (DataType.Date)]
        public DateTime FechaCreacion { get; set; }
    }
}
