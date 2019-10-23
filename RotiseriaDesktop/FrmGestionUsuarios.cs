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
    public partial class FrmGestionUsuarios : Form
    {

        RotiseriaDesktopContext db = new RotiseriaDesktopContext();

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            this.actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            var usuariosAListar = from usuario in db.Usuarios
                                  select new { id = usuario.Id, tipoUsuario = usuario.TipoUsuario.Nombre, user = usuario.User};
            gridGestionUsuario.DataSource = usuariosAListar.ToList();
        }

        private void actualizarGrilla(string textoBuscar)
        {
            var usuariosAListar = from usuario in db.Usuarios
                                  select new { id = usuario.Id, tipoUsuario = usuario.TipoUsuario.Nombre, user = usuario.User};
            gridGestionUsuario.DataSource = usuariosAListar.Where(u => u.user.Contains(textoBuscar)).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoUsuario frmNuevoUsuario = new FrmNuevoUsuario();
            frmNuevoUsuario.ShowDialog();
            actualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)this.celdaFilaActual(gridGestionUsuario, 0);
            //string usuarioSeleccionado = (string)this.celdaFilaActual(gridGestionUsuario, 2);

            FrmNuevoUsuario frmNuevoUsuario = new FrmNuevoUsuario(idSeleccionado, db);
            frmNuevoUsuario.ShowDialog();
            actualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)this.celdaFilaActual(gridGestionUsuario, 0);
            string usuarioSeleccionado = (string)this.celdaFilaActual(gridGestionUsuario, 2);

            string mensaje = "¿Está seguro que desea eliminar el usuario: " + usuarioSeleccionado + "?";
            string titulo = "Eliminación de un usuario";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Usuario usuario = db.Usuarios.Find(idSeleccionado);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
                //recargamos el listado de categorias
                actualizarGrilla();
            }
        }

        /// <summary>
        /// Obtiene la celda y la fila actual seleccionada.
        /// </summary>
        /// <param name="grid"> Corresponde al nombre del DataGridView.</param>
        /// <param name="column">Corresponde al índice de columna del DataGridView.</param>
        /// <returns>Retorna un object.</returns>
        private object celdaFilaActual(DataGridView grid, int column)
        {
            DataGridViewCellCollection celdasFilaActual = grid.CurrentRow.Cells;

            return celdasFilaActual[column].Value;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            actualizarGrilla(txtBuscar.Text);
        }
    }
}
