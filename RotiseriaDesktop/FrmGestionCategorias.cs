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
    public partial class FrmGestionCategorias : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();

        public FrmGestionCategorias()
        {
            InitializeComponent();
            grid.DataSource = db.Categorias.ToList();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria frmNuevaCategoria = new FrmNuevaCategoria(db);
            frmNuevaCategoria.ShowDialog();
            //recargamos el listado de categorias
            grid.DataSource = db.Categorias.ToList();
        }
        private object obtenerCeldaGrilla(int nroCelda)
        {
            DataGridViewCellCollection celdasFilaActual = grid.CurrentRow.Cells;
            return celdasFilaActual[nroCelda].Value;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            int idSeleccionado = (int)obtenerCeldaGrilla(0);
            string categoriaSeleccionada = (string)obtenerCeldaGrilla(1);

            string mensaje = "¿Está seguro que desea eliminar la categoría: " + categoriaSeleccionada + "?";
            string titulo = "Eliminación de una categoría";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Categoria categoria = db.Categorias.Find(idSeleccionado);
                db.Categorias.Remove(categoria);
                db.SaveChanges();
                //recargamos el listado de categorias
                grid.DataSource = db.Categorias.ToList();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = (int)obtenerCeldaGrilla(0);
            FrmNuevaCategoria frmNuevaCategoria = new FrmNuevaCategoria(idSeleccionado,db);
            frmNuevaCategoria.ShowDialog();
            //recargamos el listado de categorias
            //db = new RotiseriaDesktopContext();
            grid.DataSource = db.Categorias.ToList();

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            grid.DataSource = db.Categorias.Where(c => c.Nombre.Contains(txtBusqueda.Text)).ToList();
        }


    }
}
