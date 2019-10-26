using Datos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class FrmCompras : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();
        Compra compra = new Compra();
        DetalleCompra detalleCompra;

        public FrmCompras()
        {
            InitializeComponent();
            cargarComboProveedor(0);
            cargarComboProductos(0);
            actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            if (compra.DetalleCompras !=null )
            {
                var productosComprados = from detalleCompra in compra.DetalleCompras
                                         select new { id = detalleCompra.Producto.Id, nombre = detalleCompra.Producto.Nombre, precio = detalleCompra.PrecioCompra, cantidad = detalleCompra.Cantidad, total = detalleCompra.Total };
                gridDetalleCompras.DataSource = productosComprados.ToList();
            }
        }

        private void cargarComboProductos(int idSeleccionar)
        {
            cboProductos.DataSource = db.Productos.ToList();
            cboProductos.DisplayMember = "Nombre";
            cboProductos.ValueMember = "Id";
            cboProductos.SelectedValue = idSeleccionar;

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Producto producto in db.Productos)
            {
                autoCompletadoCbo.Add(producto.Nombre);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboProductos.AutoCompleteCustomSource = autoCompletadoCbo;
        }

        private void cargarComboProveedor(int idSeleccionar)
        {
            cboProveedor.DataSource = db.Proveedores.ToList();
            cboProveedor.DisplayMember = "Razon_social";
            cboProveedor.ValueMember = "Id";
            cboProveedor.SelectedValue = idSeleccionar;

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Proveedor proveedor in db.Proveedores)
            {
                autoCompletadoCbo.Add(proveedor.Razon_social);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboProveedor.AutoCompleteCustomSource = autoCompletadoCbo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNuevoProveedor frmNuevoProveedor = new FrmNuevoProveedor();
            frmNuevoProveedor.ShowDialog();
            cargarComboProveedor(frmNuevoProveedor.proveedor.Id);
        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cboProveedor.SelectedIndex > -1 && 
                cboProveedor.SelectedValue.GetType()== typeof(Int32))
            {
                pnlDetalleCompra.Enabled = true;
            }
        }

        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = nudPrecio.Value * nudCantidad.Value;
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = nudPrecio.Value * nudCantidad.Value;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            detalleCompra = new DetalleCompra();
            detalleCompra.Producto = db.Productos.Find((int)cboProductos.SelectedValue);
            detalleCompra.ProductoId = (int)cboProductos.SelectedValue;
            detalleCompra.PrecioCompra = nudPrecio.Value;
            detalleCompra.Cantidad = nudCantidad.Value;
            detalleCompra.Total = nudTotal.Value;
            if (compra.DetalleCompras == null)
                compra.DetalleCompras = new ObservableCollection<DetalleCompra>();
            compra.DetalleCompras.Add(detalleCompra);
            actualizarGrilla();
            limpiarPanel();
            calcularTotales();
        }

        private void limpiarPanel()
        {
            cboProductos.SelectedValue=0;
            nudCantidad.Value = 0;
            nudPrecio.Value = 0;
            nudTotal.Value = 0;
            cboProductos.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string productoSeleccionado = (string)gridDetalleCompras.CurrentRow.Cells[1].Value;
            string mensaje = "¿Está seguro que desea eliminar el producto: " + productoSeleccionado + "?";
            string titulo = "Eliminación de un producto";
            DialogResult respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                int detalleSeleccionado = gridDetalleCompras.CurrentRow.Index;
                compra.DetalleCompras.RemoveAt(detalleSeleccionado);
                actualizarGrilla();
                calcularTotales();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int detalleSeleccionado = gridDetalleCompras.CurrentRow.Index;
            DetalleCompra detalleCompra = compra.DetalleCompras[detalleSeleccionado];
            cboProductos.SelectedValue = detalleCompra.Producto.Id;
            nudCantidad.Value = detalleCompra.Cantidad;
            nudPrecio.Value = detalleCompra.PrecioCompra;
            nudTotal.Value = detalleCompra.Total;
            compra.DetalleCompras.RemoveAt(detalleSeleccionado);
            actualizarGrilla();
            calcularTotales();
        }

        private void calcularTotales()
        {
            float total = 0;
            foreach(DetalleCompra detalleCompra in compra.DetalleCompras)
            {
                total += (float)detalleCompra.Total;
            }
            compra.Total = (decimal)total;
            compra.Subtotal = Convert.ToDecimal(total / 1.21);
            compra.Iva = compra.Total-compra.Subtotal;
            txtNetoGravado.Text = compra.Subtotal.ToString();
            txtIva.Text = compra.Iva.ToString();
            txtTotal.Text = compra.Total.ToString();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = db.Proveedores.Find(cboProveedor.SelectedValue);
            compra.Proveedor = proveedor;
            compra.ProveedorId = proveedor.Id;
            compra.Fecha = dtpFecha.Value;
            compra.Usuario = FrmMenuPrincipal.usuario;
            db.Compras.Add(this.compra);
            db.SaveChanges();
            
            this.Close();
        }


    }
}
