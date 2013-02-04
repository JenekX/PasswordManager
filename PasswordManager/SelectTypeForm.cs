using System;
using System.Windows.Forms;
using Password.Classes;
using PasswordManager.Classes;

namespace PasswordManager
{
    internal partial class SelectTypeForm : Form
    {
        private PasswordDocument _document;
        private Configuration _config;

        private void FillComboBox()
        {
            cmbType.Items.Clear();

            foreach (var type in _document.Types)
                cmbType.Items.Add(type);

            if (cmbType.Items.Count > 0)
                cmbType.SelectedIndex = 0;
        }
        
        private void RefreshUI()
        {
            btnOk.Enabled = cmbType.Items.Count > 0;
        }

        private void Init(PasswordDocument document, Configuration config)
        {
            _document = document;
            _config = config;

            FillComboBox();
            RefreshUI();
        }

        public SelectTypeForm()
        {
            InitializeComponent();
        }

        public static bool Execute(IWin32Window owner, PasswordDocument document, Configuration config, out PasswordType result)
        {
            using (var form = new SelectTypeForm())
            {
                form.Init(document, config);

                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    result = form.SelectedType;
                    return true;
                }

                result = null;
                return false;
            }
        }

        public PasswordType SelectedType
        {
            get
            {
                return (PasswordType)cmbType.SelectedItem;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //

            FillComboBox();
            RefreshUI();
        }
    }
}