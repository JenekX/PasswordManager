using System;
using System.Windows.Forms;
using Password.Classes;

namespace PasswordManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool needEnter = true;
            string password = string.Empty;

            if (!MainForm.IsPasswordsFileExists)
            {
                if (!InputPasswordForm.ExecuteCreateNew(null, out password))
                    return;

                var document = new PasswordDocument();
                document.CreateNew(password);
                try
                {
                    document.SaveAs(MainForm.PasswordsFileName);
                }
                catch
                {
                    return;
                }

                needEnter = false;
            }
            
            if (!needEnter || EnterForm.Execute(out password))
            {
                Application.Run(new MainForm(password));
            }
        }
    }
}