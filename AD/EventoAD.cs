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
    public class EventoAD
    {
        #region Evento
        public List<EventoEN> clsEventos()
        {
            EventoEN eventoEN = new EventoEN();
            List<EventoEN> listado = new List<EventoEN>();
            HttpClient clienteHttp = new HttpClient();

            try
            {
                clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
                var request = clienteHttp.GetAsync("api/Evento").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    listado = JsonConvert.DeserializeObject<List<EventoEN>>(resultString);
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

        public int crearEvento(EventoEN eventoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(eventoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PostAsync("http://isasistencia.azurewebsites.net/api/Evento", content).Result;

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

        public int eliminarEvento(int idEvento)
        {
            HttpClient clienteHttp = new HttpClient();

            try
            {
                clienteHttp.BaseAddress = new Uri("http://isasistencia.azurewebsites.net/");
                var request = clienteHttp.DeleteAsync("api/Evento?idEvento=" + idEvento).Result;

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

        public int actualizarEvento(EventoEN eventoEN)
        {
            HttpClient clienteHttp = new HttpClient();
            var json = JsonConvert.SerializeObject(eventoEN);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            try
            {
                var result = clienteHttp.PutAsync("http://isasistencia.azurewebsites.net/api/Evento", content).Result;

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
        #endregion
    }
}
