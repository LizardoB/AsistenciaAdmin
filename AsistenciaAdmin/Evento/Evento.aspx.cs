using EN;
using LN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsistenciaAdmin.Evento
{
    public partial class Evento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EventoLN eventoLN = new EventoLN();
            eventoLN.gridEvento(GridEvento);
        }

        #region EventosEvento
        protected void EliminarEvento(object sender, GridViewDeleteEventArgs e)
        {
            EventoLN eventoLN = new EventoLN();
            EventoEN eventoEN = new EventoEN();

            eventoEN.IdEvento = Convert.ToInt32(GridEvento.Rows[e.RowIndex].Cells[3].Text);

            if (eventoLN.eliminarEvento(eventoEN.IdEvento) == 1)
            {
                string mensaje = "Eliminacion Exitosa";
                eventoLN.gridEvento(GridEvento);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            if (btnAgregar1.Text == "Agregar")
            {
                EventoLN eventoLN = new EventoLN();
                EventoEN eventoEN = new EventoEN();

                eventoEN.Nombre = txtEvento.Text;
                eventoEN.Año = DateTime.Now.Year.ToString();


                if (eventoLN.crearEvento(eventoEN) == 1)
                {
                    string mensaje = "Ingreso Exitoso";
                    eventoLN.gridEvento(GridEvento);
                    txtEvento.Text = String.Empty;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                }
            }
            else
            {
                EventoLN eventoLN = new EventoLN();
                EventoEN eventoEN = new EventoEN();

                eventoEN.IdEvento = Convert.ToInt32(txtIdEvento.Text);
                eventoEN.Nombre = txtEvento.Text;


                if (eventoLN.actualizarEvento(eventoEN) == 1)
                {
                    string mensaje = "Modificación Exitosa";
                    eventoLN.gridEvento(GridEvento);
                    txtIdEvento.Text = String.Empty;
                    txtEvento.Text = String.Empty;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdEvento.Text = String.Empty;
            txtEvento.Text = String.Empty;
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
        }
        #endregion

        protected void GridEvento_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        

        protected void ActualizarEvento(object sender, EventArgs e)
        {

        }
    }
}