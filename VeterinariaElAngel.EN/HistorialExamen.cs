using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VeterinariaElAngel.EN
{
    public class HistorialExamen
    {
        [Key]
        public int IDHistorialExamen { get; set; }
        public int IDExpediente { get; set; }
        public string NombreExamen { get; set; }
        public string Resultado { get; set; }
        public DateOnly FechaExamen { get; set; }
    }
}
