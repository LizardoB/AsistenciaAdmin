using EN;
using LN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsistenciaAdmin.Catedratico
{
    public partial class Catedratico : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            CatedraticoLN catedraticoLN = new CatedraticoLN();
            
            catedraticoLN.gridCatedratico(GridCatedratico);
            
        }

        #region EventosCatedratico
        protected void EliminarCatedratico(object sender, GridViewDeleteEventArgs e)
        {
            CatedraticoLN catedraticoLN = new CatedraticoLN();
            CatedraticoEN catedraticoEN = new CatedraticoEN();

            catedraticoEN.idCatedratico = Convert.ToInt32(GridCatedratico.Rows[e.RowIndex].Cells[2].Text);

            if (catedraticoLN.eliminarCatedratico(catedraticoEN.IdCatedratico) == 1)
            {
                string mensaje = "Eliminacion Exitosa";
                catedraticoLN.gridCatedratico(GridCatedratico);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            if (btnAgregar1.Text == "Agregar")
            {
                CatedraticoEN catedraticoEN = new CatedraticoEN();
                CatedraticoLN catedraticoLN = new CatedraticoLN();

                catedraticoEN.Nombres = txtNombres.Text;
                catedraticoEN.Apellidos = txtApellidos.Text;
                catedraticoEN.Email = txtEmail.Text;
                catedraticoEN.Usuario = txtUsuario.Text;
                catedraticoEN.Password = txtPassword.Text;

                
                if (catedraticoLN.crearCatedratico(catedraticoEN) == 1)
                {
                    string mensaje = "Ingreso Exitoso";
                    catedraticoLN.gridCatedratico(GridCatedratico);
                    txtNombres.Text = String.Empty;
                    txtApellidos.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    txtUsuario.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                }
            }
            else
            {
                CatedraticoEN catedraticoEN = new CatedraticoEN();
                CatedraticoLN catedraticoLN = new CatedraticoLN();

                catedraticoEN.IdCatedratico = Convert.ToInt32(txtIdCatedratico.Text);
                catedraticoEN.Nombres = txtNombres.Text;
                catedraticoEN.Apellidos = txtApellidos.Text;
                catedraticoEN.Email = txtEmail.Text;
                catedraticoEN.Usuario = txtUsuario.Text;
                catedraticoEN.Password = txtPassword.Text;

                
                if (catedraticoLN.actualizarCatedratico(catedraticoEN) == 1)
                {
                    string mensaje = "Modificación Exitosa";
                    catedraticoLN.gridCatedratico(GridCatedratico);
                    txtNombres.Text = String.Empty;
                    txtApellidos.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    txtUsuario.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                }
            }
        }

        protected void ActualizarCatedratico(object sender, EventArgs e)
        {
            btnAgregar1.Text = "Modificar";
            txtIdCatedratico.Text = GridCatedratico.SelectedRow.Cells[2].Text;
            txtNombres.Text = GridCatedratico.SelectedRow.Cells[3].Text;
            txtApellidos.Text = GridCatedratico.SelectedRow.Cells[4].Text; ;
            txtEmail.Text = GridCatedratico.SelectedRow.Cells[5].Text; ;
            txtUsuario.Text = GridCatedratico.SelectedRow.Cells[6].Text; ;
            txtPassword.Text = GridCatedratico.SelectedRow.Cells[7].Text; ;

            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "abrirModal", "abrirModal();", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdCatedratico.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtPassword.Text = String.Empty;
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
        }

        protected void GridCatedratico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignaciones")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridCatedratico.Rows[index];
                TableCell idCurso = selectedRow.Cells[2];
                AsignacionCatedraticoLN asignacionCatedraticoLN = new AsignacionCatedraticoLN();
                asignacionCatedraticoLN.gridAsignacionCatedratico(GridAsignacionesCatedratico, Convert.ToInt32(idCurso.Text));
                
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "abrirModal2", "abrirModal2();", true);
                
            }
        }
        #endregion
    }
}