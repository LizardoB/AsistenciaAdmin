using EN;
using LN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsistenciaAdmin.Estudiante
{
    public partial class EstudianteIngreso : System.Web.UI.Page
    {

        EstudianteLN estudianteLN = new EstudianteLN();
        EstudianteEN estudianteEN = new EstudianteEN();

        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                estudianteLN.gridEstudiante(GridEstudiante);

            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region EstudianteEventos
        protected void AbrirNuevo(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "abrirModal", "abrirModal();", true);
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                estudianteEN = (EstudianteEN)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String(estudianteEN.fotografia);
                (e.Row.FindControl("Fotografia") as Image).ImageUrl = imageUrl;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            estudianteEN = new EstudianteEN();
            estudianteLN = new EstudianteLN();
            estudianteEN.nombres = txtNombres.Text;
            estudianteEN.apellidos = txtApellidos.Text;

            string cadena = TextBox1.Text;
            int sitioDeCorte = 22;
            string parte1 = cadena.Substring(0, sitioDeCorte);
            string parte2 = cadena.Substring(sitioDeCorte + 1);

            byte[] bytes = System.Convert.FromBase64String(parte2);
            estudianteEN.fotografia = bytes;



            if (estudianteLN.Insertar_Estudiante(estudianteEN) == 1)
            {
                string mensaje = "Ingreso Exitoso";
                estudianteLN.gridEstudiante(GridEstudiante);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);

            }
        }

        protected void GridEstudiante_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignacion")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridEstudiante.Rows[index];
                TableCell idCurso = selectedRow.Cells[1];
                TableCell nombreEst = selectedRow.Cells[2];
                TableCell apellidoEst = selectedRow.Cells[3];
                
                string id = idCurso.Text;
                string nombre = nombreEst.Text;
                string apellido = apellidoEst.Text;



                

                Response.Redirect("EstudianteAsignacion.aspx?ID=" + id + "&Nombres=" + nombre + "&Apellidos=" + apellido);


            }
        }

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtIdEstudiante.Text = String.Empty;
            TextBox1.Text = String.Empty;
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
        }
        #endregion

    }
}