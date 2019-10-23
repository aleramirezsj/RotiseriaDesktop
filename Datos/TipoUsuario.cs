using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tipo_usuario")]
        public String Nombre { get; set; }
    }
}
