using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        public String Nombre { get; set; }
    }
}
