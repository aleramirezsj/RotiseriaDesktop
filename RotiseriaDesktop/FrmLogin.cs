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
            var listaUsuarios = db.Usuarios.Where(u => u.User.Equals(txtUsuario.Text))
                                           .Where(u=>u.User.Equals(txtPassword.Text)).ToList();
            if (listaUsuarios.Count > 0)
            {
                usuario = listaUsuarios.ElementAt(0);
                this.Close();
            }
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
    }
}
