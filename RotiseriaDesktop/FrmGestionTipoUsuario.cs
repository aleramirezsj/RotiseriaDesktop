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
    public partial class FrmGestionTipoUsuario : Form
    {

        RotiseriaDesktopContext db = new RotiseriaDesktopContext();

        public FrmGestionTipoUsuario()
        {
            InitializeComponent();
            this.actualizarGrilla();
            gridGestionTipoUsuario.DataSource = db.TipoUsuarios.ToList();
        }

        private void actualizarGrilla()
        {
            var tipoUsuariosAListar = from tipoUsuario in db.TipoUsuarios
                                  select new {
                                      id = tipoUsuario.Id,
                                      nombre = tipoUsuario.Nombre
                                  };
            gridGestionTipoUsuario.DataSource = tipoUsuariosAListar.ToList();
        }

        private void actualizarGrilla(string textoBuscar)
        {
            var tipoUsuariosAListar = from tipoUsuario in db.TipoUsuarios
                                      select new
                                      {
                                          id = tipoUsuario.Id,
                                          nombre = tipoUsuario.Nombre
                                      };
            gridGestionTipoUsuario.DataSource = tipoUsuariosAListar.Where(tpu => tpu.nombre.Contains(textoBuscar)).ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmNuevoTipoUsuario frmNuevoTipoUsuario = new FrmNuevoTipoUsuario();
            frmNuevoTipoUsuario.ShowDialog();
            actualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)this.celdaFilaActual(gridGestionTipoUsuario, 0);

            FrmNuevoTipoUsuario frmNuevoTipoUsuario = new FrmNuevoTipoUsuario(idSeleccionado, db);
            frmNuevoTipoUsuario.ShowDialog();
            actualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)this.celdaFilaActual(gridGestionTipoUsuario, 0);
            string usuarioSeleccionado = (string)this.celdaFilaActual(gridGestionTipoUsuario, 1);

            string mensaje = "¿Está seguro que desea eliminar el tipo de usuario: " + usuarioSeleccionado + "?";
            string titulo = "Eliminación de un usuario";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                TipoUsuario tipoUsuario = db.TipoUsuarios.Find(idSeleccionado);
                db.TipoUsuarios.Remove(tipoUsuario);
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
