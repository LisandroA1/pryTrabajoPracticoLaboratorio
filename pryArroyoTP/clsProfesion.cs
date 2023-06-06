using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;

namespace pryArroyoTP
{
    internal class clsProfesion
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public clsProfesion()
        {
            conector = new OleDbConnection(Properties.Settings.Default.CADENA);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Profesiones";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] dc = new DataColumn[1];
            dc[0] = tabla.Columns["profesion"];
            tabla.PrimaryKey = dc;
        }
        
        public DataTable GetAll()
        {
            return tabla;
        }

        public string NombreProfesion(int prof)
        {
            DataRow buscarfila = tabla.Rows.Find(prof);
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
