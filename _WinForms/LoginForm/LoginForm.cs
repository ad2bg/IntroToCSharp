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


namespace LoginForm
{



    public partial class frmLogin : Form
    {

        /// <summary>
        /// Disable Close Button
        /// </summary>
        const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }



        public frmLogin()
        {
            InitializeComponent();
            MaximumSize = new Size(400, 150);
            Text = Global.appName + Global.appVer + " - Sign in:";
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            var connectionString =
                string.Concat(
                $"datasource={Global.datasource};port={Global.port};",
                $"username={Global.userName};password={Global.password}"
                );

            var sqlQuery =
                string.Concat(
                "select * from database.users",
                " where ",
                $"login='{txtUsername.Text}'",
                " and ",
                $" password='{txtPassword.Text}' ;"
                );

            try
            {
                var mySqlConn = new MySqlConnection(connectionString);

                var selectCommand = new MySqlCommand(sqlQuery, mySqlConn);

                mySqlConn.Open();

                var reader = selectCommand.ExecuteReader
                    (CommandBehavior.SequentialAccess);

                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    //MessageBox.Show(
                    //    "Username and password are correct.");
                    Hide();
                    var mainForm = new Form3();//new formEntry();
                    mainForm.ShowDialog();
                    Close();
                }
                else if (count > 1)
                {
                    MessageBox.Show(
                        "Duplicate username and password... Access denied.");
                }
                else
                {
                    MessageBox.Show("Username and password are invalid.");
                }

                mySqlConn.Close();
            }
            catch (Exception ex)
            {
                ex.ExceptionMessageBox();
            }
        }



        void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        void txtUsername_Enter(object sender, EventArgs e)
        {
            SelectAllOnEnter(sender, e);
        }

        void txtPassword_Enter(object sender, EventArgs e)
        {
            SelectAllOnEnter(sender, e);
        }

        /// <summary>
        /// WinForms - SelectAllOnEnter
        /// </summary>
        /// <remarks>
        /// Calls SelectAll asynchronously so it occurs after the Click event
        /// </remarks>
        /// <param name="sender">a Textbox control</param>
        /// <param name="e"></param>
        void SelectAllOnEnter(object sender, EventArgs e)
        {
            if (sender != null)
            BeginInvoke((Action)delegate { ((TextBox)sender).SelectAll(); });
        }



    }
}