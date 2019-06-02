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
    public class EstudianteLN
    {
        EstudianteAD estudianteAD;

        public void gridEstudiante(GridView grid)
        {
            EstudianteAD estudianteAD = new EstudianteAD();
            grid.DataSource = estudianteAD.listarEstudiantes();
            grid.DataBind();
        }

        public int Insertar_Estudiante(EstudianteEN estudianteEN) //Ingreso del estudiante
        {
            estudianteAD = new EstudianteAD();
            return estudianteAD.Insertar_Estudiante(estudianteEN);
        }
    }
}
