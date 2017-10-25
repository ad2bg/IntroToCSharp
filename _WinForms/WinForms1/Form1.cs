using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using MySql.Data.MySqlClient;
using CommonUtils;

namespace WinForms1
{
    public partial class Form1 : Form
    {
        public const string appName = "My App";
        public const string appVer = " v. 1.0";
        public string userName = "root";
        public string password = "tPJ(<E223{";
        public int port = 3306;
        public string datasource = "localhost";

        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            string sqlQuery = "select * sakila.actor;";
            string connectionString =
                $"datasource={datasource};port={port};"+
                $"username={userName};password={password}";
            try
            {
                var myConn = new MySqlConnection(connectionString);
                var myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand =
                    new MySqlCommand(sqlQuery, myConn);
                var cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                var ds = new DataSet();

                MessageBox.Show("Connected.");
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace.Left(500)}",
                    appName + appVer + " - Error:",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                //throw;
            }
        }
    }
}
