
using System;
using System.Windows.Forms;

namespace WinFormApps
{
    static class WinFormsDemo
    {
        public const string appName = "My Windows Forms";
        public const string appVer = " v.1.0";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int xx = PromptOptions.ShowDialog(
                appName + appVer,
                "Please select an option:",
                "Options:",
                options: new String[]
                {
                    "1 This is a very long text - Option 1",
                    "2 This is a very long text - Option 2",
                    "3 This is a very long text - Option 3",
                    "4 This is a very long text - Option 4",
                    "5 This is a very long text - Option 5"
                });


            MessageBox.Show(xx.ToString());


            Application.Run(new Form1());
        }
    }
}
