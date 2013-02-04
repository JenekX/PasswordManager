namespace PasswordManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileCreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReferences = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReferencesFields = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReferencesPasswordTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasswords = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasswordsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasswordsRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasswordsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPasswordsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmPasswordsFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOptionsPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsTrayShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTrayClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tcPasswords = new PasswordManager.PasswordTypeTabControl();
            this.mainMenu.SuspendLayout();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmReferences,
            this.tsmPasswords,
            this.tsmOptions});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(748, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFileCreateNew,
            this.tsmFileChangePassword,
            this.tsmFileSeparator,
            this.tsmClose});
            this.tsmFile.Name = "tsmFile";
            this.tsmFile.Size = new System.Drawing.Size(48, 20);
            this.tsmFile.Text = "Файл";
            // 
            // tsmFileCreateNew
            // 
            this.tsmFileCreateNew.Name = "tsmFileCreateNew";
            this.tsmFileCreateNew.Size = new System.Drawing.Size(232, 22);
            this.tsmFileCreateNew.Text = "Очистить";
            this.tsmFileCreateNew.Click += new System.EventHandler(this.TsmFileCreateNewClick);
            // 
            // tsmFileChangePassword
            // 
            this.tsmFileChangePassword.Name = "tsmFileChangePassword";
            this.tsmFileChangePassword.Size = new System.Drawing.Size(232, 22);
            this.tsmFileChangePassword.Text = "Изменить пароль документа";
            this.tsmFileChangePassword.Click += new System.EventHandler(this.TsmFileChangePasswordClick);
            // 
            // tsmFileSeparator
            // 
            this.tsmFileSeparator.Name = "tsmFileSeparator";
            this.tsmFileSeparator.Size = new System.Drawing.Size(229, 6);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(232, 22);
            this.tsmClose.Text = "Выход";
            this.tsmClose.Click += new System.EventHandler(this.TsmCloseClick);
            // 
            // tsmReferences
            // 
            this.tsmReferences.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmReferencesFields,
            this.tsmReferencesPasswordTypes});
            this.tsmReferences.Name = "tsmReferences";
            this.tsmReferences.Size = new System.Drawing.Size(94, 20);
            this.tsmReferences.Text = "Справочники";
            // 
            // tsmReferencesFields
            // 
            this.tsmReferencesFields.Name = "tsmReferencesFields";
            this.tsmReferencesFields.Size = new System.Drawing.Size(154, 22);
            this.tsmReferencesFields.Text = "Поля";
            this.tsmReferencesFields.Click += new System.EventHandler(this.TsmReferencesFieldsClick);
            // 
            // tsmReferencesPasswordTypes
            // 
            this.tsmReferencesPasswordTypes.Name = "tsmReferencesPasswordTypes";
            this.tsmReferencesPasswordTypes.Size = new System.Drawing.Size(154, 22);
            this.tsmReferencesPasswordTypes.Text = "Типы паролей";
            this.tsmReferencesPasswordTypes.Click += new System.EventHandler(this.TsmReferencesPasswordTypesClick);
            // 
            // tsmPasswords
            // 
            this.tsmPasswords.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPasswordsAdd,
            this.tsmPasswordsRemove,
            this.tsmPasswordsEdit,
            this.tsmPasswordsSeparator,
            this.tsmPasswordsFilter});
            this.tsmPasswords.Name = "tsmPasswords";
            this.tsmPasswords.Size = new System.Drawing.Size(62, 20);
            this.tsmPasswords.Text = "Пароли";
            // 
            // tsmPasswordsAdd
            // 
            this.tsmPasswordsAdd.Name = "tsmPasswordsAdd";
            this.tsmPasswordsAdd.Size = new System.Drawing.Size(155, 22);
            this.tsmPasswordsAdd.Text = "Добавить";
            this.tsmPasswordsAdd.Click += new System.EventHandler(this.TsmPasswordsAddClick);
            // 
            // tsmPasswordsRemove
            // 
            this.tsmPasswordsRemove.Name = "tsmPasswordsRemove";
            this.tsmPasswordsRemove.Size = new System.Drawing.Size(155, 22);
            this.tsmPasswordsRemove.Text = "Удалить";
            this.tsmPasswordsRemove.Click += new System.EventHandler(this.TsmPasswordsRemoveClick);
            // 
            // tsmPasswordsEdit
            // 
            this.tsmPasswordsEdit.Name = "tsmPasswordsEdit";
            this.tsmPasswordsEdit.Size = new System.Drawing.Size(155, 22);
            this.tsmPasswordsEdit.Text = "Редактировать";
            this.tsmPasswordsEdit.Click += new System.EventHandler(this.TsmPasswordsEditClick);
            // 
            // tsmPasswordsSeparator
            // 
            this.tsmPasswordsSeparator.Name = "tsmPasswordsSeparator";
            this.tsmPasswordsSeparator.Size = new System.Drawing.Size(152, 6);
            // 
            // tsmPasswordsFilter
            // 
            this.tsmPasswordsFilter.Name = "tsmPasswordsFilter";
            this.tsmPasswordsFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmPasswordsFilter.Size = new System.Drawing.Size(155, 22);
            this.tsmPasswordsFilter.Text = "Фильтр";
            this.tsmPasswordsFilter.Click += new System.EventHandler(this.TsmPasswordsFilterClick);
            // 
            // tsmOptions
            // 
            this.tsmOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOptionsPreferences});
            this.tsmOptions.Name = "tsmOptions";
            this.tsmOptions.Size = new System.Drawing.Size(79, 20);
            this.tsmOptions.Text = "Настройки";
            // 
            // tsmOptionsPreferences
            // 
            this.tsmOptionsPreferences.Name = "tsmOptionsPreferences";
            this.tsmOptionsPreferences.Size = new System.Drawing.Size(134, 22);
            this.tsmOptionsPreferences.Text = "Настройки";
            this.tsmOptionsPreferences.Click += new System.EventHandler(this.TsmOptionsPreferencesClick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Управление паролями";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.cmsTrayShow_Click);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTrayShow,
            this.cmsTrayClose});
            this.cmsTray.Name = "contextMenuStrip1";
            this.cmsTray.Size = new System.Drawing.Size(125, 48);
            // 
            // cmsTrayShow
            // 
            this.cmsTrayShow.Name = "cmsTrayShow";
            this.cmsTrayShow.Size = new System.Drawing.Size(124, 22);
            this.cmsTrayShow.Text = "Показать";
            this.cmsTrayShow.Click += new System.EventHandler(this.cmsTrayShow_Click);
            // 
            // cmsTrayClose
            // 
            this.cmsTrayClose.Name = "cmsTrayClose";
            this.cmsTrayClose.Size = new System.Drawing.Size(124, 22);
            this.cmsTrayClose.Text = "Выход";
            this.cmsTrayClose.Click += new System.EventHandler(this.TsmCloseClick);
            // 
            // tcPasswords
            // 
            this.tcPasswords.Configuration = null;
            this.tcPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPasswords.Document = null;
            this.tcPasswords.Filter = "";
            this.tcPasswords.Location = new System.Drawing.Point(0, 24);
            this.tcPasswords.Name = "tcPasswords";
            this.tcPasswords.Size = new System.Drawing.Size(748, 312);
            this.tcPasswords.TabIndex = 1;
            this.tcPasswords.OnAddPassword += new System.EventHandler<PasswordManager.PasswordAddEventArgs>(this.TcPasswordsOnAddPassword);
            this.tcPasswords.OnRemovePassword += new System.EventHandler<PasswordManager.PasswordEventArgs>(this.TcPasswordsOnRemovePassword);
            this.tcPasswords.OnEditPassword += new System.EventHandler<PasswordManager.PasswordEventArgs>(this.TcPasswordsOnEditPassword);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 336);
            this.Controls.Add(this.tcPasswords);
            this.Controls.Add(this.mainMenu);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление паролями";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem tsmOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmPasswords;
        private System.Windows.Forms.ToolStripMenuItem tsmPasswordsAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmReferences;
        private System.Windows.Forms.ToolStripMenuItem tsmReferencesFields;
        private System.Windows.Forms.ToolStripMenuItem tsmReferencesPasswordTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmPasswordsRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmPasswordsEdit;
        private PasswordTypeTabControl tcPasswords;
        private System.Windows.Forms.ToolStripMenuItem tsmPasswordsFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmOptionsPreferences;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmFileCreateNew;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.ToolStripSeparator tsmPasswordsSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmFileChangePassword;
        private System.Windows.Forms.ToolStripSeparator tsmFileSeparator;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem cmsTrayClose;
        private System.Windows.Forms.ToolStripMenuItem cmsTrayShow;
    }
}

