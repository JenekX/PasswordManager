using System;
using System.Windows.Forms;
using Password.Classes;

namespace PasswordManager
{
    public partial class EditFieldForm : Form
    {
        private Fields _fields;
        private Field _field;

        private void RefreshUI()
        {
            btnOk.Enabled = tbName.Text.Trim().Length > 0;
        }

        private void Init(Fields fields, Field field)
        {
            _fields = fields;
            _field = field;

            if (_field == null)
                Text = "Добавление";
            else
            {
                Text = "Редактирование";

                tbName.Text = _field.Name;
                cbIsEncrypt.Checked = _field.IsEncrypt;
            }

            RefreshUI();
        }

        private void TbNameTextChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            if (_field == null)
                _field = _fields.Add();

            _field.Name = tbName.Text;
            _field.IsEncrypt = cbIsEncrypt.Checked;
        }

        public EditFieldForm()
        {
            InitializeComponent();
        }

        public static Field Execute(IWin32Window owner, Fields fields, Field field)
        {
            using (var form = new EditFieldForm())
            {
                form.Init(fields, field);

                if (form.ShowDialog(owner) == DialogResult.OK)
                    return form.SelectedField;

                return null;
            }
        }

        public Field SelectedField
        {
            get
            {
                return _field;
            }
        }
    }
}