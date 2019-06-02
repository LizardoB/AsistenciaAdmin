using EN;
using LN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsistenciaAdmin.Curso
{
    public partial class CursoMostrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CursoLN cursoLN = new CursoLN();
            cursoLN.gridCurso(GridCurso);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            CursoLN cursoLN = new CursoLN();

            if (IsPostBack == false)
            {
                cursoLN.dropCatedratico(dropCatedratico);
            }

        }

        #region EventosCurso
        protected void EliminarCurso(object sender, GridViewDeleteEventArgs e)
        {
            CursoLN cursoLN = new CursoLN();
            CursoEN cursoEN = new CursoEN();

            cursoEN.IdCurso = Convert.ToInt32(GridCurso.Rows[e.RowIndex].Cells[3].Text);

            if (cursoLN.eliminarCurso(cursoEN.IdCurso) == 1)
            {
                string mensaje = "Eliminacion Exitosa";
                cursoLN = new CursoLN();
                if (cursoLN.gridCurso(GridCurso) != 0)
                {
                    cursoLN.gridCurso(GridCurso);
                }
                else
                {
                    cursoLN.gridCurso(null);
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (btnAgregar1.Text == "Agregar")
            {
                CursoEN cursoEN = new CursoEN();
                CursoLN cursoLN = new CursoLN();
                AsignacionCatedraticoEN asignacionCatedraticoEN = new AsignacionCatedraticoEN();

                cursoEN.Nombre = txtCurso.Text;
                cursoEN.Ciclo = Convert.ToInt32(dropCiclo.SelectedItem.Value);


                if (cursoLN.crearCurso(cursoEN) == 1)
                {
                    string mensaje = "Ingreso Exitoso";
                    cursoLN = new CursoLN();
                    cursoLN.gridCurso(GridCurso);
                    txtCurso.Text = String.Empty;
                    dropCiclo.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                }
            }
            else
            {
                CursoEN cursoEN = new CursoEN();
                CursoLN cursoLN = new CursoLN();

                cursoEN.IdCurso = Convert.ToInt32(txtIdCurso.Text);
                cursoEN.Nombre = txtCurso.Text;
                cursoEN.Ciclo = Convert.ToInt32(dropCiclo.SelectedItem.Value);


                if (cursoLN.actualizarCurso(cursoEN) == 1)
                {
                    string mensaje = "Modificación Exitosa";

                    cursoLN.gridCurso(GridCurso);
                    txtCurso.Text = String.Empty;
                    dropCiclo.SelectedIndex = 0;

                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                }
            }
        }

        protected void ActualizarCurso(object sender, EventArgs e)
        {
            btnAgregar1.Text = "Modificar";
            txtIdCurso.Text = GridCurso.SelectedRow.Cells[3].Text;
            txtCurso.Text = GridCurso.SelectedRow.Cells[4].Text;
            dropCiclo.SelectedIndex = Convert.ToInt32(GridCurso.SelectedRow.Cells[4].Text);

            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "abrirModal", "abrirModal();", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdCurso.Text = String.Empty;
            txtCurso.Text = String.Empty;
            dropCiclo.SelectedIndex = 0;
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
        }
        #endregion

        #region EventosAsiganacion
        protected void CancelarAsigancion(object sender, EventArgs e)
        {
            txtIdCurso2.Text = String.Empty;
            txtCurso2.Text = String.Empty;
            dropCatedratico.SelectedIndex = 0;
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal2", "cerrarModal2();", true);
        }

        protected void AgregarAsignacion(object sender, EventArgs e)
        {
            AsignacionCatedraticoLN asignacionCatedraticoLN = new AsignacionCatedraticoLN();
            AsignacionCatedraticoEN asignacionCatedraticoEN = new AsignacionCatedraticoEN();
            
            asignacionCatedraticoEN.IdCurso = Convert.ToInt32(txtIdCurso2.Text);
            asignacionCatedraticoEN.Annio = DateTime.Now.Year.ToString();
            asignacionCatedraticoEN.IdCatedratico = Convert.ToInt32(dropCatedratico.SelectedValue);
            string cadena = txtCurso2.Text;
            string personGrupId = cadena.Replace(" ", "") + asignacionCatedraticoEN.Annio;
            string userData = cadena + " " + asignacionCatedraticoEN.Annio;
            
            MakeRequest(personGrupId.ToLower(), userData);

            asignacionCatedraticoEN.personGroupId = personGrupId.ToLower();


            if (asignacionCatedraticoLN.crearAsignacionCatedratico(asignacionCatedraticoEN) == 1)
            {
                string mensaje = "Asigancion Exitosa";
                txtIdCurso2.Text = String.Empty;
                txtCurso2.Text = String.Empty;
                dropCatedratico.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal2", "cerrarModal2();", true);
            }
        }

        protected void GridCurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignacion")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridCurso.Rows[index];
                TableCell idCurso = selectedRow.Cells[3];
                TableCell nombreCurso = selectedRow.Cells[4];
                string id = idCurso.Text;
                string nombre = nombreCurso.Text;

                txtIdCurso2.Text = id;
                txtCurso2.Text = nombre;
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "abrirModal2", "abrirModal2();", true);
            }
        }
        #endregion

        #region AzureApis
        static async void MakeRequest(string personGrupId, string userData)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(personGrupId);
            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f79cd591035a4ffcb2a30b96c38a7532");

            var uri = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/" + queryString;
            HttpResponseMessage response;

            personGroupEN person = new personGroupEN();
            person.name = userData;
            person.userData = "UMG "+ userData;
            person.recognitionModel = "recognition_02";


            string json = JsonConvert.SerializeObject(person);
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(json);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
            }
        }
        #endregion
    }
}