using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class Status
    {
        [Key]
        public int IDEstado { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(50, MinimumLength = 3)]
        public string Estado { get; set; }
    }
}
