using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Victor
{
    public class CMariadb
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

        #region MySqlCommand
        private MySqlCommand ErrorCommand = new MySqlCommand();
        private MySqlCommand IoCommand = new MySqlCommand();
        private MySqlCommand MeasureRawdataCommand = new MySqlCommand();
        private MySqlCommand MeasureValueCommand = new MySqlCommand();
        private MySqlCommand ProductCommand = new MySqlCommand();
        private MySqlCommand RunCommand = new MySqlCommand();
        #endregion MySqlCommand
        #endregion

        public CMariadb()
        {
            Initialize();
        }
        /// <summary>
        /// MariaDB 연결 및 SQL COMMAND 초기화
        /// </summary>
        public void Initialize()
        {
            try
            {
                OpenConnection();
                m_Delay.Set_Delay(10000);
                AlterTable();

                CLog.Write(ELog.MARIADB, "MariaDB Initialize 성공");
            }
            catch (Exception ex)
            {
                IsConnect = false;           // DB 연결 실패
                CLog.Write(ELog.MARIADB, "MariaDB Initialize 실패");
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
        }
        /// <summary>
        /// MariaDB 연결 종료
        /// </summary>
        public void Stop()
        {
            CloseConnection();
        }
        #region Common
        /// <summary>
        /// MariaDB 연결 MariaDB.cfg파일에서 연결정보 가져옴
        /// </summary>
        private bool OpenConnection()
        {
            try
            {
                FileInfo fI = new FileInfo(filePath);
                CIni m_Ini = new CIni(filePath);
                if (fI.Exists)
                {
                    server = m_Ini.Read("CONNECTION", "SERVER");
                    port = m_Ini.Read("CONNECTION", "PORT");
                    database = m_Ini.Read("CONNECTION", "DATABASE");
                    user = m_Ini.Read("CONNECTION", "USER");
                    password = m_Ini.Read("CONNECTION", "PASSWORD");


                    connectionString = "server=" + server
                                       + ";Port=" + port
                                       + ";database=" + database
                                       + ";user=" + user
                                       + ";password=" + password;

                    CreateConnection();
                    CreateError();
                    CreateIo();
                    CreateMeasureRawdata();
                    CreateMeasureValue();
                    CreateProduct();
                    CreateRun();


                    IsConnect = true;           // DB 연결 성공
                    CLog.Write(ELog.MARIADB, "DataBase연동 성공");
                }
                else
                {
                    IsConnect = false;           // DB 연결 실패
                    CLog.Write(ELog.MARIADB, "DataBase연동 실패_Configuration파일 확인 필요");
                }

                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("데이터베이스 서버에 연결할 수 없습니다.");
                        break;

                    case 1045:
                        MessageBox.Show("유저 ID 또는 Password를 확인해주세요.");
                        break;
                }

                IsConnect = false;           // DB 연결 실패
                return false;
            }
        }

        private void CreateConnection()
        {
            this.Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }        

        private void CreateError()
        {
            this.ErrorConnection = new MySqlConnection(connectionString);
            this.ErrorConnection.Open();
            ErrorCommand.Connection = this.ErrorConnection;
        }
        private void CreateIo()
        {
            this.IoConnection = new MySqlConnection(connectionString);
            this.IoConnection.Open();
            IoCommand.Connection = this.IoConnection;
        }
        private void CreateMeasureRawdata()
        {
            this.MeasureRawdataConnection = new MySqlConnection(connectionString);
            this.MeasureRawdataConnection.Open();
            MeasureRawdataCommand.Connection = this.MeasureRawdataConnection;
        }
        private void CreateMeasureValue()
        {
            this.MeasureValueConnection = new MySqlConnection(connectionString);
            this.MeasureValueConnection.Open();
            MeasureValueCommand.Connection = this.MeasureValueConnection;
        }
        private void CreateProduct()
        {
            this.ProductConnection = new MySqlConnection(connectionString);
            this.ProductConnection.Open();
            ProductCommand.Connection = this.ProductConnection;
        }
        private void CreateRun()
        {
            this.RunConnection = new MySqlConnection(connectionString);
            this.RunConnection.Open();
            RunCommand.Connection = this.RunConnection;
        }


        /// <summary>
        /// MariaDB 연결을 종료 Close
        /// </summary>
        private bool CloseConnection()
        {
            if (!IsConnect) return true;           // DB 연결이 되지 않았다면  수행 불필요

            try
            {
                //if (this.Connection == null || this.Connection.State == ConnectionState.Closed) return true;
                this.Connection.Close();
                this.ErrorConnection.Close();
                this.IoConnection.Close();
                this.MeasureRawdataConnection.Close();
                this.MeasureValueConnection.Close();
                this.ProductConnection.Close();
                this.RunConnection.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// SQL DBCommand 새로 생성
        /// </summary>
        public DbCommand CreateDbCommand(string cmdText = "")
        {
            MySqlCommand sqlCommand = new MySqlCommand(cmdText);
            sqlCommand.CommandType = CommandType.Text;
            //  sqlCommand.Connection = this.CreateDbConnection();

            return sqlCommand;
        }
        /// <summary>
        /// SQL 초기화시 DBCommand 초기화(생성)
        /// </summary>
        public void CreateDbCommand()
        {
            ErrorCommand.Connection = this.ErrorConnection;
            IoCommand.Connection = this.IoConnection;
            MeasureRawdataCommand.Connection = this.MeasureRawdataConnection;
            MeasureValueCommand.Connection = this.MeasureValueConnection;
            ProductCommand.Connection = this.ProductConnection;
            RunCommand.Connection = this.RunConnection;
        }
        /// <summary>
        /// SQL DBCommand에 Parameter설정 (추후삭제예정)
        /// </summary>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }
        /// <summary>
        /// DBCommand를 이용하여 SQL Insert (추후 삭제 예정)
        /// </summary>
        public int ExecuteNonQuery(DbCommand command)
        {
            int result = 0;

            try
            {
                if (this.Connection == null || this.Connection.State == ConnectionState.Closed)
                {
                    CreateConnection();
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    command.Connection = conn;
                    result = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// AxisPosCommand SQL Insert
        /// </summary>
        /// <summary>
        /// IoCommand SQL Insert
        /// </summary>
        public int IoExecuteNonQuery(string commandString)
        {
            int result = 0;
            try
            {
                if (IoCommand.Connection == null || IoCommand.Connection.State == ConnectionState.Closed)
                {
                    //CLog.Write(ELog.MARIADB, "[IoExecuteNonQuery] IoCommand Connection 상태이상");
                    //return result;
                    CreateIo();
                }

                this.IoCommand.CommandText = commandString;
                result = this.IoCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// ErrorCommand SQL Insert
        /// </summary>
        public int ErrorExecuteNonQuery(string commandString)
        {
            int result = 0;
            try
            {
                if (ErrorCommand.Connection == null || ErrorCommand.Connection.State == ConnectionState.Closed)
                {
                    //CLog.Write(ELog.MARIADB, "[ErrorExecuteNonQuery] ErrorCommand Connection 상태이상");
                    //return result;
                    CreateError();
                }

                this.ErrorCommand.CommandText = commandString;
                result = this.ErrorCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return result;
        }
        /// <summary>
        /// ProductCommand SQL Insert
        /// </summary>
        public int ProductExecuteNonQuery(string commandString)
        {
            int result = 0;
            try
            {
                if (ProductCommand.Connection == null || ProductCommand.Connection.State == ConnectionState.Closed)
                {
                    //CLog.Write(ELog.MARIADB, "[ProductExecuteNonQuery] ProductCommand Connection 상태이상");
                    //return result;
                }
                this.ProductCommand.CommandText = commandString;
                result = this.ProductCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return result;
        }
        /// <summary>
        ///  RunCommand SQL Insert
        /// </summary>
        public int RunExecuteNonQuery(string commandString)
        {
            int result = 0;
            try
            {
                if (RunCommand.Connection == null || RunCommand.Connection.State == ConnectionState.Closed)
                {
                    //CLog.Write(ELog.MARIADB, "[RunExecuteNonQuery] RunExecuteNonQuery Connection 상태이상");
                    //return result;
                    CreateRun();
                }
                this.RunCommand.CommandText = commandString;
                result = this.RunCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return result;
        }
        public DataTable ExecuteQuery(DbCommand selectCommand)
        {
            DataTable table = new DataTable();
            try
            {
                if (this.Connection == null || this.Connection.State == ConnectionState.Closed)
                {
                    CreateConnection();
                }
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    selectCommand.Connection = conn;
                    selectCommand.Connection.Open();
                    DbDataAdapter adapter = new MySqlDataAdapter(selectCommand as MySqlCommand);
                    adapter.Fill(table);
                    selectCommand.Connection.Close();
                }

            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return table;
        }
        /// <summary>
        /// SQL Update나 Select문 사용
        /// </summary>
        /// 
        public DataTable ProductExecuteQuery(string selectCommand)
        {
            DataTable table = new DataTable();
            try
            {
                if (ProductCommand.Connection == null || ProductCommand.Connection.State == ConnectionState.Closed)
                {
                    CreateProduct();
                    //CLog.Write(ELog.MARIADB, "[ProductExecuteQuery] ProductCommand Connection 상태이상");
                    //return table;
                }
                this.ProductCommand.CommandText = selectCommand;
                DbDataAdapter adapter = new MySqlDataAdapter(this.ProductCommand);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return table;
        }
        public DataTable ErrorExecuteQuery(string selectCommand)
        {
            DataTable table = new DataTable();
            try
            {
                if (ErrorCommand.Connection == null || ErrorCommand.Connection.State == ConnectionState.Closed)
                {
                    CreateError();
                    //CLog.Write(ELog.MARIADB, "[ErrorExecuteQuery] ErrorCommand Connection 상태이상");
                    //return table;
                }
                this.ErrorCommand.CommandText = selectCommand;
                DbDataAdapter adapter = new MySqlDataAdapter(this.ErrorCommand);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                CLog.Write(ELog.MARIADB, ex.ToString());
            }
            return table;
        }
        #endregion

        /// <summary>
        /// thread 상시
        /// </summary>
        public void Run()
        {
            //while (true)
            //{
            //lock (obj)
            //{
            if (m_Delay.Chk_Delay())
            {
                InsertInOutData();
                m_Delay.Set_Delay(1000);
            }
            //InsertAxisPosData();
            // }
            Thread.Sleep(10);
            // }
        }



        #region Inout
        /// <summary>
        /// [INOUT] in, out signal데이터를 실시간으로 Insert
        /// </summary>
        /// <param name="inOutData">임시 생성 추후삭제예정</param>
        public void InsertInOutData()
        {
            ioRows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}')",
                CData.EqStatus.ToString(), // 0 : EQ Status
                "", // 1 : IN00 (00 byte, 02 byte~31 byte)
                "", // 2 : IN01 (32byte~63byte)
                "", // 3 : OUT00 (00 byte, 02 byte~31 byte)
                "")); // 4 : OUT01 (32byte~63byte)

            if (ioRows.Count < 10) return;

            StringBuilder sCommand = new StringBuilder();
            sCommand.AppendFormat("INSERT INTO {0} (EQSTATUS, IN00, IN01, OUT00, OUT01) VALUES ", DbTableName.INOUTSIGNAL);
            sCommand.Append(string.Join(",", ioRows));
            sCommand.Append(";");

            this.IoExecuteNonQuery(sCommand.ToString());
            ioRows.Clear();
        }
        #endregion


        /// <summary>
        /// MariaDB 연결 종료, DEQUEUE용 Thread 종료
        /// </summary>
        public void AlterTable()
        {
            StringBuilder sb = new StringBuilder();
            DbCommand command = this.CreateDbCommand(sb.ToString());

            // Error테이블 comment 추가하기
            sb.AppendFormat("SELECT * FROM information_schema.`COLUMNS` WHERE table_schema = 'sw21' AND TABLE_NAME = 'error' AND COLUMN_NAME = 'DESCRIPTION'");

            command.CommandText = sb.ToString();
            DataTable table = this.ExecuteQuery(command);

            sb.Clear();

            if (0 == table.Rows.Count)
            {
                sb.AppendFormat("ALTER TABLE ERROR ADD DESCRIPTION VARCHAR(200) AFTER ERRORNAME");

                command = this.CreateDbCommand(sb.ToString());
                this.ExecuteNonQuery(command);
            }


            #region Wheel Table 생성하기
            sb.Clear();

            sb.AppendFormat("CREATE TABLE IF NOT EXISTS `wheel` (");
            sb.AppendFormat(" `IDX` int(11) NOT NULL AUTO_INCREMENT, ");
            sb.AppendFormat(" `M_ID` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `PRODUCT_DATE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `FACTORY_OUT_DATE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `FACTORY_OUT_SITE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP1` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP2` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `WHEEL_DATA` varchar(256) DEFAULT NULL, ");
            sb.AppendFormat(" `DIAMETER` varchar(10) DEFAULT NULL, ");
            sb.AppendFormat(" `MESH` varchar(10) DEFAULT NULL, ");
            sb.AppendFormat(" `WHEEL_IN_ID` varchar(10) DEFAULT NULL, ");
            sb.AppendFormat(" `WHEEL_FILE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `PARTNO` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `MASS_DATA` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `WORK_START_DATE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `WORK_END_DATE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `MACHINE_NO` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `RECIPENAME` varchar(256) DEFAULT NULL, ");
            sb.AppendFormat(" `STAGENO` varchar(2) DEFAULT NULL, ");
            sb.AppendFormat(" `STRIPID` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `WORK_EVENT` varchar(30) DEFAULT NULL, ");
            sb.AppendFormat(" `MAESURE_STEP` varchar(30) DEFAULT NULL, ");
            sb.AppendFormat(" `ZAXIS_POS` varchar(20) DEFAULT NULL, ");
            sb.AppendFormat(" `MAESURE_VALUE` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `MAESURE_MAX` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `LOSS` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `GRINDING_CNT` varchar(20) DEFAULT NULL, ");
            sb.AppendFormat(" `DRE_AFTER_CNT` varchar(20) DEFAULT NULL, ");
            sb.AppendFormat(" `DRESS_CNT` varchar(20) DEFAULT NULL, ");
            sb.AppendFormat(" `BEFORE_WHEEL_THICK` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `AFTER_WHEEL_THICK` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `BEFORE_STRIP_THICK` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `AFTER_STRIP_THICK` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `DRESSER_NAME` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `DRESSER_HEIGHT` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `DRESSER_LOSS` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP3` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP4` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP5` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP6` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `TEMP7` varchar(50) DEFAULT NULL, ");
            sb.AppendFormat(" `INSERTTIME` timestamp(4) NULL DEFAULT current_timestamp(4), ");
            sb.AppendFormat(" `UPDATETIME` timestamp NULL DEFAULT NULL, ");
            sb.AppendFormat(" KEY `IDX` (`IDX`)");
            sb.AppendFormat(") ENGINE = InnoDB AUTO_INCREMENT = 191 DEFAULT CHARSET = utf8; ");

            command = this.CreateDbCommand(sb.ToString());
            this.ExecuteNonQuery(command);
            #endregion Wheel Table 생성하기
        }
    }

}



public class RunData
{
    public string StripId { get; set; }
    public string LotId { get; set; }
    public int Mgz_Count { get; set; }
    public int Mgz_In_Slot_No { get; set; }
    public int Lot_In_Strip_No { get; set; }
    public string RecipeName { get; set; }
    public string EqStatus { get; set; }
}
public class ErrorData
{
    public string StripId { get; set; }
    public string LotId { get; set; }
    public string RecipeName { get; set; }
    public int ErrorNo { get; set; }
    public string ErrorName { get; set; }
    public DateTime SetTime { get; set; }
    public DateTime ReSetTime { get; set; }
    public int Lot_In_Count { get; set; }
    public int Strip_In_Count { get; set; }
}

public class AuxUnitData
{
    public string EqStatus { get; set; }
    public string Sg1_StripId { get; set; }
    public double Sg1_Stage_Vaccum { get; set; }
    public double Sg1_DI_Flow { get; set; }
    public double Sg1_DI_Temp { get; set; }
    public double Sg1_PCW_Flow { get; set; }
    public double Sg1_PCW_Temp { get; set; }
    public double Sg1_Spindle_Load_Cell { get; set; }
    public string Sg2_StripId { get; set; }
    public double Sg2_Stage_Vaccum { get; set; }
    public double Sg2_DI_Flow { get; set; }
    public double Sg2_DI_Temp { get; set; }
    public double Sg2_PCW_Flow { get; set; }
    public double Sg2_PCW_Temp { get; set; }
    public double Sg2_Spindle_Load_Cell { get; set; }

};
