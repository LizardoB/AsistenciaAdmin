using EN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AD
{
    public class CatedraticoAD
    {
        public List<CatedraticoEN> clsCatedraticos()
        {
            CatedraticoEN catedraticoEN = new CatedraticoEN();
            List<CatedraticoEN> listado = new List<CatedraticoEN>();
            HttpClient clienteHttp = new HttpClient();

            try
            {
                clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
                var request = clienteHttp.GetAsync("api/Catedratico").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    listado = JsonConvert.DeserializeObject<List<CatedraticoEN>>(resultString);
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

        public int crearCatedratico(CatedraticoEN catedraticoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(catedraticoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PostAsync("http://isasistencia.azurewebsites.net/api/Catedratico", content).Result;

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


        public int eliminarCatedratico(int idCatedratico)
        {
            HttpClient clienteHttp = new HttpClient();

            try
            {
                clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
                var request = clienteHttp.DeleteAsync("api/Catedratico?idCatedratico=" + idCatedratico).Result;

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

        public int actualizarCatedratico(CatedraticoEN catedraticoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(catedraticoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PutAsync("http://isasistencia.azurewebsites.net/api/Catedratico", content).Result;

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
