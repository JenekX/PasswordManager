using System;
using System.Windows.Forms;
using PasswordManager.Controls;

namespace PasswordManager
{
    public partial class InputPasswordForm : Form
    {
        private void FillPasswordEvaluator()
        {
            passwordEvaluator.Password = tbPassword.Text;

            if (!cbShowPassword.Checked && string.Compare(tbPassword.Text, tbConfirmPassword.Text, StringComparison.Ordinal) != 0)
                passwordEvaluator.ErrorText = "Пароли не совпадают";
            else
                passwordEvaluator.ErrorText = string.Empty;
        }

        private void Init(string description)
        {
            Description = description;
        }

        private void RefreshUI()
        {
            btnOk.Enabled = tbPassword.Text.Trim().Length > 0 &&
                (cbShowPassword.Checked || tbPassword.Text == tbConfirmPassword.Text);
        }

        private void InputPasswordFormShown(object sender, EventArgs e)
        {
            ClientSize = tpMain.Size;
        }

        private void CbShowPasswordCheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '*';
            lblConfirmPassword.Visible = tbConfirmPassword.Visible = !cbShowPassword.Checked;
            ClientSize = tpMain.Size;

            FillPasswordEvaluator();
            RefreshUI();
        }

        private void TbPasswordTextChanged(object sender, EventArgs e)
        {
            FillPasswordEvaluator();
            RefreshUI();
        }

        private void PasswordEvaluatorEvaluatePassword(object sender, PasswordEvaluator.EvaluatePasswordEventArgs e)
        {
            // todo: Написать корректную функцию проверки сложности пароля
            switch (e.Password.Length)
            {
                case 0:
                    e.Status = PasswordEvaluator.Status.Empty;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    e.Status = PasswordEvaluator.Status.Low;
                    break;
                case 5:
                case 6:
                case 7:
                    e.Status = PasswordEvaluator.Status.Medium;
                    break;
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    e.Status = PasswordEvaluator.Status.High;
                    break;
                default:
                    e.Status = PasswordEvaluator.Status.Best;
                    break;
            }
        }

        public InputPasswordForm()
        {
            InitializeComponent();

            RefreshUI();
        }

        private static bool Execute(IWin32Window owner, string description, out string password)
        {
            using (var form = new InputPasswordForm())
            {
                form.Init(description);
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    password = form.Password;
                    return true;
                }

                password = string.Empty;
                return false;
            }
        }

        public static bool ExecuteCreateNew(IWin32Window owner, out string password)
        {
            return Execute(owner, "Файл паролей не обнаружен. Будет создан новый файл. Введите пароль для файла.", out password);
        }

        public static bool ExecuteChange(IWin32Window owner, out string password)
        {
            return Execute(owner, "Задайте новый пароль к документу.", out password);
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
        }

        public string Description
        {
            get
            {
                return lblDescription.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    lblDescription.Visible = false;
                else
                {
                    lblDescription.Visible = true;
                    lblDescription.Text = value;
                }

                ClientSize = tpMain.Size;
            }
        }
    }
}