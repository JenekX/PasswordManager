using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManager.Controls
{
    public partial class PasswordEvaluator : UserControl
    {
        public enum Status
        {
            Unknown,
            Empty,
            Low,
            Medium,
            High,
            Best
        }

        public class EvaluatePasswordEventArgs : EventArgs
        {
            public string Password
            {
                get;
                set;
            }

            public Status Status
            {
                get;
                set;
            }
        }

        private const int BlockCount = 8;

        private readonly Brush _borderBrush;
        private readonly Pen _borderPen;
        private readonly Brush _lowBrush;
        private readonly Brush _mediumBrush;
        private readonly Brush _highBrush;
        private readonly Brush _bestBrush;

        private Status _status = Status.Empty;
        private int _currentBlockCount;
        private Brush _currentBrush;

        private string _password;
        private string _errorText;

        private void FillCurrentBrush()
        {
            switch (_status)
            {
                case Status.Unknown:
                case Status.Empty:
                    _currentBlockCount = BlockCount;
                    _currentBrush = _lowBrush;
                    break;
                case Status.Low:
                    _currentBlockCount = 2;
                    _currentBrush = _lowBrush;
                    break;
                case Status.Medium:
                    _currentBlockCount = 4;
                    _currentBrush = _mediumBrush;
                    break;
                case Status.High:
                    _currentBlockCount = 6;
                    _currentBrush = _highBrush;
                    break;
                case Status.Best:
                    _currentBlockCount = BlockCount;
                    _currentBrush = _bestBrush;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string StatusToString()
        {
            switch (_status)
            {
                case Status.Unknown:
                    return "Не задан обработчик";
                case Status.Empty:
                    return "Введите пароль";
                case Status.Low:
                    return "Очень простой";
                case Status.Medium:
                    return "Нормальный";
                case Status.High:
                    return "Хороший";
                case Status.Best:
                    return "Отличный";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CheckPassword()
        {
            if (string.IsNullOrEmpty(ErrorText))
            {
                if (string.IsNullOrEmpty(Password))
                    _status = Status.Empty;
                else
                {
                    var args = new EvaluatePasswordEventArgs
                    {
                        Password = Password,
                        Status = Status.Unknown
                    };

                    if (EvaluatePassword != null)
                        EvaluatePassword(this, args);

                    _status = args.Status;
                }

                FillCurrentBrush();
                lblStatus.Text = StatusToString();
            }
            else
            {
                _currentBlockCount = BlockCount;
                _currentBrush = _lowBrush;

                lblStatus.Text = ErrorText;
            }

            Invalidate();
        }

        public PasswordEvaluator()
        {
            _borderBrush = new SolidBrush(Color.Black);
            _borderPen = new Pen(_borderBrush);
            _lowBrush = new SolidBrush(Color.Red);
            _mediumBrush = new SolidBrush(Color.Orange);
            _highBrush = new SolidBrush(Color.SkyBlue);
            _bestBrush = new SolidBrush(Color.Green);

            InitializeComponent();

            Password = string.Empty;
            ErrorText = string.Empty;
        }

        private void TpMainCellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row != 0 || e.Column != 0)
                return;

            int blockWidth = (e.CellBounds.Width - (BlockCount - 1) * 2)/BlockCount;

            using (var emptyBrush = new SolidBrush(BackColor))
            {
                for (int i = 0; i < BlockCount; i++)
                {
                    var rect = new Rectangle(e.CellBounds.Left + (blockWidth + 2)*i, e.CellBounds.Top, blockWidth, e.CellBounds.Height);
                    e.Graphics.FillRectangle(i < _currentBlockCount ? _currentBrush : emptyBrush, rect);
                    e.Graphics.DrawRectangle(_borderPen, rect);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value ?? string.Empty;

                CheckPassword();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ErrorText
        {
            get
            {
                return _errorText;
            }
            set
            {
                _errorText = value ?? string.Empty;

                CheckPassword();
            }
        }

        public event EventHandler<EvaluatePasswordEventArgs> EvaluatePassword;
    }
}