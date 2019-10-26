using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotiseriaDesktop
{
    public partial class FrmNuevoUsuario : Form
    {
        RotiseriaDesktopContext db;
        Usuario usuario;
        

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
            this.cargarTipoUsuario((int)usuario.TipoUsuario);
            txtUsuario.Text = usuario.User;
            txtPassword.Text = usuario.Password;
        }

        private void cargarTipoUsuario(int idSeleccionado)
        {
            cboTipoUsuario.DataSource = Enum.GetValues(typeof(TipoDeUsuarioEnum));
            cboTipoUsuario.SelectedIndex = idSeleccionado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            usuario.TipoUsuario =(TipoDeUsuarioEnum)cboTipoUsuario.SelectedIndex+1;
            usuario.User = txtUsuario.Text;
            usuario.Password = obtenerSha256Hash(txtPassword.Text);

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

        //método que 
        private string obtenerSha256Hash(string textoAEncriptar)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoAEncriptar));

                // Convert byte array to a string   
                StringBuilder hashObtenido = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    hashObtenido.Append(bytes[i].ToString("x2"));
                }
                return hashObtenido.ToString();
            }
        }
    }
}
