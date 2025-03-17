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
        protected delegate void FuncPointer();
        /// <summary>
        /// 다음 워크 함수를 담아두는 함수 포인터
        /// </summary>
        protected FuncPointer pNextFun = null; //Static으로 하면 안됩니다.

        private static TFlag pFlags = new TFlag();

        private enum mStep
        {
            Init,
            Init_Down,
            Init_down_Check,
            Init_End
        }

        private mStep mSeq_Step;

        public Sequence_02() 
        {
            Console.WriteLine("Sequence 01 Start");
            NextFun_Null();
        }
         ~Sequence_02() 
        {
            NextFun_Null();
        }
        private void NextFun_Null()
        {
            pNextFun = null;
        }
        #region Test 코드
        static int nExeCnt = 0;
        static int nExeCnt_01 = 0;
        static DateTime sOldTime;
        public void Sequence_Run()
        {
            TimeSpan span = DateTime.Now - sOldTime;
            if (span.TotalMilliseconds > 0) nExeCnt_01 = 0;

            CLog.Write(ELog.MAIN, $"{Utils.Now()} : 02 Sequence_Run {nExeCnt} ,  {nExeCnt_01} ");
            if (nExeCnt > 1000) nExeCnt = 0; else nExeCnt++;
            if (nExeCnt_01 > 1000) nExeCnt_01 = 0; else nExeCnt_01++;

            sOldTime = DateTime.Now;
        }
        #endregion

        private void Proc_Work_Doing()
        {
            switch (mSeq_Step)
            {
                case mStep.Init:
                    {
                    }
                    break;
                case mStep.Init_Down:
                    {
                    }
                    break;
                case mStep.Init_down_Check:
                    {
                    }
                    break;
                case mStep.Init_End:
                    {
                    }
                    break;

                default:
                    {
                    }
                    break;
            }
        }

        private void Proc_ServoOn_Check()
        {
            pNextFun = Proc_Work_Doing;
        }

        private void Proc_Start()
        {
            pNextFun = Proc_ServoOn_Check;
        }
        private void Proc_Error(int nError_NUm)
        {
            NextFun_Null();
        }

        private void Proc_Stop()
        {
            NextFun_Null();
        }
        private void Proc_EStop()
        {
            NextFun_Null();
        }

        public void Run()
        {
            //Set_UnitData();

            if (GConst.EqStatus == EQStatus.EMG_Status)
            {// 메인 상태가 비상정지 상태                
                Proc_EStop();
            }

            if ((GVar.mKeyCmd.bRun_flag == true) || (pFlags.run == true) || (pFlags.step == true) || (pFlags.stop == true))
            {
                // Auto Run을 지속적으로 할수 있도록 하는 구문
                if (GVar.mKeyCmd.bRun_flag == true)
                {
                    // 해당 프로세스의 모든 플레그를 활성화 시켜준다.
                    pFlags.run = pFlags.step = pFlags.stop = true;
                }
                // 스텝 플래그만 꺼지면, 즉시 정지가 아닌 진행중인 동작 완료 후 종료
                if ((pFlags.step == false) && (pFlags.stop == true))
                {
                    // 스탑 플래그 오프
                    pFlags.stop = false;
                    // 함수포인터에 스탑 함수 등록
                    pNextFun = Proc_Stop;
                }

                if ((pNextFun == null) && (pFlags.run == true))
                {
                    pNextFun = Proc_Start;
                }
                else if (pNextFun != null)
                {
                    pNextFun();
                }
            }
            else if (pFlags.init == true)
            {// 초기화 진행, 모터 올홈 
                // 함수포인터가 비워있으면, 시작 함수 등록
                // 비워있지 않다면, 함수포인터 실행
                if (pNextFun == null)
                {
                    pNextFun = Proc_Start;
                }
                else
                {
                    pNextFun();
                }
            }
            //else if (_flags.manual == true)
            //{// 메뉴얼 동작 실행 
            //    // 함수포인터가 비워있으면, 시작 함수 등록
            //    // 비워있지 않다면, 함수포인터 실행
            //    if (_nextWork == null)
            //    {
            //        _nextWork = _Proc_SelectManual;
            //    }
            //    else
            //    {
            //        _nextWork();
            //    }
            //}
            else
            {
                pNextFun = null;
            }
            //_Write_Cosole();
            //DTrace_Message();
        }
    }
}
