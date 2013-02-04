namespace PasswordManager
{
    partial class EditFieldForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbIsEncrypt = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.tpMain.SetColumnSpan(this.lblName, 2);
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(8, 8);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(218, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Имя поля:";
            // 
            // tbName
            // 
            this.tpMain.SetColumnSpan(this.tbName, 2);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(8, 24);
            this.tbName.Margin = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(218, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.TbNameTextChanged);
            // 
            // cbIsEncrypt
            // 
            this.tpMain.SetColumnSpan(this.cbIsEncrypt, 2);
            this.cbIsEncrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIsEncrypt.Location = new System.Drawing.Point(8, 47);
            this.cbIsEncrypt.Margin = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.cbIsEncrypt.Name = "cbIsEncrypt";
            this.cbIsEncrypt.Size = new System.Drawing.Size(218, 17);
            this.cbIsEncrypt.TabIndex = 2;
            this.cbIsEncrypt.Text = "это пароль";
            this.cbIsEncrypt.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(70, 67);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(151, 67);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 2;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.Controls.Add(this.lblName, 0, 0);
            this.tpMain.Controls.Add(this.btnOk, 0, 3);
            this.tpMain.Controls.Add(this.btnCancel, 1, 3);
            this.tpMain.Controls.Add(this.tbName, 0, 1);
            this.tpMain.Controls.Add(this.cbIsEncrypt, 0, 2);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 4;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.Size = new System.Drawing.Size(234, 100);
            this.tpMain.TabIndex = 5;
            // 
            // EditFieldForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(234, 100);
            this.Controls.Add(this.tpMain);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 138);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 138);
            this.Name = "EditFieldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.CheckBox cbIsEncrypt;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tpMain;
    }
}