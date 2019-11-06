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
    public partial class FrmLogin : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();
        int intentosFallidos = 0;
        public Usuario usuario;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (validarAcceso())
                this.Close();
            else
            {
                intentosFallidos++;
                if (intentosFallidos == 3)
                    Application.Exit();
                else
                {
                    MessageBox.Show("Error en usuario o contraseña ingresados");
                    txtUsuario.Text = "";
                    txtPassword.Text = "";
                }
            }
        }

        private bool validarAcceso()
        {
            string pass = obtenerSha256Hash(txtPassword.Text);
            var listaUsuarios = db.Usuarios.Where(u => u.User.Equals(txtUsuario.Text))
                               .Where(u => u.Password.Equals(pass)).ToList();
            //MessageBox.Show(listaUsuarios.Count.ToString());
            if (listaUsuarios.Count > 0)
            {
                usuario = listaUsuarios.ElementAt(0);
                return true;
            }
            else
            {
                return false;
            }

        }

        //método que 
        static string obtenerSha256Hash(string textoAEncriptar)
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
