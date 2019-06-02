using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class AsignacionCatedraticoEN
    {
        public int IdAsignacionCatedratico;
        public int IdCatedratico;
        public int IdCurso;
        public String Annio;
        public String PersonGroupId;
        public String Catedratico;
        public String Curso;

        public AsignacionCatedraticoEN()
        {

        }

        public AsignacionCatedraticoEN(int idAsignacionCatedratico, int idCatedratico, int idCurso, string annio, string personGroupId, String catedratico, String curso)
        {
            IdAsignacionCatedratico = idAsignacionCatedratico;
            IdCatedratico = idCatedratico;
            IdCurso = idCurso;
            Annio = annio;
            PersonGroupId = personGroupId;
            Catedratico = catedratico;
            Curso = curso;

        }

        public int idAsignacionCatedratico { get { return IdAsignacionCatedratico; } set { IdAsignacionCatedratico = value; } }
        public int idCatedratico { get { return IdCatedratico; } set { IdCatedratico = value; } }
        public int idCurso { get { return IdCurso; } set { IdCurso = value; } }
        public String annio { get { return Annio; } set { Annio = value; } }
        public String personGroupId { get { return PersonGroupId; } set { PersonGroupId = value; } }
        public String catedratico { get { return Catedratico; } set { Catedratico = value; } }
        public String curso { get { return Curso; } set { Curso = value; } }
    }
}
