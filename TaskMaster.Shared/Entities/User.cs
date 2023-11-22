using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Shared.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Nombre es correoelectronico")]
        public string? CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El campo Nombre es contraseña")]
        public string? Password { get; set; }

        public virtual ICollection<Task>? Tasks { get; set; }
    }
}
