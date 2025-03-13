using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor
{
    public partial class Sequence_00
    {
        public Sequence_00() 
        {
            Console.WriteLine("Sequence 00 Start");
        }
         ~Sequence_00() 
        { 
        }

        static int nExeCnt = 0;
        public void Sequence_Run()
        {
            Console.WriteLine($"{Utils.Now()} : 00 Sequence_Run {nExeCnt}");
            if (nExeCnt > 1000) nExeCnt = 0; else nExeCnt++;
        }
    }
}
