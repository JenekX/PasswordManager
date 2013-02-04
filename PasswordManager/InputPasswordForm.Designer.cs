namespace PasswordManager
{
    partial class InputPasswordForm
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
            this.tpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.passwordEvaluator = new PasswordManager.Controls.PasswordEvaluator();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpMain
            // 
            this.tpMain.AutoSize = true;
            this.tpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tpMain.ColumnCount = 2;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.Controls.Add(this.lblPassword, 0, 1);
            this.tpMain.Controls.Add(this.tbPassword, 0, 2);
            this.tpMain.Controls.Add(this.lblConfirmPassword, 0, 3);
            this.tpMain.Controls.Add(this.tbConfirmPassword, 0, 4);
            this.tpMain.Controls.Add(this.btnCancel, 1, 7);
            this.tpMain.Controls.Add(this.btnOk, 0, 7);
            this.tpMain.Controls.Add(this.cbShowPassword, 0, 5);
            this.tpMain.Controls.Add(this.passwordEvaluator, 0, 6);
            this.tpMain.Controls.Add(this.lblDescription, 0, 0);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 8;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.Size = new System.Drawing.Size(284, 208);
            this.tpMain.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.tpMain.SetColumnSpan(this.lblPassword, 2);
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(8, 29);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(8, 8, 8, 3);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(268, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Пароль:";
            // 
            // tbPassword
            // 
            this.tpMain.SetColumnSpan(this.tbPassword, 2);
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Location = new System.Drawing.Point(8, 48);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(268, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.TextChanged += new System.EventHandler(this.TbPasswordTextChanged);
            // 
            // lblConfirmPassword
            // 
            this.tpMain.SetColumnSpan(this.lblConfirmPassword, 2);
            this.lblConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfirmPassword.Location = new System.Drawing.Point(8, 74);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(268, 13);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Подтверждение:";
            // 
            // tbConfirmPassword
            // 
            this.tpMain.SetColumnSpan(this.tbConfirmPassword, 2);
            this.tbConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConfirmPassword.Location = new System.Drawing.Point(8, 93);
            this.tbConfirmPassword.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(268, 20);
            this.tbConfirmPassword.TabIndex = 3;
            this.tbConfirmPassword.TextChanged += new System.EventHandler(this.TbPasswordTextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(201, 175);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(120, 175);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // cbShowPassword
            // 
            this.tpMain.SetColumnSpan(this.cbShowPassword, 2);
            this.cbShowPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShowPassword.Location = new System.Drawing.Point(8, 119);
            this.cbShowPassword.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.Size = new System.Drawing.Size(268, 17);
            this.cbShowPassword.TabIndex = 4;
            this.cbShowPassword.Text = "Показывать пароль";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.CbShowPasswordCheckedChanged);
            // 
            // passwordEvaluator
            // 
            this.tpMain.SetColumnSpan(this.passwordEvaluator, 2);
            this.passwordEvaluator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordEvaluator.Location = new System.Drawing.Point(8, 142);
            this.passwordEvaluator.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.passwordEvaluator.Name = "passwordEvaluator";
            this.passwordEvaluator.Size = new System.Drawing.Size(268, 27);
            this.passwordEvaluator.TabIndex = 7;
            this.passwordEvaluator.EvaluatePassword += new System.EventHandler<PasswordManager.Controls.PasswordEvaluator.EvaluatePasswordEventArgs>(this.PasswordEvaluatorEvaluatePassword);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.tpMain.SetColumnSpan(this.lblDescription, 2);
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription.Location = new System.Drawing.Point(8, 8);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(268, 13);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Описание";
            // 
            // InputPasswordForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 208);
            this.Controls.Add(this.tpMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Задайте пароль";
            this.Shown += new System.EventHandler(this.InputPasswordFormShown);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private Controls.PasswordEvaluator passwordEvaluator;
        private System.Windows.Forms.Label lblDescription;
    }
}