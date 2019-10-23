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
    public partial class FrmNuevoTipoUsuario : Form
    {
        RotiseriaDesktopContext db;

        public TipoUsuario tipoUsuario;

        public FrmNuevoTipoUsuario()
        {
            InitializeComponent();
            db = new RotiseriaDesktopContext();
            tipoUsuario = new TipoUsuario();
        }

        public FrmNuevoTipoUsuario(RotiseriaDesktopContext dbEnviado)
        {
            InitializeComponent();
            db = dbEnviado;
            tipoUsuario = new TipoUsuario();
        }

        public FrmNuevoTipoUsuario(int idSeleccionado, RotiseriaDesktopContext dbEnviado)
        {
            InitializeComponent();
            db = dbEnviado;
            this.cargarTipoUsuario(idSeleccionado);
        }

        private void cargarTipoUsuario(int idSeleccionado)
        {
            tipoUsuario = db.TipoUsuarios.Find(idSeleccionado);
            txtNombre.Text = tipoUsuario.Nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tipoUsuario.Nombre = txtNombre.Text;

            if (tipoUsuario.Id > 0)
            {
                db.Entry(tipoUsuario).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.TipoUsuarios.Add(tipoUsuario);
            }

            db.SaveChanges();
            MessageBox.Show("Se ha guardado correctamente el tipo de usuario.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
