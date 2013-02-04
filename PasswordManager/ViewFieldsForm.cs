using System;
using System.Windows.Forms;
using Password.Classes;

namespace PasswordManager
{
    public partial class ViewFieldsForm : Form
    {
        private Fields _fields;
        private bool _isEdit;

        private void Fill()
        {
            dgvItems.Rows.Clear();

            foreach (var field in _fields)
                AddField(field);
        }

        private Field GetField(int index)
        {
            if (index == -1)
                return null;

            return dgvItems.Rows[index].Tag as Field;
        }

        private int GetSelectedIndex()
        {
            if (dgvItems.SelectedRows.Count > 0)
                return dgvItems.SelectedRows[0].Index;

            return -1;
        }

        private Field GetSelectedField()
        {
            int index = GetSelectedIndex();
            return GetField(index);
        }

        private void Init(Fields fields, bool isEdit)
        {
            _fields = fields;
            _isEdit = isEdit;

            if (isEdit)
            {
                Text = "Редактировать поле";

                btnClose.Text = "Закрыть";
            }
            else
            {
                Text = "Выбрать поле";

                dgvItems.DoubleClick -= BtnEditClick;
                dgvItems.DoubleClick += BtnSelectClick;
            }

            Fill();
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            btnSelect.Visible = !_isEdit;

            RefreshUI();
        }

        private void AddField(Field field)
        {
            var item = new DataGridViewRow();
            item.CreateCells(dgvItems, field.Name, field.IsEncrypt);
            item.Tag = field;

            dgvItems.Rows.Add(item);
            item.Selected = true;
        }

        private void RemoveField(int index)
        {
            var field = GetField(index);

            _fields.Remove(field);
            dgvItems.Rows.RemoveAt(index);

            int selectedIndex = Math.Min(index, dgvItems.Rows.Count - 1);
            if (selectedIndex != -1)
            {
                var item = dgvItems.Rows[selectedIndex];
                item.Selected = true;
            }
        }

        private void EditField(int index)
        {
            var item = dgvItems.Rows[index];
            var field = GetField(index);

            item.Cells[0].Value = field.Name;
            item.Cells[1].Value = field.IsEncrypt;
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
            var result = EditFieldForm.Execute(this, _fields, null);
            if (result == null)
                return;

            AddField(result);
            RefreshUI();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Удалить поле?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            int index = GetSelectedIndex();

            RemoveField(index);
            RefreshUI();
        }

        private void BtnEditClick(object sender, EventArgs e)
        {
            var index = GetSelectedIndex();
            if (index == -1)
                return;

            var field = GetField(index);

            var result = EditFieldForm.Execute(this, _fields, field);
            if (result == null)
                return;

            EditField(index);
        }

        private void BtnMoveUpClick(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            _fields.Move(index, index - 1);

            var item = dgvItems.Rows[index];
            dgvItems.Rows.RemoveAt(index);
            dgvItems.Rows.Insert(index - 1, item);

            item.Selected = true;

            RefreshUI();
        }

        private void BtnMoveDownClick(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();

            _fields.Move(index, index + 1);

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

        public ViewFieldsForm()
        {
            InitializeComponent();
        }

        public static void ExecuteEdit(IWin32Window owner, Fields fields)
        {
            using (var form = new ViewFieldsForm())
            {
                form.Init(fields, true);
                form.ShowDialog(owner);
            }
        }

        public static Field ExecuteSelect(IWin32Window owner, Fields fields)
        {
            using (var form = new ViewFieldsForm())
            {
                form.Init(fields, false);

                if (form.ShowDialog(owner) == DialogResult.OK)
                    return form.GetSelectedField();

                return null;
            }
        }
    }
}