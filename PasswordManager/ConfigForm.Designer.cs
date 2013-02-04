namespace PasswordManager
{
    partial class ConfigForm
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
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tpPasswords = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAllowChars = new System.Windows.Forms.Label();
            this.lblPasswordLength = new System.Windows.Forms.Label();
            this.nPasswordLength = new System.Windows.Forms.NumericUpDown();
            this.tbAllowChars = new System.Windows.Forms.TextBox();
            this.tpHotkeys = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hkShowForSelect = new PasswordManager.Controls.HotkeyEdit();
            this.tcIntegration = new System.Windows.Forms.TabPage();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcPages.SuspendLayout();
            this.tpPasswords.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPasswordLength)).BeginInit();
            this.tpHotkeys.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tcIntegration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPages
            // 
            this.tcPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPages.Controls.Add(this.tpPasswords);
            this.tcPages.Controls.Add(this.tpHotkeys);
            this.tcPages.Controls.Add(this.tcIntegration);
            this.tcPages.Location = new System.Drawing.Point(0, 0);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(284, 221);
            this.tcPages.TabIndex = 0;
            // 
            // tpPasswords
            // 
            this.tpPasswords.Controls.Add(this.tableLayoutPanel1);
            this.tpPasswords.Location = new System.Drawing.Point(4, 22);
            this.tpPasswords.Margin = new System.Windows.Forms.Padding(0);
            this.tpPasswords.Name = "tpPasswords";
            this.tpPasswords.Padding = new System.Windows.Forms.Padding(3);
            this.tpPasswords.Size = new System.Drawing.Size(276, 195);
            this.tpPasswords.TabIndex = 0;
            this.tpPasswords.Text = "Пароли";
            this.tpPasswords.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblAllowChars, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordLength, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nPasswordLength, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbAllowChars, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 189);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblAllowChars
            // 
            this.lblAllowChars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAllowChars.Location = new System.Drawing.Point(8, 52);
            this.lblAllowChars.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblAllowChars.Name = "lblAllowChars";
            this.lblAllowChars.Size = new System.Drawing.Size(254, 15);
            this.lblAllowChars.TabIndex = 2;
            this.lblAllowChars.Text = "Символы пароля:";
            // 
            // lblPasswordLength
            // 
            this.lblPasswordLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPasswordLength.Location = new System.Drawing.Point(8, 8);
            this.lblPasswordLength.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblPasswordLength.Name = "lblPasswordLength";
            this.lblPasswordLength.Size = new System.Drawing.Size(254, 15);
            this.lblPasswordLength.TabIndex = 0;
            this.lblPasswordLength.Text = "Длина пароля:";
            this.lblPasswordLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nPasswordLength
            // 
            this.nPasswordLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nPasswordLength.Location = new System.Drawing.Point(8, 26);
            this.nPasswordLength.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.nPasswordLength.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nPasswordLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nPasswordLength.Name = "nPasswordLength";
            this.nPasswordLength.Size = new System.Drawing.Size(254, 20);
            this.nPasswordLength.TabIndex = 1;
            this.nPasswordLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nPasswordLength.ValueChanged += new System.EventHandler(this.PasswordLengthValueChanged);
            // 
            // tbAllowChars
            // 
            this.tbAllowChars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAllowChars.Location = new System.Drawing.Point(8, 73);
            this.tbAllowChars.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.tbAllowChars.Name = "tbAllowChars";
            this.tbAllowChars.Size = new System.Drawing.Size(254, 20);
            this.tbAllowChars.TabIndex = 3;
            this.tbAllowChars.TextChanged += new System.EventHandler(this.PasswordLengthValueChanged);
            // 
            // tpHotkeys
            // 
            this.tpHotkeys.Controls.Add(this.tableLayoutPanel2);
            this.tpHotkeys.Location = new System.Drawing.Point(4, 22);
            this.tpHotkeys.Name = "tpHotkeys";
            this.tpHotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tpHotkeys.Size = new System.Drawing.Size(276, 195);
            this.tpHotkeys.TabIndex = 1;
            this.tpHotkeys.Text = "Горячие клавиши";
            this.tpHotkeys.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.hkShowForSelect, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(270, 189);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // hkShowForSelect
            // 
            this.hkShowForSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.hkShowForSelect.Location = new System.Drawing.Point(8, 8);
            this.hkShowForSelect.Margin = new System.Windows.Forms.Padding(8);
            this.hkShowForSelect.Name = "hkShowForSelect";
            this.hkShowForSelect.Size = new System.Drawing.Size(254, 36);
            this.hkShowForSelect.TabIndex = 0;
            this.hkShowForSelect.Title = "Показать для выбора пароля:";
            // 
            // tcIntegration
            // 
            this.tcIntegration.Controls.Add(this.cbAutoStart);
            this.tcIntegration.Location = new System.Drawing.Point(4, 22);
            this.tcIntegration.Name = "tcIntegration";
            this.tcIntegration.Padding = new System.Windows.Forms.Padding(3);
            this.tcIntegration.Size = new System.Drawing.Size(276, 195);
            this.tcIntegration.TabIndex = 2;
            this.tcIntegration.Text = "Интеграция";
            this.tcIntegration.UseVisualStyleBackColor = true;
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.Location = new System.Drawing.Point(11, 11);
            this.cbAutoStart.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(252, 17);
            this.cbAutoStart.TabIndex = 0;
            this.cbAutoStart.Text = "Запуск при входе";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            this.cbAutoStart.CheckedChanged += new System.EventHandler(this.PasswordLengthValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(116, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Location = new System.Drawing.Point(197, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcPages);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.tcPages.ResumeLayout(false);
            this.tpPasswords.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPasswordLength)).EndInit();
            this.tpHotkeys.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tcIntegration.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPages;
        private System.Windows.Forms.TabPage tpPasswords;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbAllowChars;
        private System.Windows.Forms.Label lblAllowChars;
        private System.Windows.Forms.NumericUpDown nPasswordLength;
        private System.Windows.Forms.Label lblPasswordLength;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tpHotkeys;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.HotkeyEdit hkShowForSelect;
        private System.Windows.Forms.TabPage tcIntegration;
        private System.Windows.Forms.CheckBox cbAutoStart;
    }
}