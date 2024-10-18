using Hardware;
using Hardware.IO;
using System;

namespace VMS23
{
    public class CModIO
    {
        private HwIO_Module pIo;
        private TIoConfig[] mIn;
        private TIoConfig[] mOut;

        public bool IsOpen { get { return pIo.IsOpen; } }

        public string[] Group { get { return pIo.GroupList; } }

        public TIoConfig[] mInList { get { return mIn; } }
        public TIoConfig[] mOutList { get { return mOut; } }

        public double[] AInput => pIo.AInput;

        public CModIO()
        {
            pIo = new HwIO_Module();
        }

        // 종료시 thread loop를 종료시킨다.
        public void StopLoop()
        {
            pIo.IsLoop = false;          //  Read/Write 호출하는  thread loop 종료
        }

        // I/O moudle을 조회한다.
        public HwIO_Module GetIoModule()
        {
            return pIo;
        }

        private void _ParseList()
        {
            int inCnt = pIo.InList.Count;
            int outCnt = pIo.OutList.Count;

            mIn = new TIoConfig[inCnt];
            mOut = new TIoConfig[outCnt];

            for (int i = 0; i < inCnt; i++)
            {
                TIoConfig temp = new TIoConfig();
                temp.group = pIo.InList[i].group;
                temp.addr = pIo.InList[i].swAddr;
                temp.label = pIo.InList[i].label;
                temp.discrip = pIo.InList[i].discrip;
                mIn[i] = temp;

                if (inCnt == outCnt)
                {
                    TIoConfig temp2 = new TIoConfig();
                    temp2.group = pIo.OutList[i].group;
                    temp2.addr = pIo.OutList[i].swAddr;
                    temp2.label = pIo.OutList[i].label;
                    temp2.discrip = pIo.OutList[i].discrip;
                    mOut[i] = temp2;
                }
            }

            if (inCnt != outCnt)
            {
                for (int i = 0; i < outCnt; i++)
                {
                    TIoConfig temp = new TIoConfig();
                    temp.group = pIo.OutList[i].group;
                    temp.addr = pIo.OutList[i].swAddr;
                    temp.label = pIo.OutList[i].label;
                    temp.discrip = pIo.OutList[i].discrip;
                    mOut[i] = temp;
                }
            }
        }

        public int Open()
        {
            if (!pIo.Open())
            {
                return -1;
            }

            _ParseList();

            return 0;
        }

        public void Close()
        {
            if (pIo.IsOpen)
            {
                pIo.Close();
            }
        }

        public bool Get(EIo io)
        {
            bool ret = false;
            int swAddr = (int)io;

            //if ((int)io < Define.OUT_START_SWADDR)//MAX_BIT_COUNT)

            if (swAddr < Define.OUT_START_SWADDR)//MAX_BIT_COUNT)
            {
                // Input
                ret = pIo.GetIn(swAddr);
            }
            else
            {
                // Output
                ret = pIo.GetOut(swAddr);
            }

            return ret;
        }

        public string GetIO_Label(EIo io)
        {
            string ret = "";
            int swAddr = (int)io;

            if ((int)io < Define.MAX_BIT_COUNT)
            {
                // Input
                ret = pIo.GetInHwLabel(swAddr);
            }
            else
            {
                // Output
                ret = pIo.GetOutHwLabel(swAddr);
            }

            return ret;
        }

        public int GetI(EIo io)
        {
            return Convert.ToInt32(Get(io));
        }

        public byte[] GetBytes(EIo io)
        {
            int swAddr = (int)io;
            return pIo.GetBytes(swAddr);
        }

        public bool Set(EIo io)
        {
            bool ret = false;
            bool val = !Get(io);
            int swAddr = (int)io;

            if ((int)io < Define.MAX_BIT_COUNT)
            {
                // Input
                ret = pIo.SetIn(swAddr, val);
            }
            else
            {
                // Output
                ret = pIo.SetOut(swAddr, val);
            }

            return ret;
        }

        public bool Set(EIo io, ESet set)
        {
            bool val = (set == ESet.On);
            return Set(io, val);
        }

        public bool Set(EIo io, bool val)
        {
            bool ret = false;
            int swAddr = (int)io;

            if ((int)io < Define.MAX_BIT_COUNT)
            {
                // Input
                ret = pIo.SetIn(swAddr, val);
            }
            else
            {
                // Output
                ret = pIo.SetOut(swAddr, val);
            }
            return ret;
        }

        public bool Set(EIo[] ios, bool val)
        {
            bool ret = false;

            foreach (EIo io in ios)
            {
                int swAddr = (int)io;

                if ((int)io < Define.MAX_BIT_COUNT)
                {
                    // Input
                    ret = pIo.SetIn(swAddr, val);
                }
                else
                {
                    // Output
                    ret = pIo.SetOut(swAddr, val);
                }
            }
            return ret;
        }

        public bool And(params EIo[] ios)
        {
            int[] arr = new int[ios.Length];
            for (int i = 0; i < ios.Length; i++)
            {
                arr[i] = (int)ios[i];
            }

            return pIo.OperAnd(arr);
        }

        public bool Or(params EIo[] ios)
        {
            int[] arr = new int[ios.Length];
            for (int i = 0; i < ios.Length; i++)
            {
                arr[i] = (int)ios[i];
            }

            return pIo.OperOr(arr);
        }

        public bool All(bool val, params EIo[] ios)
        {
            int[] arr = new int[ios.Length];
            for (int i = 0; i < ios.Length; i++)
            {
                arr[i] = (int)ios[i];
            }

            return pIo.OperAll(val, arr);
        }

        public bool Any(bool val, params EIo[] ios)
        {
            int[] arr = new int[ios.Length];
            for (int i = 0; i < ios.Length; i++)
            {
                arr[i] = (int)ios[i];
            }

            return pIo.OperAny(val, arr);
        }

        public bool IPG_Position_Mapping(int nIPG_no, int nSet_no, double[] nCurrent_Val, double[] fSet_mm)
        {
            return pIo.IPG_Position_Mapping(nIPG_no,
                                        nSet_no,
                                        nCurrent_Val,
                                        fSet_mm);
        }
        public double IPG_Value_curr(int nIPG_no)
        {
            double curr_value = 0.0;
            curr_value = pIo.IPG_Value_curr(nIPG_no);
            return curr_value;
        }
        public double IPG_Value_mm(int nIPG_no)
        {
            double mm_value = 0.0;
            mm_value = pIo.IPG_Value_mm(nIPG_no);
            return mm_value;
        }

        public bool IPG_Para_Set(int nIPG_no, int nBuf, double fIBM_Value_mV, double fIBO_Value_mV, double fdiff_mm)
        {
            return pIo.IPG_Para_Set(nIPG_no,
                                    nBuf,
                                    fIBM_Value_mV,
                                    fIBO_Value_mV,
                                    fdiff_mm);
        }

        public bool IPG_Scan_Para_Set(int nIPG_no, int nBuf, int axis, double fstart_pos, double fend_pos, int nGetDelaytime, int nData_cnt, double fSet_val, double fHL_Filter)
        {
            return pIo.IPG_Scan_Para_Set(nIPG_no,
                                            nBuf,
                                            axis,
                                            fstart_pos,
                                            fend_pos,
                                            nGetDelaytime,
                                            nData_cnt,
                                            fSet_val,
                                            fHL_Filter);
        }
        public int IPG_Read(int nIPG_no, int nBuf, ref double fvalue)
        {
            double fData = 0.0;
            int nRet_code = pIo.IPG_Read(nIPG_no,
                                            nBuf,
                                            ref fData);
            fvalue = fData;
            return nRet_code;
        }
        //HJP211005_Vac값 읽어오기
        public double Vac_Value(int nStage)
        {
            double vac_value = 0.0;
            vac_value = pIo.Vac_Value(nStage);
            return vac_value;
        }
        //HJP211005_Load Cell값 읽어오기
        public double LoadCell_Value(int nStage)
        {
            double loadc_value = 0.0;
            loadc_value = Math.Round(pIo.LoadCell_Value(nStage), 1);
            return loadc_value;
        }
        //211227HJP Add Flow value
        public double TblFlow_Value(int nStage)
        {
            double tblflow = 0.0;
            tblflow = Math.Round(pIo.TblFlow_Value(nStage), 1);
            return tblflow;
        }
        public double Gwater_Value(int nStage)
        {
            double gwater = 0.0;
            gwater = Math.Round(pIo.SplGwater_Value(nStage), 1);
            return gwater;
        }
        public double Sidecln_Value(int nStage)
        {
            double sidecln = 0.0;
            sidecln = Math.Round(pIo.SideCln_Value(nStage), 1);
            return sidecln;
        }
        public double Whlcln_Value(int nStage)
        {
            double whlcln = 0.0;
            whlcln = Math.Round(pIo.WhlCln_Value(nStage), 1);
            return whlcln;
        }
        public double PCW_Value(int nStage)
        {
            double pcw = 0.0;
            pcw = Math.Round(pIo.PCW_Value(nStage), 1);
            return pcw;
        }
    }
}
