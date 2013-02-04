using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Password.Classes;
using PasswordManager.Classes;
using XConfig;

namespace PasswordManager
{
    public partial class MainForm : Form
    {
        private XConfigManager<Configuration> _config;
        private string _password;
        private PasswordDocument _document;

        private KeyboardHook _hook;

        public static string PasswordsFileName
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Passwords.xml");
            }
        }

        public static bool IsPasswordsFileExists
        {
            get
            {
                return File.Exists(PasswordsFileName);
            }
        }

        public string ConfigFileName
        {
            get
            {
                return Path.Combine(Application.StartupPath, "options.config");
            }
        }

        private void LoadDocument(string password)
        {
            _document = new PasswordDocument();
            _document.Load(PasswordsFileName, password);

            Action invoke = () =>
                                {
                                    tcPasswords.Configuration = _config.RootElement;
                                    tcPasswords.Document = _document;
                                };

            Invoke(invoke);
        }

        private void ShowErrorMessage(string message)
        {
            Action method = () => MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }

        public MainForm(string password)
        {
            InitializeComponent();

            _password = password;
            _config = new XConfigManager<Configuration>("configuration");

            _hook = new KeyboardHook();
            _hook.KeyPressed += HookKeyPressed;
        }

        protected override void OnLoad(EventArgs e)
        {
            backgroundWorker.RunWorkerAsync(_password);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _hook.Dispose();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = false;

            try
            {
                if (File.Exists(ConfigFileName))
                    _config.Load(ConfigFileName);

                var password = (string)e.Argument;
                LoadDocument(password);

                e.Result = true;
            }
            catch (InvalidPasswordException)
            {
                ShowErrorMessage("Неверный пароль");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(string.Format("Произошла ошибка:\r\n\r\n{0}", ex.Message));
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(bool)e.Result)
            {
                Application.Exit();
                return;
            }

            _hook.RegisterHotKey(Classes.ModifierKeys.Control | Classes.ModifierKeys.Shift, Keys.P);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_document.IsLoaded)
                _document.Save();
        }

        private void TcPasswordsOnAddPassword(object sender, PasswordAddEventArgs e)
        {
            if (e.NeedChoosePasswordType)
            {
                var passwordType = ViewTypesForm.ExecuteSelect(this, _document.Types);
                if (passwordType == null)
                    return;

                e.Password.PasswordType = passwordType;
            }

            if (!EditPasswordForm.Execute(this, _config.RootElement, e.Password))
                return;

            e.Success = true;
        }

        private void TcPasswordsOnRemovePassword(object sender, PasswordEventArgs e)
        {
            e.Success = MessageBox.Show(this, "Вы действительно хотите удалить пароль?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private void TcPasswordsOnEditPassword(object sender, PasswordEventArgs e)
        {
            e.Success = EditPasswordForm.Execute(this, _config.RootElement, e.Password);
        }

        private void TsmFileCreateNewClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Будут удалены все пароли, типы и поля. Вы действительно хотите продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            _document.CreateNew(_document.DocumentPassword);

            tcPasswords.UpdateTabs();
        }

        private void TsmFileChangePasswordClick(object sender, EventArgs e)
        {
            string password;
            if (!InputPasswordForm.ExecuteChange(this, out password))
                return;

            _document.DocumentPassword = password;
        }

        private void TsmCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TsmReferencesFieldsClick(object sender, EventArgs e)
        {
            ViewFieldsForm.ExecuteEdit(this, _document.Fields);

            tcPasswords.UpdateTabs();
        }

        private void TsmReferencesPasswordTypesClick(object sender, EventArgs e)
        {
            ViewTypesForm.ExecuteEdit(this, _document.Types);

            tcPasswords.UpdateTabs();
        }

        private void TsmPasswordsAddClick(object sender, EventArgs e)
        {
            tcPasswords.AddPassword(true);
        }

        private void TsmPasswordsRemoveClick(object sender, EventArgs e)
        {
            tcPasswords.RemovePassword();
        }

        private void TsmPasswordsEditClick(object sender, EventArgs e)
        {
            tcPasswords.EditPassword();
        }

        private void TsmPasswordsFilterClick(object sender, EventArgs e)
        {
            string filter;
            if (FilterForm.Execute(this, tcPasswords.Filter, out filter))
                tcPasswords.Filter = filter;
        }

        private void TsmOptionsPreferencesClick(object sender, EventArgs e)
        {
            ConfigForm.Execute(this, _config.RootElement);

            _config.Save(ConfigFileName);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                Hide();
            }
        }

        private void cmsTrayShow_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void HookKeyPressed(object sender, KeyPressedEventArgs args)
        {
            if (Visible)
                Focus();
            else
                cmsTrayShow_Click(this, new EventArgs());
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyData == Keys.Escape)
            {
                WindowState = FormWindowState.Minimized;

                e.Handled = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyValue >= 48 && e.KeyValue <= 57)
            {
                var tab = tcPasswords.SelectedTab;
                if (tab != null)
                {
                    var password = tab.SelectedPassword;
                    if (password != null)
                    {
                        int index = e.KeyValue == 48 ? 9 : (e.KeyValue - 49);
                        if (index < password.Values.Count)
                        {
                            var value = password.Values[index].Value;
                            if (string.IsNullOrEmpty(value))
                                Clipboard.Clear();
                            else
                                while (true)
                                    try
                                    {
                                        var obj = new DataObject(DataFormats.UnicodeText, value);
                                        Clipboard.SetDataObject(obj);
                                        break;
                                    }
                                    catch
                                    {
                                    }

                            WindowState = FormWindowState.Minimized;
                            e.Handled = true;
                        }
                    }
                }
            }
        }
    }
}