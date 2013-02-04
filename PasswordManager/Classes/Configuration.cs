using System.Windows.Forms;
using XConfig;

namespace PasswordManager.Classes
{
    internal class Configuration : XConfigElement
    {
        public override void Clear()
        {
            PasswordLength = 8;
            AllowChars = string.Empty;
            ShowShortcut = Keys.None;
        }

        [XAttributeBinding("passwordlength", DefaultValue = 8, IsRequired = false)]
        [XRangeValidation(Min = 2, Max = 32)]
        public int PasswordLength
        {
            get;
            set;
        }

        [XAttributeBinding("allowchars")]
        public string AllowChars
        {
            get;
            set;
        }

        [XAttributeBinding("showshortcut", DefaultValue = Keys.None, IsRequired = false)]
        public Keys ShowShortcut
        {
            get;
            set;
        }
    }
}