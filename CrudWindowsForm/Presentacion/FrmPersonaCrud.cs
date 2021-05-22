using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudWindowsForm.Models;

namespace CrudWindowsForm.Presentacion
{
    public partial class FrmPersonaCrud : Form
    {
        public int? id;
        PersonaCrud opersona = null;

        public FrmPersonaCrud(int? id=null)
        {
            InitializeComponent();
            this.id =  id;
            if (id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            using (PruebaCityEntities1 db = new PruebaCityEntities1())
            {
                opersona = db.PersonaCrud.Find(id);
                txtCorreo.Text = opersona.correo;
                txtNombre.Text = opersona.nombre;
                FechaNacimiento.Value = opersona.fecha_nacimiento;
            }
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (PruebaCityEntities1 db = new PruebaCityEntities1())
            {

                PersonaCrud persona = new PersonaCrud();
                persona.nombre = txtNombre.Text;
                persona.correo = txtCorreo.Text;
                persona.fecha_nacimiento = FechaNacimiento.Value;

                

                db.PersonaCrud.Add(persona);
                db.SaveChanges();

                MessageBox.Show("Datos Guardados");
                this.Close();
                txtNombre.Text = "";
                txtCorreo.Text = "";
                FechaNacimiento.Text = "";
            }

        }

        private void FrmPersonaCrud_Load(object sender, EventArgs e)
        {

        }
    }
}
