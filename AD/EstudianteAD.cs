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
    public class EstudianteAD
    {
        EstudianteEN estudianteEN = new EstudianteEN();

        public List<EstudianteEN> listarEstudiantes()
        {
            List<EstudianteEN> listado = new List<EstudianteEN>();

            HttpClient clienteHttp = new HttpClient();

            clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
            var request = clienteHttp.GetAsync("api/Estudiante").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<EstudianteEN>>(resultString);

            }

            return listado;
        }

        public int Insertar_Estudiante(EstudianteEN estudianteEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(estudianteEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PostAsync("http://isasistencia.azurewebsites.net/api/Estudiante", content).Result;

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
