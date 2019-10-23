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
    public partial class frmMenuPrincipal : Form
    {
        Usuario usuario;

        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void insertarUnaNuevaCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria frmNuevaCategoria = new FrmNuevaCategoria(new RotiseriaDesktopContext());
            frmNuevaCategoria.ShowDialog();
        }

        private void gestiónDeCategoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionCategorias frmGestionCategorias = new FrmGestionCategorias();
            frmGestionCategorias.ShowDialog();
        }

        private void insertarNuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoProducto frmNuevoProducto = new FrmNuevoProducto();
            frmNuevoProducto.ShowDialog();
        }

        private void gestiónDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionProductos frmGestionProductos = new FrmGestionProductos();
            frmGestionProductos.ShowDialog();
        }

        private void insertarNuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompras frmCompras = new FrmCompras();
            frmCompras.ShowDialog();
        }

        private void insertarNuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoProveedor frmNuevoProveedor = new FrmNuevoProveedor();
            frmNuevoProveedor.ShowDialog();
        }

        private void gestiónDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionProveedores frmGestionProveedores = new FrmGestionProveedores();
            frmGestionProveedores.ShowDialog();
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios frmGestionUsuarios = new FrmGestionUsuarios();
            frmGestionUsuarios.ShowDialog();
        }

        private void gestiónDeTiposDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionTipoUsuario frmGestionTipoUsuario = new FrmGestionTipoUsuario();
            frmGestionTipoUsuario.ShowDialog();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            usuario = frmLogin.usuario;
            if (usuario.TipoUsuario.Nombre == "Gerente")
                usuariosToolStripMenuItem.Enabled = true;
            else
                usuariosToolStripMenuItem.Enabled = false;
        }
    }
}
