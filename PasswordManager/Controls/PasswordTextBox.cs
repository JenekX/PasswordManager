using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PasswordManager.Classes;

namespace PasswordManager.Controls
{
    internal partial class PasswordTextBox : UserControl
    {
        private void BtnGenerateClick(object sender, EventArgs e)
        {
            if (Configuration == null)
                return;

            tbValue.Text = PasswordHelper.CreatePassword(Configuration);
        }

        public PasswordTextBox()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Configuration Configuration
        {
            get;
            set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override sealed string Text
        {
            get
            {
                return tbValue.Text;
            }
            set
            {
                tbValue.Text = value;
            }
        }
    }
}
