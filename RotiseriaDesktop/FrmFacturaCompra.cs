using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotiseriaDesktop
{
    public partial class FrmFacturaCompra : Form
    {
        RotiseriaDesktopContext db ;
        private int idCompraAImprimir;

        public FrmFacturaCompra(RotiseriaDesktopContext dbRecibido,int idCompra)
        {
            InitializeComponent();
            this.idCompraAImprimir = idCompra;
            db = dbRecibido;
        }

        private void FrmFacturaCompra_Load(object sender, EventArgs e)
        {
            var Compra = from compra in db.Compras.Where(c=>c.Id==this.idCompraAImprimir)
                                select new { Id = compra.Id, Fecha = compra.Fecha, Proveedor = compra.Proveedor.Razon_social, DetalleCompras= compra.DetalleCompras };
            this.CompraBindingSource.DataSource = Compra.ToList();
           // var Compra= db.Compras.Find(this.idCompraAImprimir);
            //this.CompraBindingSource.DataSource = Compra;
            this.reportViewer1.RefreshReport();

        }
    }
}
