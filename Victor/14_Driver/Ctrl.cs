using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor
{
    public class Ctrl
    {
        public static HardWare.Ctrl_Ajin mMotion = new HardWare.Ctrl_Ajin(GVar.PATH_EQUIP_MotorList);

    }
}
