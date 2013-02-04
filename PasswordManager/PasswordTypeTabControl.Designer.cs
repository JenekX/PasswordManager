namespace PasswordManager
{
    partial class PasswordTypeTabControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcPasswordTypes = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tcPasswordTypes
            // 
            this.tcPasswordTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPasswordTypes.Location = new System.Drawing.Point(0, 0);
            this.tcPasswordTypes.Name = "tcPasswordTypes";
            this.tcPasswordTypes.SelectedIndex = 0;
            this.tcPasswordTypes.Size = new System.Drawing.Size(487, 207);
            this.tcPasswordTypes.TabIndex = 0;
            // 
            // PasswordTypeTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcPasswordTypes);
            this.Name = "PasswordTypeTabControl";
            this.Size = new System.Drawing.Size(487, 207);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPasswordTypes;
    }
}
