using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class EventoEN
    {
        private int idEvento;
        private String nombre;
        private String año;
        

        public EventoEN()
        {
        }

        public EventoEN(int idEvento, string nombre, string año)
        {
            IdEvento = idEvento;
            Nombre = nombre;
            Año = año;
        }

        public int IdEvento { get => idEvento; set => idEvento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Año { get => año; set => año = value; }
    }
}
