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
    public partial class FrmListadoCategorias : Form
    {
        RotiseriaDesktopContext db = new RotiseriaDesktopContext();
        public FrmListadoCategorias()
        {

            InitializeComponent();
        }

        private void FrmListadoCategorias_Load(object sender, EventArgs e)
        {
            var Categorias = from categoria in db.Categorias
                             select new
                             {
                                 Id = categoria.Id,
                                 Nombre = categoria.Nombre
                             };
            CategoriaBindingSource.DataSource = Categorias.ToList();
                                this.reportViewer1.RefreshReport();
        }
    }
}
