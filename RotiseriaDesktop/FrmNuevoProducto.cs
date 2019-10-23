using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotiseriaDesktop
{
    public partial class FrmNuevoProducto : Form
    {
        RotiseriaDesktopContext db;
        Producto producto;

        /// <summary>
        /// Constructor que se ejecuta cuando cargamos un nuevo producto
        /// </summary>
        /// <param name="dbRecibido">Objeto db entity framework que maneja la bbdd </param>
        public FrmNuevoProducto(RotiseriaDesktopContext dbRecibido)
        {
            InitializeComponent();
            db = dbRecibido;
            cargarCombo(0);
            producto = new Producto();
        }

        /// <summary>
        /// Constructor que se ejecuta cuando modificamos un producto
        /// </summary>
        /// <param name="dbRecibido">Objeto db entity framework que maneja la bbdd </param>
        /// <param name="idSeleccionado">id del producto a modificar</param>
        public FrmNuevoProducto(RotiseriaDesktopContext dbRecibido,int idSeleccionado)
        {
            InitializeComponent();
            db = dbRecibido;
            producto = db.Productos.Find(idSeleccionado);
            cargarProducto();
            cargarCombo(producto.CategoriaProductoId);

        }

        private void cargarProducto()
        {
            txtNombre.Text = producto.Nombre;
            nudCantidad.Value = producto.Cantidad;
            nudPrecioCosto.Value = producto.PrecioCosto;
            nudPrecioVenta.Value = producto.PrecioVenta;
        }

        public FrmNuevoProducto()
        {
            InitializeComponent();
            db = new RotiseriaDesktopContext();
            cargarCombo(0);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            producto.Nombre = txtNombre.Text;
            producto.Cantidad = (int)nudCantidad.Value;
            producto.PrecioCosto = nudPrecioCosto.Value;
            producto.PrecioVenta = nudPrecioVenta.Value;
            producto.CategoriaProductoId = (int)cboCategoria.SelectedValue;

            if (producto.Id > 0)
            {
                db.Entry(producto).State = EntityState.Modified;
            }
            else
            {
                db.Productos.Add(producto);
            }
            db.SaveChanges();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        private void cargarCombo(int idCategoria)
        {
            cboCategoria.DataSource = db.Categorias.ToList();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedValue = idCategoria;
        }
    }
}
