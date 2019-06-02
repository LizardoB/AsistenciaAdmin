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
    public class AsignacionCatedraticoAD
    {
        ConexionBD conectar;

        #region AsignacionCatedratico
        public int crearAsignacionCatedratico(AsignacionCatedraticoEN asignacionCatedraticoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(asignacionCatedraticoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PostAsync("http://isasistencia.azurewebsites.net/api/AsignacionCatedratico", content).Result;


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

        public DataTable clsAsignaiconCatedratico(int idCatedratico)
        {
            try
            {
                conectar = new ConexionBD();
                DataTable tabla = new DataTable();
                conectar.AbrirConexion();
                string strConsulta = string.Format("exec clsAsignacionCat '" + idCatedratico + "';");
                SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
                consulta.Fill(tabla);
                conectar.CerrarConexion();
                return tabla;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        #endregion
    }
}
