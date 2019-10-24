using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(60, ErrorMessage = "No puede ingresar más de 60 caracteres")]
        public String User { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public TipoDeUsuarioEnum TipoUsuario { get; set; }


    }
}
