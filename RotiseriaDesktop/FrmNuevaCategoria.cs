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
    public partial class FrmNuevaCategoria : Form
    {
        //propiedades
        RotiseriaDesktopContext db;
        Categoria categoria ;
        //constructor que no recibe parametros y se ejecuta cuando hacemos nuevo
        public FrmNuevaCategoria(RotiseriaDesktopContext dbEnviado)
        {
            InitializeComponent();
            categoria = new Categoria();
            db = dbEnviado;
        }

        //constructor que recibe parámetros y se ejecuta cuando hacemos el modificar
        public FrmNuevaCategoria(int idSeleccionado, RotiseriaDesktopContext dbEnviado)
        {
            InitializeComponent();
            db = dbEnviado;
            categoria = db.Categorias.Find(idSeleccionado);
            txtNombre.Text = categoria.Nombre;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            categoria.Nombre = txtNombre.Text;
            if(categoria.Id>0)
            {
                db.Entry(categoria).State = EntityState.Modified;
            }
            else
            {
                db.Categorias.Add(categoria);
            }
            db.SaveChanges();
            this.Close();
        }
    }
}
