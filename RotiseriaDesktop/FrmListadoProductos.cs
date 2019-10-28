using Datos;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmListadoProductos : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            var Productos = from producto in db.Productos
                                   select new { Id = producto.Id, Nombre = producto.Nombre, PrecioVenta = producto.PrecioVenta, CategoriaProducto = producto.CategoriaProducto.Nombre };
            //ReportDataSource datosReporte = new ReportDataSource("Datos", productosAListar.ToList());
            //datosReporte.Name = "DataSetProductos";
            //this.reportViewer1.LocalReport.DataSources.Add(datosReporte);*/
            //var Productos= db.Productos.ToList();
            this.ProductoBindingSource.DataSource = Productos.ToList();
            this.reportViewerProductos.RefreshReport();
        }
    }
}
