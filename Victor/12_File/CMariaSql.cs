using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victor
{
    public class CMariaSql
    {
        #region Filed
        private static String connectionString; // 
        private static String database = "sw21";    // "연동db"; 
        private static String port = "3306";        //"포트이름"
        private static String server = "localhost"; //" 서버 이름"
        private static String user = "root";        //"내아이디"
        private static String password = "sw21";    // "패스워드"; 
        private static String filePath = GVar.PATH_CONFIG + "MariaDB.cfg";

        string sData0 = "";
        string sData1 = "";

        private List<string> axisHomeRows = new List<string>();
        private List<string> axisPosRows = new List<string>();
        private List<string> axisCmdRows = new List<string>();
        private List<string> spindleRows = new List<string>();
        private List<string> ioRows = new List<string>();
        //private List<EErr> errsList = new List<EErr>();
        #endregion

        #region Property
        private static CTime m_Delay = new CTime();
        public static bool IsConnect { set; get; } = false;         // DB 연결 여부
        public static int ConnectTryCount { set; get; } = 0;        // DB 연결 시도 횟수

        #region MysqlConnection
        public MySqlConnection Connection;
        public MySqlConnection ErrorConnection;
        public MySqlConnection IoConnection;
        public MySqlConnection MeasureRawdataConnection;
        public MySqlConnection MeasureValueConnection;
        public MySqlConnection ProductConnection;
        public MySqlConnection RunConnection;
        #endregion MysqlConnection


        //private MySqlCommand ErrorCommand = new MySqlCommand();
        #endregion

        public CMariaSql() { 
        }
    }
}
