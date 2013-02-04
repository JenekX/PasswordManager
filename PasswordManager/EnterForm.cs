using System.Windows.Forms;

namespace PasswordManager
{
    public partial class EnterForm : Form
    {
        private void RefreshUI()
        {
            btnOk.Enabled = Password.Length > 0;
        }

        private void TbPasswordTextChanged(object sender, System.EventArgs e)
        {
            RefreshUI();
        }

        public EnterForm()
        {
            InitializeComponent();

            RefreshUI();
        }

        public static bool Execute(out string password)
        {
            using (var form = new EnterForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    password = form.Password;
                    return true;
                }

                password = string.Empty;
                return false;
            }
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
        }
    }
}