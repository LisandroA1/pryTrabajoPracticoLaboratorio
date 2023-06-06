using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryArroyoTP
{
    internal class clsLocalidad
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        private string nombre;

        private string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public clsLocalidad()
        {
            conector = new OleDbConnection(Properties.Settings.Default.CADENA);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Localidades";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[1];
            dc[0] = tabla.Columns["localidad"];
            tabla.PrimaryKey = dc;
        }

        public DataTable GetAll()
        {
            return tabla;
        }

        public string NombreLocalidad(int loc)
        {
            DataRow buscarfila = tabla.Rows.Find(loc);
            if (buscarfila != null)
            {
                nombre = buscarfila[1].ToString();
            }
            else
            {
                nombre = "";
            }
            return nombre;
        }
    }
}
