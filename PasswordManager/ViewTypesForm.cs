using System;
using System.Windows.Forms;
using Password.Classes;

namespace PasswordManager
{
    public partial class ViewTypesForm : Form
    {
        private PasswordTypes _passwordTypes;

        private void Fill()
        {
            dgvItems.Rows.Clear();

            foreach (var passwordType in _passwordTypes)
                AddPasswordType(passwordType);
        }

        private PasswordType GetPasswordType(int index)
        {
            if (index == -1)
                return null;

            return dgvItems.Rows[index].Tag as PasswordType;
        }

        private int GetSelectedIndex()
        {
            if (dgvItems.SelectedRows.Count > 0)
                return dgvItems.SelectedRows[0].Index;

            return -1;
        }

        private PasswordType GetSelectedPasswordType()
        {
            int index = GetSelectedIndex();
            return GetPasswordType(index);
        }

        private void Init(PasswordTypes passwordTypes, bool isEdit)
        {
            _passwordTypes = passwordTypes;

            if (isEdit)
            {
                Text = "Редактировать тип";

                btnSelect.Visible = false;
                btnClose.Text = "Закрыть";
            }
            else
            {
                Text = "Выбрать тип";

                dgvItems.DoubleClick -= BtnEditClick;
                dgvItems.DoubleClick += BtnSelectClick;
            }

            Fill();
            RefreshUI();
        }

        private void RefreshUI()
        {
            int index = GetSelectedIndex();

            btnRemove.Enabled = btnEdit.Enabled = index >= 0;
            btnMoveUp.Enabled = index > 0;
            btnMoveDown.Enabled = index >= 0 && index < dgvItems.Rows.Count - 1;

            if (btnSelect.Visible)
                btnSelect.Enabled = btnRemove.Enabled;
        }

        private void AddPasswordType(PasswordType passwordType)
        {
            var item = new DataGridViewRow();
            item.CreateCells(dgvItems, passwordType.Name, passwordType.Fields.Count);
            item.Tag = passwordType;

            dgvItems.Rows.Add(item);
            item.Selected = true;
        }

        private void RemovePasswordType(int index)
        {
            var passwordType = GetPasswordType(index);

            _passwordTypes.Remove(passwordType);
            dgvItems.Rows.RemoveAt(index);

            int selectedIndex = Math.Min(index, dgvItems.Rows.Count - 1);
            if (selectedIndex != -1)
            {
                var item = dgvItems.Rows[selectedIndex];
                item.Selected = true;
            }
        }

        private void EditPasswordType(int index)
        {
            var item = dgvItems.Rows[index];
            var passwordType = GetPasswordType(index);

            item.Cells[0].Value = passwordType.Name;
            item.Cells[1].Value = passwordType.Fields.Count;
            item.Selected = true;
        }

        private void DgvItemsSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void DgvItemsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt || e.Control || e.Shift)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Insert: btnAdd.PerformClick(); break;
                case Keys.Delete: btnRemove.PerformClick(); break;
                case Keys.Return: btnEdit.PerformClick(); break;
                default: return;
            }

            e.Handled = true;
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            var result = EditPasswordTypeForm.Execute(this, _passwordTypes, null);
            if (result == null)
                return;

            AddPasswordType(result);
            RefreshUI();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            var passwordType = GetSelectedPasswordType();
            if (passwordType == null)
                return;

            var canRemove = _passwordTypes.CanRemove(passwordType);
            if (canRemove)
            {
                if (MessageBox.Show(this, "Удалить тип?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
            }
            else
            {
                if (MessageBox.Show(this, "Обнаружены пароли, использующие данный тип. Удаление типа приведет и к удалению этих паролей. Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;
            }

            int index = GetSelectedIndex();

            RemovePasswordType(index);
            RefreshUI();
        }

        private void BtnEditClick(object sender, EventArgs e)
        {
            var index = GetSelectedIndex();
            if (index == -1)
                return;

            var passwordType = GetPasswordType(index);

            var result = EditPasswordTypeForm.Execute(this, _passwordTypes, passwordType);
            if (result == null)
                return;

            EditPasswordType(index);
        }

        private void BtnMoveUpClick(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            _passwordTypes.Move(index, index - 1);

            var item = dgvItems.Rows[index];
            dgvItems.Rows.RemoveAt(index);
            dgvItems.Rows.Insert(index - 1, item);

            item.Selected = true;

            RefreshUI();
        }

        private void BtnMoveDownClick(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            _passwordTypes.Move(index, index + 1);

            var item = dgvItems.Rows[index];
            dgvItems.Rows.RemoveAt(index);
            dgvItems.Rows.Insert(index + 1, item);

            item.Selected = true;

            RefreshUI();
        }

        private void BtnSelectClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        public ViewTypesForm()
        {
            InitializeComponent();
        }

        public static void ExecuteEdit(IWin32Window owner, PasswordTypes passwordTypes)
        {
            using (var form = new ViewTypesForm())
            {
                form.Init(passwordTypes, true);
                form.ShowDialog(owner);
            }
        }

        public static PasswordType ExecuteSelect(IWin32Window owner, PasswordTypes passwordTypes)
        {
            using (var form = new ViewTypesForm())
            {
                form.Init(passwordTypes, false);

                if (form.ShowDialog(owner) == DialogResult.OK)
                    return form.GetSelectedPasswordType();

                return null;
            }
        }
    }
}
