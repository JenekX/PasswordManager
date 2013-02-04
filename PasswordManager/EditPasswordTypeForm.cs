using System;
using System.Linq;
using System.Windows.Forms;
using Password.Classes;

namespace PasswordManager
{
    public partial class EditPasswordTypeForm : Form
    {
        private PasswordTypes _passwordTypes;
        private PasswordType _passwordType;

        private void Fill()
        {
            dgvFields.Rows.Clear();

            foreach (var field in _passwordType.Fields)
                AddField(field);
        }

        private int GetSelectedIndex()
        {
            if (dgvFields.SelectedRows.Count > 0)
                return dgvFields.SelectedRows[0].Index;

            return -1;
        }

        private Field[] GetFields()
        {
            return dgvFields.Rows.OfType<DataGridViewRow>().Select(x => x.Tag as Field).ToArray();
        }

        private void Init(PasswordTypes passwordTypes, PasswordType passwordType)
        {
            _passwordTypes = passwordTypes;
            _passwordType = passwordType;

            if (_passwordType == null)
                Text = "Добавление";
            else
            {
                Text = "Редактирование";

                tbName.Text = _passwordType.Name;
                Fill();
            }

            RefreshUI();
        }
        
        private void RefreshUI()
        {
            int index = GetSelectedIndex();

            btnRemove.Enabled = index >= 0;
            btnMoveUp.Enabled = index > 0;
            btnMoveDown.Enabled = index >= 0 && index < dgvFields.Rows.Count - 1;

            btnOk.Enabled = tbName.Text.Trim().Length > 0;
        }

        private void AddField(Field field)
        {
            var item = new DataGridViewRow();
            item.CreateCells(dgvFields, field.Name, field.IsEncrypt);
            item.Tag = field;

            dgvFields.Rows.Add(item);
            item.Selected = true;
        }

        private void RemoveField(int index)
        {
            dgvFields.Rows.RemoveAt(index);

            int selectedIndex = Math.Min(index, dgvFields.Rows.Count - 1);
            if (selectedIndex != -1)
            {
                var item = dgvFields.Rows[selectedIndex];
                item.Selected = true;
            }
        }

        private void TbNameTextChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void DgvFieldsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt || e.Control || e.Shift)
                return;

            switch (e.KeyCode)
            {
                case Keys.Insert: btnAdd.PerformClick(); break;
                case Keys.Delete: btnRemove.PerformClick(); break;
                default: return;
            }

            e.Handled = true;
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            var field = ViewFieldsForm.ExecuteSelect(this, _passwordTypes.Owner.Fields);
            if (field == null)
                return;

            AddField(field);
            RefreshUI();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Удалить поле из типа?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            int index = GetSelectedIndex();

            RemoveField(index);
            RefreshUI();
        }

        private void BtnMoveUpClick(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            var item = dgvFields.Rows[index];
            dgvFields.Rows.RemoveAt(index);
            dgvFields.Rows.Insert(index - 1, item);

            item.Selected = true;

            RefreshUI();
        }

        private void BtnMoveDownClick(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            var item = dgvFields.Rows[index];
            dgvFields.Rows.RemoveAt(index);
            dgvFields.Rows.Insert(index + 1, item);

            item.Selected = true;

            RefreshUI();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            if (_passwordType == null)
                _passwordType = _passwordTypes.Add();

            _passwordType.Name = tbName.Text;

            var fields = GetFields();
            _passwordType.Fields.Sync(fields);
        }

        public EditPasswordTypeForm()
        {
            InitializeComponent();
        }

        public static PasswordType Execute(IWin32Window owner, PasswordTypes passwordTypes, PasswordType passwordType)
        {
            using (var form = new EditPasswordTypeForm())
            {
                form.Init(passwordTypes, passwordType);

                if (form.ShowDialog(owner) == DialogResult.OK)
                    return form.SelectedPasswordType;

                return null;
            }
        }

        public PasswordType SelectedPasswordType
        {
            get
            {
                return _passwordType;
            }
        }
    }
}