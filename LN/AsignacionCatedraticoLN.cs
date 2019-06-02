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
    public class AsignacionCatedraticoLN
    {
        #region AsigancionCatedratico
        public int crearAsignacionCatedratico(AsignacionCatedraticoEN asignacionCatedraticoEN)
        {
            AsignacionCatedraticoAD asignacionCatedraticoAD = new AsignacionCatedraticoAD();
            return asignacionCatedraticoAD.crearAsignacionCatedratico(asignacionCatedraticoEN);
        }

        public void gridAsignacionCatedratico(GridView grid, int id)
        {
            AsignacionCatedraticoAD asignacionCatedraticoAD = new AsignacionCatedraticoAD();
            grid.DataSource = asignacionCatedraticoAD.clsAsignaiconCatedratico(id);
            grid.DataBind();
        }
        #endregion
    }
}
