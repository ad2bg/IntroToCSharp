using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Windows.Forms;
using CommonUtils;

namespace LoginForm
{
    static class Global
    {
        internal const string appName = "My App";
        internal const string appVer = " v. 1.0";

        internal static string datasource = "localhost";
        internal static int port = 3306;
        internal static string userName = "root";
        internal static string password = "tPJ(<E223{";


        public static void ExceptionMessageBox(this Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace.Left(500)}",
                appName + appVer + " - Error:",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
