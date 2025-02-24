
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Victor
{
    public class CMariaSqlHelper
    {
        private readonly string connectionString;
        private MySqlConnection connection;

        public CMariaSqlHelper(string server, string database, string user, string password)
        {
            connectionString = $"Server={server};Database={database};User ID={user};Password={password};SslMode=none;";
            connection = new MySqlConnection(connectionString);
        }

        // 연결 열기
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // 연결 닫기
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Create
        public void Insert(string query)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        // Read
        public DataTable Select(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        // Update
        public void Update(string query)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        // Delete
        public void Delete(string query)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        // Batch Execute
        public void ExecuteBatchCommands(params string[] queries)
        {
            try
            {
                OpenConnection();
                foreach (string query in queries)
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        /*
         /// Example
        public partial class MainForm : Form
        {
            private DatabaseManager dbManager;

            public MainForm()
            {
                InitializeComponent();
                dbManager = new DatabaseManager("서버주소", "데이터베이스명", "사용자명", "비밀번호");
            }

            private void insertButton_Click(object sender, EventArgs e)
            {
                string query = "INSERT INTO 테이블명 (컬럼1, 컬럼2) VALUES ('값1', '값2')";
                dbManager.Insert(query);
                MessageBox.Show("데이터가 삽입되었습니다.");
            }

            private void selectButton_Click(object sender, EventArgs e)
            {
                string query = "SELECT * FROM 테이블명";
                DataTable dataTable = dbManager.Select(query);
                // 데이터 테이블을 DataGridView에 바인딩
                dataGridView.DataSource = dataTable;
            }

            private void updateButton_Click(object sender, EventArgs e)
            {
                string query = "UPDATE 테이블명 SET 컬럼1='새값' WHERE 조건";
                dbManager.Update(query);
                MessageBox.Show("데이터가 업데이트되었습니다.");
            }

            private void deleteButton_Click(object sender, EventArgs e)
            {
                string query = "DELETE FROM 테이블명 WHERE 조건";
                dbManager.Delete(query);
                MessageBox.Show("데이터가 삭제되었습니다.");
            }


        }
        */

    }
}
