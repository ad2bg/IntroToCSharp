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

namespace LoginForm
{
    public partial class formEntry : Form
    {
        public formEntry()
        {
            InitializeComponent();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var connectionString =
                string.Concat(
                $"datasource={Global.datasource};port={Global.port};",
                $"username={Global.userName};password={Global.password}"
                );

            var sqlQuery =
                string.Concat(
                "insert into database.users",
                " (login, password, first_name, last_name, gender)",
                string.Format(
                    " values('{0}','{1}','{2}','{3}','{4}') ;",
                    txtLogin.Text,
                    txtPassword.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    rbMale.Checked ? "Male" :
                    (rbFemale.Checked ? "Female" : null))
                );
            try
            {
                var mySqlConn = new MySqlConnection(connectionString);

                var cmd = new MySqlCommand(sqlQuery, mySqlConn);

                mySqlConn.Open();

                var reader = cmd.ExecuteReader();
                MessageBox.Show("Saved.");
                while (reader.Read()) { }
            }
            catch (Exception ex)
            {
                ex.ExceptionMessageBox();
            }

        }
    }
}
