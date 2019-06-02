using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class CursoEN
    {
        public int IdCurso;
        public String Nombre;
        public int Ciclo;

        public CursoEN()
        {
        }

        public CursoEN(int idCurso, string nombres, int ciclo)
        {
            IdCurso = idCurso;
            Nombre = nombres;
            Ciclo = ciclo;
        }

        public int idCurso { get { return IdCurso; } set { IdCurso = value; } }
        public int ciclo { get { return Ciclo; } set { Ciclo = value; } }
        public String nombre { get { return Nombre; } set { Nombre = value; } }
    }
}
