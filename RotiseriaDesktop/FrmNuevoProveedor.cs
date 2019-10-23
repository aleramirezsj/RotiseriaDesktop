using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotiseriaDesktop
{
    public partial class FrmNuevoProveedor : Form
    {
        RotiseriaDesktopContext db;
        public Proveedor proveedor;

        //nuevo desde el menú
        public FrmNuevoProveedor()
        {
            InitializeComponent();
            db = new RotiseriaDesktopContext();
            proveedor = new Proveedor();
        }
        //nuevo
        public FrmNuevoProveedor(RotiseriaDesktopContext dbRecibido)
        {
            InitializeComponent();
            db = dbRecibido;
            proveedor = new Proveedor();
        }
        //modificar
        public FrmNuevoProveedor(RotiseriaDesktopContext dbRecibido,int idModificar)
        {
            InitializeComponent();
            db = dbRecibido;
            proveedor = db.Proveedores.Find(idModificar);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            proveedor.Razon_social = txtRazonSocial.Text;
            proveedor.Domicilio = txtDomicilio.Text;
            proveedor.telefono = txtTelefono.Text;
            proveedor.observaciones = txtObservaciones.Text;
            proveedor.celular = txtCelular.Text;
            if (proveedor.Id > 0)
            {
                db.Entry(proveedor).State = EntityState.Modified;
            }
            else
            {
                db.Proveedores.Add(proveedor);
            }
            db.SaveChanges();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
