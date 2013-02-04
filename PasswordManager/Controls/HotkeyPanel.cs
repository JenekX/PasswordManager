using System;
using System.Windows.Forms;

namespace PasswordManager.Controls
{
    public partial class HotkeyPanel : Form
    {
        private void Fill()
        {
            var keys = new[]
            {
                Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L,
                Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z,
                Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
                Keys.Up, Keys.Down, Keys.Left, Keys.Right,
                Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12,
                Keys.Insert, Keys.Delete, Keys.PageUp, Keys.PageDown, Keys.Home, Keys.End, Keys.Tab
            };

            foreach (var key in keys)
                cmbKey.Items.Add(key);
        }

        public HotkeyPanel()
        {
            InitializeComponent();

            Fill();
            Deactivate += BtnOkClick;
        }

        public Keys Key
        {
            get
            {
                var result = Keys.None;

                if (cbCtrl.Checked)
                    result |= Keys.Control;

                if (cbAlt.Checked)
                    result |= Keys.Alt;

                if (cbShift.Checked)
                    result |= Keys.Shift;

                result |= (Keys)cmbKey.SelectedItem;

                return result;
            }
            set
            {
                cbCtrl.Checked = value.HasFlag(Keys.Control);
                cbAlt.Checked = value.HasFlag(Keys.Alt);
                cbShift.Checked = value.HasFlag(Keys.Shift);

                if (cbCtrl.Checked)
                    value -= Keys.Control;
                if (cbAlt.Checked)
                    value -= Keys.Alt;
                if (cbShift.Checked)
                    value -= Keys.Shift;

                cmbKey.SelectedItem = value;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Hide();
        }
    }
}