using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor
{
    public partial class Sequence_02
    {
        public Sequence_02() 
        {
            Console.WriteLine("Sequence 01 Start");
        }
         ~Sequence_02() 
        { 
        }

        static int nExeCnt = 0;
        public void Sequence_Run()
        {
            Console.WriteLine($"{Utils.Now()} : 02 Sequence_Run {nExeCnt}");
            if (nExeCnt > 1000) nExeCnt = 0; else nExeCnt++;
        }

    }
}
