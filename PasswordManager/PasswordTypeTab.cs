using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Password.Classes;
using PasswordManager.Classes;

namespace PasswordManager
{
    internal partial class PasswordTypeTab : TabPage
    {
        private PasswordType _passwordType;
        private Configuration _configuration;

        private string _filter;

        private Control _parent;

        private bool CompareFilter(Password.Classes.Password password)
        {
            if (string.IsNullOrWhiteSpace(Filter))
                return true;

            return password.Values.Any(x => !x.Field.IsEncrypt && x.Value.ToLowerInvariant().Contains(Filter.ToLowerInvariant()));
        }

        private void FillColumns()
        {
            grid.Columns.Clear();

            foreach (var field in PasswordType.Fields)
            {
                DataGridViewColumn column;

                if (field.IsEncrypt)
                {
                    column = new DataGridViewButtonColumn
                    {
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 100
                    };
                }
                else
                    column = new DataGridViewTextBoxColumn();

                column.HeaderText = field.Name;
                grid.Columns.Add(column);
            }
        }

        private DataGridViewRow AddRow(Password.Classes.Password password)
        {
            var row = new DataGridViewRow();
            row.CreateCells(grid);
            row.Tag = password;
            row.Visible = CompareFilter(password);

            int i = 0;
            foreach (var value in password.Values)
                row.Cells[i++].Value = new GridCellWrapper(value);

            grid.Rows.Add(row);

            return row;
        }

        private void FillRows()
        {
            grid.Rows.Clear();

            var passwords = PasswordType.Parent.Owner.Passwords.Where(password => password.PasswordType.Equals(PasswordType));
            foreach (var password in passwords)
                AddRow(password);
        }

        private void Fill()
        {
            if (PasswordType == null || Configuration == null)
                return;

            Clear();
            FillColumns();
            FillRows();
        }

        private void ApplyFilter()
        {
            foreach (DataGridViewRow row in grid.Rows)
                row.Visible = CompareFilter(row.Tag as Password.Classes.Password);

            Visible = VisibleRowCount > 0;
        }

        private DataGridViewRow GetSelectedRow()
        {
            return grid.SelectedRows.Count == 1 ? grid.SelectedRows[0] : null;
        }

        public PasswordTypeTab(PasswordType passwordType, Configuration configuration)
        {
            InitializeComponent();

            Controls.Add(grid);
            
            Configuration = configuration;
            PasswordType = passwordType;

            Text = passwordType.Name;
        }

        public void Clear()
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
        }

        public void UpdatePasswords()
        {
        	Fill();
        	
        	Visible = VisibleRowCount > 0;
        }

        public PasswordType PasswordType
        {
            get
            {
                return _passwordType;
            }
            set
            {
                _passwordType = value;

                Fill();
            }
        }

        public Configuration Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                _configuration = value;

                Fill();
            }
        }

        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;

                ApplyFilter();
            }
        }

        public List<DataGridViewRow> Rows
        {
            get
            {
                return grid.Rows.Cast<DataGridViewRow>().ToList();
            } 
        }

        public int VisibleRowCount
        {
            get
            {
                return grid.Rows.Cast<DataGridViewRow>().Count(x => x.Visible);
            }
        }

        public override sealed string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        
        public PasswordTypeTabControl PasswordControl
        {
        	get
        	{
        		return (PasswordTypeTabControl)(base.Parent.Parent);
        	}
        }

        public new bool Visible
        {
            get
            {
                return Parent != null;
            }
            set
            {
                bool visible = Visible;
                if (visible == value)
                    return;

                if (value)
                    Parent = _parent;
                else
                {
                    _parent = Parent;
                    Parent = null;
                }
            }
        }

        public Password.Classes.Password SelectedPassword
        {
            get
            {
                var row = GetSelectedRow();

                return row != null ? row.Tag as Password.Classes.Password : null;
            }
            set
            {
                if (value == null)
                    return;

                var row = grid.Rows.OfType<DataGridViewRow>().SingleOrDefault(x => x.Tag is Password.Classes.Password && x.Tag.Equals(value));
                if (row == null)
                    return;

                row.Selected = true;
            }
        }

        private void GridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;

            var cell = grid[e.ColumnIndex, e.RowIndex];
            if (cell.OwningColumn.CellType != typeof(DataGridViewButtonCell))
                return;

            var value = cell.Value as GridCellWrapper;
            if (value == null)
                return;

            try
            {
                var obj = new DataObject(DataFormats.UnicodeText, value.PasswordValue.Value);
                Clipboard.SetDataObject(obj);
            }
            catch
            {
            }
        }

        private void GridDoubleClick(object sender, System.EventArgs e)
        {
        	PasswordControl.EditPassword();
        }

        private void GridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt || e.Control || e.Shift)
                return;

            switch (e.KeyCode)
            {
            		case Keys.Insert: PasswordControl.AddPassword(false); break;
            		case Keys.Delete: PasswordControl.RemovePassword(); break;
            		case Keys.Return: PasswordControl.EditPassword(); break;
                default: return;
            }

            e.Handled = true;
        }
    }

    internal class GridCellWrapper
    {
        public GridCellWrapper(PasswordValue passwordValue)
        {
            PasswordValue = passwordValue;
        }

        public override string ToString()
        {
            return PasswordValue.Field.IsEncrypt ? "Копировать" : PasswordValue.Value;
        }

        public PasswordValue PasswordValue
        {
            get;
            set;
        }
    }
}