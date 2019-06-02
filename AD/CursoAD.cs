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
    public class CursoAD
    {
        #region Curso
        ConexionBD conectar;
        public List<CursoEN> clsCursos()
        {
            CursoEN cursoEN = new CursoEN();
            List<CursoEN> listado = new List<CursoEN>();
            HttpClient clienteHttp = new HttpClient();

            try
            {
                clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
                var request = clienteHttp.GetAsync("api/Curso").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    listado = JsonConvert.DeserializeObject<List<CursoEN>>(resultString);
                    return listado;
                }
                else
                {
                    return listado = null;
                }
            }
            catch (Exception)
            {

                return listado = null;
            }

        }

        public int crearCurso(CursoEN cursoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(cursoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PostAsync("http://isasistencia.azurewebsites.net/api/Curso", content).Result;

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

        public int eliminarCurso(int idCurso)
        {
            HttpClient clienteHttp = new HttpClient();

            try
            {
                clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
                var request = clienteHttp.DeleteAsync("api/Curso?idCurso=" + idCurso).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                return 2;
            }
        }

        public int actualizarCurso(CursoEN cursoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(cursoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PutAsync("http://isasistencia.azurewebsites.net/api/Curso", content).Result;

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

        
        public DataTable comboCatedratico()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ComboCatedratico");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        #endregion
    }
}
