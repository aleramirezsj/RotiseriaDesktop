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
    public partial class FrmNuevoUsuario : Form
    {
        RotiseriaDesktopContext db;
        Usuario usuario;
        TipoUsuario tipoUsuario;

        public FrmNuevoUsuario()
        {
            InitializeComponent();
            db = new RotiseriaDesktopContext();
            usuario = new Usuario();
            //tipoUsuario = new TipoUsuario();
            this.cargarTipoUsuario(0);    
        }

        public FrmNuevoUsuario(RotiseriaDesktopContext dbEnviado)
        {
            InitializeComponent();
            db = dbEnviado;
            usuario = new Usuario();
            //tipoUsuario = new TipoUsuario();
            this.cargarTipoUsuario(0);
        }

        public FrmNuevoUsuario(int idSeleccionado, RotiseriaDesktopContext dbEnviado)
        {
            InitializeComponent();
            db = dbEnviado;
            //tipoUsuario = new TipoUsuario();
            usuario = new Usuario();
            this.cargarUsuario(idSeleccionado);
        }

        private void cargarUsuario(int idSeleccionado)
        {
            usuario = db.Usuarios.Find(idSeleccionado);
            this.cargarTipoUsuario(usuario.TipoUsuarioId);
            txtUsuario.Text = usuario.User;
            txtPassword.Text = usuario.Password;
        }

        private void cargarTipoUsuario(int idSeleccionado)
        {
            cboTipoUsuario.DataSource = db.TipoUsuarios.ToList();
            cboTipoUsuario.DisplayMember = "Nombre";
            cboTipoUsuario.ValueMember = "Id";
            cboTipoUsuario.SelectedValue = idSeleccionado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            usuario.TipoUsuario = (TipoUsuario)cboTipoUsuario.SelectedItem;
            usuario.User = txtUsuario.Text;
            usuario.Password = txtPassword.Text;

            if (usuario.Id > 0)
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                MessageBox.Show("Se ha modificado el usuario correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                db.Usuarios.Add(usuario);
                MessageBox.Show("Se ha guardado correctamente el usuario.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }

            db.SaveChanges();
            this.Close();
        }
    }
}
