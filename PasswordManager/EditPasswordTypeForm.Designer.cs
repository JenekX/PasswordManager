namespace PasswordManager
{
    partial class EditPasswordTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPasswordTypeForm));
            this.tpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblFields = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIsEncrypt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.tpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 2;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.Controls.Add(this.lblFields, 0, 2);
            this.tpMain.Controls.Add(this.lblName, 0, 0);
            this.tpMain.Controls.Add(this.btnCancel, 1, 5);
            this.tpMain.Controls.Add(this.tbName, 0, 1);
            this.tpMain.Controls.Add(this.btnOk, 0, 5);
            this.tpMain.Controls.Add(this.dgvFields, 0, 3);
            this.tpMain.Controls.Add(this.tpButtons, 0, 4);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 6;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.Size = new System.Drawing.Size(284, 262);
            this.tpMain.TabIndex = 0;
            // 
            // lblFields
            // 
            this.tpMain.SetColumnSpan(this.lblFields, 2);
            this.lblFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFields.Location = new System.Drawing.Point(8, 47);
            this.lblFields.Margin = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(268, 13);
            this.lblFields.TabIndex = 2;
            this.lblFields.Text = "Поля типа:";
            // 
            // lblName
            // 
            this.tpMain.SetColumnSpan(this.lblName, 2);
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(8, 8);
            this.lblName.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(268, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Имя типа:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(201, 229);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tpMain.SetColumnSpan(this.tbName, 2);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(8, 24);
            this.tbName.Margin = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(268, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.TbNameTextChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(120, 229);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.AllowUserToDeleteRows = false;
            this.dgvFields.AllowUserToResizeColumns = false;
            this.dgvFields.AllowUserToResizeRows = false;
            this.dgvFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFields.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chName,
            this.chIsEncrypt});
            this.tpMain.SetColumnSpan(this.dgvFields, 2);
            this.dgvFields.Location = new System.Drawing.Point(8, 63);
            this.dgvFields.Margin = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.dgvFields.MultiSelect = false;
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.ReadOnly = true;
            this.dgvFields.RowHeadersVisible = false;
            this.dgvFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFields.Size = new System.Drawing.Size(268, 135);
            this.dgvFields.TabIndex = 3;
            this.dgvFields.SelectionChanged += new System.EventHandler(this.TbNameTextChanged);
            this.dgvFields.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvFieldsKeyDown);
            // 
            // chName
            // 
            this.chName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chName.HeaderText = "Имя";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            this.chName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chIsEncrypt
            // 
            this.chIsEncrypt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chIsEncrypt.FillWeight = 30F;
            this.chIsEncrypt.HeaderText = "Пароль";
            this.chIsEncrypt.Name = "chIsEncrypt";
            this.chIsEncrypt.ReadOnly = true;
            this.chIsEncrypt.Width = 50;
            // 
            // tpButtons
            // 
            this.tpButtons.AutoSize = true;
            this.tpButtons.ColumnCount = 4;
            this.tpMain.SetColumnSpan(this.tpButtons, 2);
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.Controls.Add(this.btnMoveDown, 3, 0);
            this.tpButtons.Controls.Add(this.btnMoveUp, 2, 0);
            this.tpButtons.Controls.Add(this.btnRemove, 1, 0);
            this.tpButtons.Controls.Add(this.btnAdd, 0, 0);
            this.tpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpButtons.Location = new System.Drawing.Point(0, 198);
            this.tpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tpButtons.Name = "tpButtons";
            this.tpButtons.RowCount = 1;
            this.tpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpButtons.Size = new System.Drawing.Size(284, 28);
            this.tpButtons.TabIndex = 4;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveDown.ImageIndex = 4;
            this.btnMoveDown.ImageList = this.imageList;
            this.btnMoveDown.Location = new System.Drawing.Point(101, 3);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(25, 25);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.BtnMoveDownClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Add");
            this.imageList.Images.SetKeyName(1, "Remove");
            this.imageList.Images.SetKeyName(2, "Edit");
            this.imageList.Images.SetKeyName(3, "Up");
            this.imageList.Images.SetKeyName(4, "Down");
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveUp.ImageIndex = 3;
            this.btnMoveUp.ImageList = this.imageList;
            this.btnMoveUp.Location = new System.Drawing.Point(70, 3);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(25, 25);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.BtnMoveUpClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.ImageIndex = 1;
            this.btnRemove.ImageList = this.imageList;
            this.btnRemove.Location = new System.Drawing.Point(39, 3);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(25, 25);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageList = this.imageList;
            this.btnAdd.Location = new System.Drawing.Point(8, 3);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(8, 3, 3, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
            // 
            // EditPasswordTypeForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tpMain);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "EditPasswordTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.tpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chIsEncrypt;
        private System.Windows.Forms.TableLayoutPanel tpButtons;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
    }
}