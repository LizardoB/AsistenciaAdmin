using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class AsignacionEstudianteEN
    {
        public int IdAsignacionCatedratico;
        public int IdAsignacionEstudiante;
        public int IdEstudiante;

        public AsignacionEstudianteEN()
        {
        }

        public AsignacionEstudianteEN(int idAsignacionCatedratico, int idAsignacionEstudiante, int idEstudiante)
        {
            IdAsignacionCatedratico = idAsignacionCatedratico;
            IdAsignacionEstudiante = idAsignacionEstudiante;
            IdEstudiante = idEstudiante;
        }

        public int idAsignacionCatedratico { get { return IdAsignacionCatedratico; } set { IdAsignacionCatedratico = value; } }
        public int idAsignacionEstudiante { get { return IdAsignacionEstudiante; } set { IdAsignacionEstudiante = value; } }
        public int idEstudiante { get { return IdEstudiante; } set { IdEstudiante = value; } }
    }
}
