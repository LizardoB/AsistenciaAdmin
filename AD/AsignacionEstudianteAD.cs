using EN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    public class AsignacionEstudianteAD
    {
        ConexionBD conectar;
        public DataTable cursoCiclo1()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec cursoCiclo1");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable cursoCiclo2()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec cursoCiclo2");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable cursoCiclo3()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec cursoCiclo3");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable cursoCiclo4()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec cursoCiclo4");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable cursoCiclo5()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec cursoCiclo5");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable cursoCiclo6()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec cursoCiclo6");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        
        public DataTable FotografiaEstudiante(int ID)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec FotografiaEstudiante " + ID + ";");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable ActualizarPersonID(int ID, string personId)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ActualizarPersonID " + ID + ", '"+   personId  +"';");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public int Insertar_AsignacionEstudiante(AsignacionEstudianteEN asignacionEstudianteEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(asignacionEstudianteEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PostAsync("http://isasistencia.azurewebsites.net/api/AsignacionEstudiante", content).Result;

                if (result.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return 2;
            }
        }
    }
}
