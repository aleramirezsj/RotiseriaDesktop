using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Compra
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required]
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Iva { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal Total { get; set; }

        //establece un vínculo entre la tabla compras y detalle de compras, haciendo que
        //cada vez que obtengamos una compra, también nos traiga como objetos, a todos sus
        //detalles de compras
        public virtual ObservableCollection<DetalleCompra> DetalleCompras { get; set; }

    }
}
