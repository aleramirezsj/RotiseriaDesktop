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
    public partial class FrmListaUsuarios : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();
        public FrmListaUsuarios()
        {
            InitializeComponent();
        }

        private void FrmListaUsuarios_Load(object sender, EventArgs e)
        {
            var ListaUsuarios = from usuario in db.Usuarios
                                  select new { Id = usuario.Id, TipoUsuario = usuario.TipoUsuario.ToString(), User = usuario.User };
            this.UsuarioBindingSource.DataSource = ListaUsuarios.ToList();
            this.reportViewerUsuarios.RefreshReport();
        }
    }
}
