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
    public class CursoLN
    {
        #region Curso
        public int gridCurso(GridView grid)
        {

            CursoAD cursoAD = new CursoAD();

            if (cursoAD.clsCursos() != null)
            {
                grid.DataSource = cursoAD.clsCursos();
                grid.DataBind();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int crearCurso(CursoEN cursoEN)
        {

            CursoAD cursoAD = new CursoAD();
            return cursoAD.crearCurso(cursoEN);
        }

        public int eliminarCurso(int idCurso)
        {
            CursoAD cursoAD = new CursoAD();
            return cursoAD.eliminarCurso(idCurso);
        }

        public int actualizarCurso(CursoEN cursoEN)
        {
            CursoAD cursoAD = new CursoAD();
            return cursoAD.actualizarCurso(cursoEN);
        }

        public void dropCatedratico(DropDownList drop)
        {
            CursoAD cursoAD = new CursoAD();
            drop.ClearSelection(); 
            drop.Items.Clear();  
            drop.AppendDataBoundItems = true; 
            drop.Items.Add("<< Elija Catedratico >>"); 
            drop.Items[0].Value = "0";
            drop.DataSource = cursoAD.comboCatedratico();
            drop.DataTextField = "Catedratico"; 
            drop.DataValueField = "ID"; 
            drop.DataBind();
        }
        #endregion
    }
}
