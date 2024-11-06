using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor
{
    public class HW
    {
        public static HardWare.Ctrl_AjinMot mMot = new HardWare.Ctrl_AjinMot(GVar.PATH_EQUIP_MotorList);
        public static HardWare.Ctrl_AjinIo mIo = new HardWare.Ctrl_AjinIo(GVar.PATH_EQUIP_MotorList);

    }
}
