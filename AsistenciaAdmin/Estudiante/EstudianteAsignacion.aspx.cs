using EN;
using LN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsistenciaAdmin.Estudiante
{
    public partial class EstudianteAsignacion : System.Web.UI.Page
    {

        List<String> cursos = new List<String>();
        DataTable dt = new DataTable();
        AsignacionEstudianteLN asignacionEstudianteLN;
        AsignacionEstudianteEN asignacionEstudianteEN;
        
        class PersonCreateResponse
        {
            public string PersonId { get; set; }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                asignacionEstudianteLN = new AsignacionEstudianteLN();

                asignacionEstudianteLN.gridCiclo1(GridCiclo1);
                asignacionEstudianteLN.gridCiclo2(GridCiclo2);
                GridAsignaciones.DataSource = dt;
                DataTable foto = asignacionEstudianteLN.FotografiaEstudiante(Convert.ToInt32(txtIDE.Text));
                DataRow row = foto.Rows[0];
                var fotografia = row["Fotografia"];

                byte[] bytes = (byte[])row["Fotografia"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                hdfFoto.Value = base64String;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string IDE = Request.QueryString["ID"];
            txtIDE.Text = IDE;
            string nombres = Request.QueryString["Nombres"];
            string apellidos = Request.QueryString["Apellidos"];
            txtNombres.Text = nombres + " " + apellidos;
        }

        #region CheckBoxEventos
        protected void CheckBox_ChangedCiclo1(object sender, EventArgs e)
        {
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ID"), new DataColumn("Curso"), new DataColumn("personGroupId") });

            foreach (GridViewRow row in GridCiclo1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[2].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = System.Drawing.Color.Green;
                        row.ForeColor = System.Drawing.Color.White;
                        string name = row.Cells[0].Text;
                        string curso = row.Cells[1].Text; ;
                        string pgid = row.Cells[2].Text; ;
                        dt.Rows.Add(name, curso, pgid);
                    }
                    else
                    {
                        row.BackColor = System.Drawing.Color.Empty;
                        row.ForeColor = System.Drawing.Color.Empty;
                    }
                }
            }
            GridAsignaciones.DataSource = dt;
            GridAsignaciones.DataBind();
        }

        protected void CheckBox_ChangedCiclo2(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("Curso") });

            foreach (GridViewRow row in GridCiclo2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[2].FindControl("chkRow2") as CheckBox);
                    if (chkRow.Checked)
                    {
                        row.BackColor = System.Drawing.Color.Green;
                        row.ForeColor = System.Drawing.Color.White;
                        string name = row.Cells[0].Text;
                        string curso = row.Cells[1].Text; ;
                        dt.Rows.Add(name, curso);
                    }
                    else
                    {
                        row.BackColor = System.Drawing.Color.Empty;
                        row.ForeColor = System.Drawing.Color.Empty;
                    }
                }
            }
            GridAsignaciones2.DataSource = dt;
            GridAsignaciones2.DataBind();
        }

        protected void CheckBox_ChangedCiclo3(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("Curso") });

            foreach (GridViewRow row in GridCurso3.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow3 = (row.Cells[2].FindControl("chkRow3") as CheckBox);
                    if (chkRow3.Checked)
                    {
                        row.BackColor = System.Drawing.Color.Green;
                        row.ForeColor = System.Drawing.Color.White;
                        string name = row.Cells[0].Text;
                        string curso = row.Cells[1].Text; ;
                        dt.Rows.Add(name, curso);
                    }
                    else
                    {
                        row.BackColor = System.Drawing.Color.Empty;
                        row.ForeColor = System.Drawing.Color.Empty;
                    }
                }
            }
            GridAsignaciones3.DataSource = dt;
            GridAsignaciones3.DataBind();
        }

        protected void CheckBox_ChangedCiclo4(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("Curso") });

            foreach (GridViewRow row in GridCiclo4.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow4 = (row.Cells[2].FindControl("chkRow4") as CheckBox);
                    if (chkRow4.Checked)
                    {
                        row.BackColor = System.Drawing.Color.Green;
                        row.ForeColor = System.Drawing.Color.White;
                        string name = row.Cells[0].Text;
                        string curso = row.Cells[1].Text; ;
                        dt.Rows.Add(name, curso);
                    }
                    else
                    {
                        row.BackColor = System.Drawing.Color.Empty;
                        row.ForeColor = System.Drawing.Color.Empty;
                    }
                }
            }
            GridAsignaciones4.DataSource = dt;
            GridAsignaciones4.DataBind();
        }

        protected void CheckBox_ChangedCiclo5(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("Curso") });

            foreach (GridViewRow row in GridCiclo5.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow5 = (row.Cells[2].FindControl("chkRow5") as CheckBox);
                    if (chkRow5.Checked)
                    {
                        row.BackColor = System.Drawing.Color.Green;
                        row.ForeColor = System.Drawing.Color.White;
                        string name = row.Cells[0].Text;
                        string curso = row.Cells[1].Text; ;
                        dt.Rows.Add(name, curso);
                    }
                    else
                    {
                        row.BackColor = System.Drawing.Color.Empty;
                        row.ForeColor = System.Drawing.Color.Empty;
                    }
                }
            }
            GridAsignaciones5.DataSource = dt;
            GridAsignaciones5.DataBind();
        }
        #endregion

        #region EstudianteAsignaciónEvento
        protected void btnAgregar1_Click(object sender, EventArgs e)
        {
            asignacionEstudianteEN = new AsignacionEstudianteEN();
            asignacionEstudianteLN = new AsignacionEstudianteLN();

            if (GridAsignaciones != null)
            {
                foreach (GridViewRow row in GridAsignaciones.Rows)
                {
                    string id = row.Cells[0].Text;
                    string personGroupId = row.Cells[2].Text;
                    string personName = txtNombres.Text;
                    
                    asignacionEstudianteEN.idAsignacionCatedratico = Convert.ToInt32(id);
                    asignacionEstudianteEN.idEstudiante = Convert.ToInt32(txtIDE.Text);
                    
                    if (asignacionEstudianteLN.Insertar_AsignacionEstudiante(asignacionEstudianteEN) == 1)
                    {
                        string mensaje = "Ingreso Exitoso";
                        addPersonToGroup(personGroupId, personName);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                    }
                }
            }

            if (GridAsignaciones2 != null)
            {
                foreach (GridViewRow row in GridAsignaciones2.Rows)
                {
                    string id = row.Cells[0].Text;
                    string personGroupId = row.Cells[2].Text;
                    string personName = txtNombres.Text;

                    asignacionEstudianteEN.idAsignacionCatedratico = Convert.ToInt32(id);
                    asignacionEstudianteEN.idEstudiante = Convert.ToInt32(txtIDE.Text);

                    if (asignacionEstudianteLN.Insertar_AsignacionEstudiante(asignacionEstudianteEN) == 1)
                    {
                        string mensaje = "Ingreso Exitoso";
                        addPersonToGroup(personGroupId, personName);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                    }
                }
            }

            if (GridAsignaciones3 != null)
            {
                foreach (GridViewRow row in GridAsignaciones3.Rows)
                {
                    string id = row.Cells[0].Text;
                    string personGroupId = row.Cells[2].Text;
                    string personName = txtNombres.Text;

                    asignacionEstudianteEN.idAsignacionCatedratico = Convert.ToInt32(id);
                    asignacionEstudianteEN.idEstudiante = Convert.ToInt32(txtIDE.Text);

                    if (asignacionEstudianteLN.Insertar_AsignacionEstudiante(asignacionEstudianteEN) == 1)
                    {
                        string mensaje = "Ingreso Exitoso";
                        addPersonToGroup(personGroupId, personName);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                    }
                }
            }


            if (GridAsignaciones4 != null)
            {
                foreach (GridViewRow row in GridAsignaciones4.Rows)
                {
                    string id = row.Cells[0].Text;
                    string personGroupId = row.Cells[2].Text;
                    string personName = txtNombres.Text;

                    asignacionEstudianteEN.idAsignacionCatedratico = Convert.ToInt32(id);
                    asignacionEstudianteEN.idEstudiante = Convert.ToInt32(txtIDE.Text);

                    if (asignacionEstudianteLN.Insertar_AsignacionEstudiante(asignacionEstudianteEN) == 1)
                    {
                        string mensaje = "Ingreso Exitoso";
                        addPersonToGroup(personGroupId, personName);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                    }
                }
            }
            
            if (GridAsignaciones5 != null)
            {
                foreach (GridViewRow row in GridAsignaciones5.Rows)
                {
                    string id = row.Cells[0].Text;
                    string personGroupId = row.Cells[2].Text;
                    string personName = txtNombres.Text;

                    asignacionEstudianteEN.idAsignacionCatedratico = Convert.ToInt32(id);
                    asignacionEstudianteEN.idEstudiante = Convert.ToInt32(txtIDE.Text);

                    if (asignacionEstudianteLN.Insertar_AsignacionEstudiante(asignacionEstudianteEN) == 1)
                    {
                        string mensaje = "Ingreso Exitoso";
                        addPersonToGroup(personGroupId, personName);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                    }
                }
            }
        }
        #endregion

        #region EventosGroupId
        public async void addPersonToGroup(string personGroupId, string personName)
        {

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(personGroupId);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f79cd591035a4ffcb2a30b96c38a7532");

            var uri = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/" + queryString + "/persons?";
           
            personGroupPersonEN personGroupPerson = new personGroupPersonEN();
            personGroupPerson.name = personName;
            personGroupPerson.userData = "Estudiante";


            string json = JsonConvert.SerializeObject(personGroupPerson);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PersonCreateResponse>(content);
                var personId = result.PersonId;

                addFaceToPerson(personGroupId, personId, hdfFoto.Value);
            }
        }




        public async void addFaceToPerson(string groupid, string personid, string face)
        {

            var client = new HttpClient();
            var groupId = HttpUtility.ParseQueryString(groupid);
            var personId = HttpUtility.ParseQueryString(personid);

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f79cd591035a4ffcb2a30b96c38a7532");


            var uri = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/persongroups/" + groupId + "/persons/" + personId + "/persistedFaces?";

            HttpResponseMessage response;

            
            byte[] imageBytes = Convert.FromBase64String(face);


            using (ByteArrayContent content = new ByteArrayContent(imageBytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                
                response = await client.PostAsync(uri, content);

                asignacionEstudianteLN.ActualizarPersonID(Convert.ToInt32(txtIDE.Text), personid);
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
        #endregion
    }
}