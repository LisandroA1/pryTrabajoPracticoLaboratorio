using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryArroyoTP
{
    public partial class frmListado : Form
    {
        clsProfesion objProfesion;
        clsLocalidad objLocalidad;
        clsEncuesta objEncuesta;
        public frmListado()
        {
            InitializeComponent();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
             objProfesion = new clsProfesion();
             objLocalidad = new clsLocalidad();
             objEncuesta = new clsEncuesta();

            dgvListado.Columns.Add("Grilla", "GRILLA");

            DataTable tablaProfesion = objProfesion.GetAll();
            DataTable tablaLocalidad = objLocalidad.GetAll();
            DataTable tablaEncuesta = objEncuesta.GetAll();

            foreach (DataRow fila in tablaProfesion.Rows)
            {
                dgvListado.Columns.Add("Profesion", fila.ItemArray[1].ToString());
            }

            foreach (DataRow fila in tablaLocalidad.Rows)
            {
                dgvListado.Rows.Add(fila.ItemArray[1].ToString());
            }

            

            foreach (DataRow fila in tablaEncuesta.Rows  )
            {
                string Localidad = objLocalidad.NombreLocalidad(Convert.ToInt32(fila.ItemArray[0]));
                string Profesion = objProfesion.NombreProfesion(Convert.ToInt32(fila.ItemArray[1]));

                foreach (DataGridViewTextBoxColumn dcGrilla in dgvListado.Columns)
                {
                    if (Profesion == dcGrilla.HeaderText)
                    {
                        int posicionColumna = dcGrilla.Index;
                        foreach (DataGridViewRow drGrilla in dgvListado.Rows)
                        {
                            if (Localidad == drGrilla.Cells[0].Value.ToString())
                            {
                                int posicionFila = drGrilla.Index;
                                dgvListado.Rows[posicionFila].Cells[posicionColumna].Value = fila["cantidad"];
                            }

                        }
                    }
                }
            }

        }
    }
}
