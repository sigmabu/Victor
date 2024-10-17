using System;
using System.Collections.Concurrent; // ConcurrentQueue
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Util
{
    public class Utils
    {
        /// <summary>
        /// Delay 함수
        /// </summary>
        /// <param name="iTime">밀리초 단위 설정</param>
        /// <returns></returns>
        public static DateTime Delay(int iTime)
        {

            DateTime dtNow = DateTime.Now;
            TimeSpan tSpan = new TimeSpan(0, 0, 0, 0, iTime);
            DateTime dtTar = dtNow.Add(tSpan);

            Application.DoEvents();
            while (dtTar >= dtNow)
            {
                Application.DoEvents();
                dtNow = DateTime.Now;
                Thread.Sleep(1);
            }

            return DateTime.Now;
        }

        /// <summary>
        /// 10진수 -> 4 Digit 16진수
        /// </summary>
        /// <param name="iSrc">10진수</param>
        /// <returns></returns>
        public static int HexStr2Int(string str)
        {
            int nstrlen = str.Length;
            string hex; int nRet = 0;
            for (int i = nstrlen - 1; i >= 0; i--)
            {
                hex = str.Substring(i, 1);
                nRet += (int)Hex2Int(hex) * (int)Math.Pow((double)16, nstrlen - i - 1);
            }
            return nRet;
        }

        public static int Hex2Int(string cHex)
        {
            switch (cHex)
            {
                case "F":
                case "f": return (15);
                case "E":
                case "e": return (14);
                case "D":
                case "d": return (13);
                case "C":
                case "c": return (12);
                case "B":
                case "b": return (11);
                case "A":
                case "a": return (10);
                case "9": return (9);
                case "8": return (8);
                case "7": return (7);
                case "6": return (6);
                case "5": return (5);
                case "4": return (4);
                case "3": return (3);
                case "2": return (2);
                case "1": return (1);
                default: return (0);
            }
        }
        /// <summary>
        /// 10진수 -> 4 Digit 16진수
        /// </summary>
        /// <param name="iSrc">10진수</param>
        /// <returns></returns>
        public static string IntToHex_4Digit(int iSrc)
        {
            string strHex = iSrc.ToString("X");

            if ((strHex.Length % 4) == 0) strHex = String.Format("{0}", strHex);
            else if ((strHex.Length % 3) == 0) strHex = String.Format("0{0}", strHex);
            else if ((strHex.Length % 2) == 0) strHex = String.Format("00{0}", strHex);
            else /*if (strHex.Length % 2 = 0)*/ strHex = String.Format("000{0}", strHex);

            return strHex;
        }
        /// <summary>
        /// 10진수 -> 16진수
        /// </summary>
        /// <param name="iSrc">10진수</param>
        /// <returns></returns>
        public static string ToHex(int iSrc)
        {
            string strHex = iSrc.ToString("X");
            if (strHex.Length % 2 != 0)
                strHex = String.Format("0{0}", strHex);

            return strHex;
        }

        /// <summary>
        /// 16진수 -> 10진수
        /// </summary>
        /// <param name="sSrc">16진수</param>
        /// <returns>Int32</returns>
        public static int ToDec(string sSrc)
        {
            return Convert.ToInt32(sSrc, 16);
        }

        /// <summary>
        /// 16진수 -> 10진수
        /// </summary>
        /// <param name="sSrc">16진수</param>
        /// <returns>Int64</returns>
        public static long ToLong(string sSrc)
        {
            return Convert.ToInt64(sSrc, 16);
        }

        /// <summary>
        /// string -> enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string src)
        {
            return (T)Enum.Parse(typeof(T), src);
        }

        /// <summary>
        /// string -> enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static object ToEnum(Type type, string src)
        {
            return Enum.Parse(type, src);
        }

        /// <summary>
        /// 소수점 제거 함수
        /// </summary>
        /// <param name="dSrc"></param>
        /// <param name="iIdx"></param>
        /// <returns></returns>
        public static double Truncate(double dSrc, int iIdx)
        {
            double dRet;
            dRet = dSrc * Math.Pow(10.0, iIdx);
            dRet = Math.Truncate(dRet);
            dRet = dRet / Math.Pow(10.0, iIdx);
            return dRet;
        }

        public static int ToInt(bool src)
        {
            return Convert.ToInt32(src);
        }

        public static int ToInt(string src, int def = 0)
        {
            int ret = def;
            return (int.TryParse(src, out ret)) ? ret : def;
        }

        public static float ToFloat(string src)
        {
            float ret = 0f;
            return (float.TryParse(src, out ret)) ? ret : 0f;
        }

        public static double ToDouble(string src)
        {
            double ret = 0f;
            return (double.TryParse(src, out ret)) ? ret : 0.0;
        }

        /// <summary>
        /// double 형 데이터 덧셈, 기본으로 소수점 5자리에서 반올림
        /// </summary>
        /// <param name="val1">값 1</param>
        /// <param name="val2">값 2</param>
        /// <param name="digits">반올림 소수점</param>
        /// <returns>결과</returns>
        public static double Add(double val1, double val2, int digits = 5)
        {
            return Math.Round(val1 + val2, digits);
        }

        /// <summary>
        /// double 형 데이터 뺄셈, 기본으로 소수점 5자리에서 반올림
        /// </summary>
        /// <param name="val1">값 1</param>
        /// <param name="val2">값 2</param>
        /// <param name="digits">반올림 소수점</param>
        /// <returns>결과</returns>
        public static double Sub(double val1, double val2, int digits = 5)
        {
            return Math.Round(val1 - val2, digits);
        }

        /// <summary>
        /// double 형 데이터 곱셈, 기본으로 소수점 5자리에서 반올림
        /// </summary>
        /// <param name="val1">값 1</param>
        /// <param name="val2">값 2</param>
        /// <param name="digits">반올림 소수점</param>
        /// <returns>결과</returns>
        public static double Mul(double val1, double val2, int digits = 5)
        {
            return Math.Round(val1 * val2, digits);
        }

        /// <summary>
        /// double 형 데이터 나눗셈(값 1 / 값 2), 기본으로 소수점 5자리에서 반올림
        /// </summary>
        /// <param name="val1">값 1</param>
        /// <param name="val2">값 2</param>
        /// <param name="remainder">나머지</param>
        /// <param name="digits">반올림 소수점</param>
        /// <returns>몫</returns>
        public static double Div(double val1, double val2, out double remainder, int digits = 5)
        {
            double quotient = Math.Round(val1 / val2, digits);
            remainder = Math.Round(val1 % val2, digits);
            return quotient;
        }

        /// <summary>
        /// double 형 데이터 나눗셈(값 1 / 값 2), 기본으로 소수점 5자리에서 반올림
        /// </summary>
        /// <param name="val1">값 1</param>
        /// <param name="val2">값 2</param>
        /// <param name="digits">반올림 소수점</param>
        /// <returns>몫</returns>
        public static double Div(double val1, double val2, int digits = 5)
        {
            return Math.Round(val1 / val2, digits); ;
        }

        /// <summary>
        /// 현재 시간의 문자열 획득
        /// </summary>
        /// <param name="tmFormat">시간 문자열 포맷</param>
        /// <returns>현재 시간 문자열</returns>
        public static string Now(string tmFormat = "yyyy-MM-dd HH:mm:ss fff")
        {
            return DateTime.Now.ToString(tmFormat);
        }

        /// <summary>
        /// 두 시간 문자열의 시간 차를 계산하여 문자열로 반환
        /// </summary>
        /// <param name="startTime">시작 시간 문자열</param>
        /// <param name="endTime">종료 시간 문자열</param>
        /// <returns>계산된 시간 차 문자열</returns>
        public static string TimeDiff(string startTime, string endTime)
        {
            try
            {
                DateTime dt1 = Convert.ToDateTime(startTime);
                DateTime dt2 = Convert.ToDateTime(endTime);
                TimeSpan ts = dt2 - dt1;
                return ts.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = ((MemberExpression)expr.Body);
            return body.Member.Name;
        }


        /// <summary>
        /// 설정된 +/- 제한 범위 검사 (최소 체크 단위 적용)
        /// </summary>
        /// <param name="dVal">검사 대상 값(측정값)</param>
        /// <param name="dSetVal">검사 기준 값(설정값)</param>
        /// <param name="dLimit">설정 제한 값, 0인 경우 검사하지 않고 true 반환</param>
        /// <param name="dMinCheckUnit">범위 검사 시 최소 검사 단위(mm)</param>
        /// <returns>true: 범위 내 OK, false: 범위 이탈</returns>
        public static bool Check_MinMax_Range(double dVal, double dSetVal, double dLimit, double dMinCheckUnit)
        {
            if (dLimit == 0)
            {
                return true; // 범위 검사하지 않는 옵션 설정값
            }

            bool bResult = true;
            double dLim = Math.Abs(dLimit);
            double dMin = Sub(dSetVal, dLim);
            double dMax = Add(dSetVal, dLim);

            if ((dVal < dMin) && (Sub(dMin, dVal) >= dMinCheckUnit))
            {
                bResult = false;
            }
            else if ((dVal > dMax) && (Sub(dVal, dMax) >= dMinCheckUnit))
            {
                bResult = false;
            }
            else
            {
                bResult = true;
            }

            return bResult;
        }

        /// <summary>
        /// 설정된 제한 범위 검사 (최소 체크 단위 적용)
        /// </summary>
        /// <param name="dVal">검사 대상 값(측정값)</param>
        /// <param name="dLimit">설정 제한 값, 0인 경우 검사하지 않고 true 반환</param>
        /// <param name="dMinCheckUnit">범위 검사 시 최소 검사 단위(mm)</param>
        /// <returns>true: 범위 내 OK, false: 범위 이탈</returns>
        public static bool Check_Limit(double dVal, double dLimit, double dMinCheckUnit)
        {
            if (dLimit == 0)
            {
                return true; // 범위 검사하지 않는 옵션 설정값
            }

            bool bResult = true;
            double dLim = Math.Abs(dLimit);

            if ((dVal > dLim) && (Sub(dVal, dLim) >= dMinCheckUnit))
            {
                bResult = false;
            }
            else
            {
                bResult = true;
            }

            return bResult;
        }

        /// <summary>
        /// 지정 값에 해당 자릿수에 1로 Set 되었는지 확인한다.
        /// </summary>
        /// <param name="nValue"></param>
        /// <param name="nDigit"></param>
        /// <returns>지정 자리에 1로 Set 되어있는지 여부</returns>
        public static bool IsMask(int nValue, int nDigit)
        {
            return (((byte)nValue >> nDigit) & 0x01) > 0;
        }

        /// <summary>
        /// 지정 값에 해당 자릿수에 1로 Set 지정해준다.
        /// </summary>
        /// <param name="nValue"></param>
        /// <param name="nDigit"></param>
        /// <returns>지정 자리에 1로 Set 하여 되돌려준다</returns>
        public static int SetMask(int nValue, int nDigit)
        {
            return nValue | (1 << nDigit);
        }

        /// <summary>
        /// 큐를 활용한 이동평균값 계산
        /// </summary>
        /// <param name="Q">기존 표본값 저장된 큐</param>
        /// <param name="N">
        /// 이동평균값 산출을 위한 표본 수량 (이동 평균값 계산에 사용될 큐 아이템 수량)
        /// 표본 데이터 수량이 N보다 작은 경우 현재 표본 데이터만으로 평균값 산출
        /// </param>
        /// <param name="dVal">신규 이동평균값 산출을 위해 기존 표본 데이터 큐(Q)에 신규 추가할 값</param>
        /// <param name="dN">기존 표본 데이터 큐(Q)에 신규 추가할 값의 횟수</param>
        /// <param name="digits">소숫점 이하 자릿수, Default : 5</param>
        /// <returns></returns>
        public static double MovingAvg(ref ConcurrentQueue<double> Q, int N, double dVal, int dN, int digits = 5)
        {
            if (Q == null)
            {
                return Math.Round(dVal, digits);
            }

            double result;
            int setCnt = N;
            int newCnt = dN;

            if (setCnt < 1)
            {
                setCnt = 1;
            }

            if (newCnt < 1)
            {
                newCnt = 1;
            }

            // 큐에 신규 데이터 추가
            while (0 < newCnt)
            {
                Q.Enqueue(dVal);
                newCnt--;
            }
            // 표본데이터 수량 만큼만 남기고 큐에서 방출
            while (setCnt < Q.Count)
            {
                Q.TryDequeue(out result);
            }

            return Math.Round(Q.Average(), digits);
        }
        /// <summary>
        /// Trace 로그 사용 방법 : message = "" + ""  ~~
        /// </summary>
        /// <param name="message"></param>
        /// <param name="allPathName"></param>
        /// <param name="memberName"></param>
        /// <param name="sourceFilePath"></param>
        /// <param name="sourceLineNumber"></param>
        public static void TRACE(string message,
           [CallerFilePathAttribute] string allPathName = null,
           [CallerMemberName] string memberName = null,
           [CallerFilePath] string sourceFilePath = null,
           [CallerLineNumber] int sourceLineNumber = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(DateTime.Now);
            builder.Append(", callPath = ");
            builder.Append(allPathName + "\\");
            builder.Append(memberName + "(line = ");
            builder.Append(sourceLineNumber + "), ");
            builder.Append(message);
            Trace.WriteLine(builder);
        }
        public static bool Inbound(double dsrc_val, double dref_val, double dLimit = 5.0)
        {
            return (Math.Abs(dsrc_val - dref_val) <= dLimit) ? true : false;
        }

        /// <summary>
        /// true : dL_Limit <= dsrc_val <= dH_Limit
        /// </summary>
        /// <param name="dsrc_val"></param>
        /// <param name="dL_Limit"></param>
        /// <param name="dH_Limit"></param>
        /// <param name=""></param>
        /// <returns></returns>

        public static bool InRange(double dsrc_val, double dL_Limit, double dH_Limit)
        {
            if (dsrc_val < dL_Limit) return false;
            else if (dsrc_val > dH_Limit) return false;
            else return true;

        }
    }
}
