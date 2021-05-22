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
using CrudWindowsForm.Presentacion;

namespace CrudWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();  
        }




        #region HELPER
        private void Refrescar()
        {
            using (PruebaCityEntities1 db = new PruebaCityEntities1())
            {
                var lst = from d in db.PersonaCrud
                          select d;
                dataGridView1.DataSource = lst.ToList();

            }
        }
        #endregion

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentacion.FrmPersonaCrud oFrmPersona = new Presentacion.FrmPersonaCrud();
            oFrmPersona.ShowDialog();

            Refrescar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if(id!=null)
            {
                Presentacion.FrmPersonaCrud oFrmPersonaCrud = new Presentacion.FrmPersonaCrud(id);
                oFrmPersonaCrud.ShowDialog();
            }
        }
    }
}
