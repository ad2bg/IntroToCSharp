
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
using System.Configuration;
using MySql.Data.MySqlClient;



namespace LoginForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void usersBindingNavigatorSaveItem_Click(
            object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string connectionString =
                ConfigurationManager.
                ConnectionStrings
                ["LoginForm.Properties.Settings.databaseConnectionString"].
                ConnectionString;

            if (connectionString.Contains("password=XYXYXYXY"))
            {
                connectionString = connectionString.Replace(
                    "XYXYXYXY", $"{Global.password}");
            }
            else
            {
                connectionString += $"password={Global.password}";
            }

            var mySqlConn = new MySqlConnection(connectionString);
            mySqlConn.Open();

            // TODO: This line of code loads data into the 'databaseDataSet.users'
            // table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.databaseDataSet.users);


            mySqlConn.Close();
        }
    }
}
