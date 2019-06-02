using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class EstudianteEN
    {
        int IdEstudiante;
        string Nombres;
        string Apellidos;
        string Api_Id;
        byte[] Fotografia;
        string PersonId;

        public EstudianteEN()
        {
        }

        public EstudianteEN(int idEstudiante, string nombres, string apellidos, string api_Id, byte[] fotografia, string personId)
        {
            IdEstudiante = idEstudiante;
            Nombres = nombres;
            Apellidos = apellidos;
            Api_Id = api_Id;
            Fotografia = fotografia;
            PersonId = personId;
        }



        public int idEstudiante { get { return IdEstudiante; } set { IdEstudiante = value; } }
        public string nombres { get { return Nombres; } set { Nombres = value; } }
        public string apellidos { get { return Apellidos; } set { Apellidos = value; } }
        public byte[] fotografia { get { return Fotografia; } set { Fotografia = value; } }
        public string api_Id { get { return Api_Id; } set { Api_Id = value; } }
        public string personId { get { return PersonId; } set { PersonId = value; } }
    }
}
