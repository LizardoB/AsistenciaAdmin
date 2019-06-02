using AD;
using EN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LN
{
    public class AsignacionEstudianteLN
    {
        AsignacionEstudianteAD asignacionEstudianteAD;

        public void gridCiclo1(GridView grid)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            grid.DataSource = asignacionEstudianteAD.cursoCiclo1();
            grid.DataBind();
        }

        public void gridCiclo2(GridView grid)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            grid.DataSource = asignacionEstudianteAD.cursoCiclo2();
            grid.DataBind();
        }

        public void gridCiclo3(GridView grid)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            grid.DataSource = asignacionEstudianteAD.cursoCiclo3();
            grid.DataBind();
        }

        public void gridCiclo4(GridView grid)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            grid.DataSource = asignacionEstudianteAD.cursoCiclo4();
            grid.DataBind();
        }

        public void gridCiclo5(GridView grid)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            grid.DataSource = asignacionEstudianteAD.cursoCiclo5();
            grid.DataBind();
        }

        public void gridCiclo6(GridView grid)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            grid.DataSource = asignacionEstudianteAD.cursoCiclo6();
            grid.DataBind();
        }
        public int Insertar_AsignacionEstudiante(AsignacionEstudianteEN asignacionEstudianteEN) //Ingreso del estudiante
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            return asignacionEstudianteAD.Insertar_AsignacionEstudiante(asignacionEstudianteEN);
        }

        public DataTable FotografiaEstudiante(int ID)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            DataTable tabla2 = new DataTable();
            tabla2 = asignacionEstudianteAD.FotografiaEstudiante(ID);
            return tabla2;
        }

        public void ActualizarPersonID(int ID, string personId)
        {
            asignacionEstudianteAD = new AsignacionEstudianteAD();
            asignacionEstudianteAD.ActualizarPersonID(ID,personId);
        }
    }
}
