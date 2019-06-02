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
    public class CatedraticoLN
    {
        public int gridCatedratico(GridView grid)
        {

            CatedraticoAD catedraticoAD = new CatedraticoAD();

            if (catedraticoAD.clsCatedraticos() != null)
            {
                grid.DataSource = catedraticoAD.clsCatedraticos();
                grid.DataBind();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int crearCatedratico(CatedraticoEN catedraticoEN)
        {

            CatedraticoAD catedraticoAD = new CatedraticoAD();
            return catedraticoAD.crearCatedratico(catedraticoEN);
        }

        public int eliminarCatedratico(int idCatedratico)
        {
            CatedraticoAD catedraticoAD = new CatedraticoAD();
            return catedraticoAD.eliminarCatedratico(idCatedratico);
        }

        public int actualizarCatedratico(CatedraticoEN catedraticoEN)
        {
            CatedraticoAD catedraticoAD = new CatedraticoAD();
            return catedraticoAD.actualizarCatedratico(catedraticoEN);
        }
    }
}
