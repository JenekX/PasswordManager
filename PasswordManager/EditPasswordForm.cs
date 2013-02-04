using System;
using System.Drawing;
using System.Windows.Forms;
using Password.Classes;
using PasswordManager.Classes;
using PasswordManager.Controls;

namespace PasswordManager
{
    internal partial class EditPasswordForm : Form
    {
        private void CreateButtons(int index)
        {
            tpMain.RowStyles[index].SizeType = SizeType.AutoSize;

            var btnOk = new Button
            {
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Right,
                Margin = new Padding(3, 3, 3, 8),
                Size = new Size(75, 25),
                Text = "Ok"
            };
            btnOk.Click += BtnOkClick;

            tpMain.Controls.Add(btnOk, 0, index);

            var btnCancel = new Button
            {
                DialogResult = DialogResult.Cancel,
                Dock = DockStyle.Right,
                Margin = new Padding(3, 3, 8, 8),
                Size = new Size(75, 25),
                Text = "Отмена"
            };

            tpMain.Controls.Add(btnCancel, 1, index);

            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }

        private void Init(Configuration configuration, Password.Classes.Password password)
        {
            tpMain.RowCount = password.Values.Count + 1;

            int i = 0;
            foreach (var passwordValue in password.Values)
            {
                tpMain.RowStyles[i].SizeType = SizeType.AutoSize;

                Control editor;

                if (passwordValue.Field.IsEncrypt)
                {
                    editor = new PasswordTextBox
                    {
                        Configuration = configuration,
                        Title = passwordValue.Field.Name
                    };
                }
                else
                {
                    editor = new LabeledTextBox
                    {
                        Title = passwordValue.Field.Name
                    };
                }

                editor.Dock = DockStyle.Fill;
                editor.Margin = new Padding(8, i == 0 ? 8 : 3, 8, 0);
                editor.Text = passwordValue.Value;
                editor.Tag = passwordValue;

                tpMain.Controls.Add(editor, 0, i);
                tpMain.SetColumnSpan(editor, 2);

                i++;
            }

            CreateButtons(password.Values.Count);

            ClientSize = tpMain.Size;
            MinimumSize = new Size(200, Size.Height);
            MaximumSize = new Size(800, Size.Height);
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            for (int i = 0; i < tpMain.RowCount - 1; i++)
            {
                var editor = tpMain.GetControlFromPosition(0, i);
                if (editor == null)
                    continue;

                var passwordValue = editor.Tag as PasswordValue;
                if (passwordValue == null)
                    continue;

                passwordValue.Value = editor.Text;
            }
        }

        public EditPasswordForm()
        {
            InitializeComponent();
        }

        public static bool Execute(IWin32Window owner, Configuration configuration, Password.Classes.Password password)
        {
            using (var form = new EditPasswordForm())
            {
                form.Init(configuration, password);
                return form.ShowDialog(owner) == DialogResult.OK;
            }
        }
    }
}