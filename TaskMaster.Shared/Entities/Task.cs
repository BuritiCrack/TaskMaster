using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Shared.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string? Descripcion { get; set; }
        public DateTime FechaCreación { get; set; }
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Prioridad")]
        public int Prioridad { get; set; }

        [Display(Name = "Estado: pendiente, en progreso, completada")]
        public string? Estado { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

    }
}
