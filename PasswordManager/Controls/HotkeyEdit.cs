using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManager.Controls
{
    public partial class HotkeyEdit : UserControl
    {
        private readonly HotkeyPanel _panel;
        private Keys _key;

        private void BtnEditClick(object sender, EventArgs e)
        {
            var p = PointToScreen(new Point(btnEdit.Left, btnEdit.Bottom));
            _panel.Location = p;
            _panel.Show();
        }

        public HotkeyEdit()
        {
            InitializeComponent();

            _panel = new HotkeyPanel();
            _panel.VisibleChanged += PanelVisibleChanged;
        }

        private void PanelVisibleChanged(object sender, EventArgs args)
        {
            if (_panel.Visible)
                return;

            Key = _panel.Key;
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
        public Keys Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;

                string text = string.Empty;
                
                if (value.HasFlag(Keys.Control))
                {
                    text = "Control + ";
                    value -= Keys.Control;
                }

                if (value.HasFlag(Keys.Alt))
                {
                    text += "Alt + ";
                    value -= Keys.Alt;
                }

                if (value.HasFlag(Keys.Shift))
                {
                    text += "Shift + ";
                    value -= Keys.Shift;
                }

                text += value.ToString("G");

                tbValue.Text = text;
            }
        }
    }
}