using System.Windows.Forms;

namespace PasswordManager
{
    public partial class FilterForm : Form
    {
        private void Init(string filter)
        {
            Filter = filter;
        }

        public FilterForm()
        {
            InitializeComponent();
        }

        public static bool Execute(IWin32Window owner, string filter, out string result)
        {
            using (var form = new FilterForm())
            {
                form.Init(filter);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    result = form.Filter;
                    return true;
                }

                result = string.Empty;
                return false;
            }
        }

        public string Filter
        {
            get
            {
                return tbFilter.Text;
            }
            set
            {
                tbFilter.Text = value;
            }
        }
    }
}