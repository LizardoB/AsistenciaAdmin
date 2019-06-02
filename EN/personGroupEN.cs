using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class personGroupEN
    {
        string Name;
        string UserData;
        string RecognitionModel = "";

        public personGroupEN()
        {
        }
        

        public string name { get => Name; set => Name = value; }
        public string userData { get => UserData; set => UserData = value; }
        public string recognitionModel { get => RecognitionModel; set => RecognitionModel = value; }
    }
}
