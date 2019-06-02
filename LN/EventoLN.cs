using AD;
using EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LN
{
    public class EventoLN
    {
        #region Evento
        public int gridEvento(GridView grid)
        {

            EventoAD eventoAD = new EventoAD();

            if (eventoAD.clsEventos() != null)
            {
                grid.DataSource = eventoAD.clsEventos();
                grid.DataBind();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int crearEvento(EventoEN eventoEN)
        {

            EventoAD eventoAD = new EventoAD();
            return eventoAD.crearEvento(eventoEN);
        }

        public int eliminarEvento(int idEvento)
        {
            EventoAD eventoAD = new EventoAD();
            return eventoAD.eliminarEvento(idEvento);
        }

        public int actualizarEvento(EventoEN eventoEN)
        {
            EventoAD eventoAD = new EventoAD();
            return eventoAD.actualizarEvento(eventoEN);
        }
        #endregion
    }
}
