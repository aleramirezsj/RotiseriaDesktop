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
    public partial class FrmGestionProveedores : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();
        Proveedor proveedor;

        public FrmGestionProveedores()
        {
            InitializeComponent();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            gridProveedores.DataSource = db.Proveedores.ToList();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoProveedor frmNuevoProveedor = new FrmNuevoProveedor(db);
            frmNuevoProveedor.ShowDialog();
            gridProveedores.DataSource = db.Proveedores.ToList();

        }
    }
}
