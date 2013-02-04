using System;
using System.Windows.Forms;
using PasswordManager.Classes;

namespace PasswordManager
{
    internal partial class ConfigForm : Form
    {
        private Configuration _config;
        private bool _modified;

        private PasswordAutostartHelper _passwordAutostart;

        public ConfigForm()
        {
            InitializeComponent();

            _passwordAutostart = new PasswordAutostartHelper();
        }

        public void Initialize(Configuration config)
        {
            _config = config;

            nPasswordLength.Value = _config.PasswordLength;
            tbAllowChars.Text = _config.AllowChars;

            cbAutoStart.Checked = _passwordAutostart.IsRegistred;

            Modified = false;
        }

        public void RefreshUI()
        {
            btnSave.Enabled = Modified;
        }

        public static void Execute(IWin32Window owner, Configuration config)
        {
            using (var form = new ConfigForm())
            {
                form.Initialize(config);
                form.ShowDialog(owner);
            }
        }

        private void PasswordLengthValueChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            _config.PasswordLength = (int)nPasswordLength.Value;
            _config.AllowChars = tbAllowChars.Text;

            _config.ShowShortcut = hkShowForSelect.Key;

            _passwordAutostart.IsRegistred = cbAutoStart.Checked;

            Modified = false;
        }

        public bool Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
                RefreshUI();
            }
        }
    }
}