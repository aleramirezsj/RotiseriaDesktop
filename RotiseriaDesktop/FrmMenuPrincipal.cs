﻿using Datos;
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
    public partial class FrmMenuPrincipal : Form
    {
        public static Usuario usuario;

        public FrmMenuPrincipal()
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
            //me fijo cual fue el usuario ingresado en frmLogin y si es
            //gerente habilito el menú usuarios.
            usuario = frmLogin.usuario;
            if (usuario.TipoUsuario == TipoDeUsuarioEnum.Gerente)
                usuariosToolStripMenuItem.Enabled = true;
            else
                usuariosToolStripMenuItem.Enabled = false;
        }
    }
}
