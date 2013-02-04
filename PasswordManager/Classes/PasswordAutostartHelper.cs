using System;
using System.Windows.Forms;

namespace PasswordManager.Classes
{
    internal class PasswordAutostartHelper : AutostartHelper
    {
        public override string ProgramName
        {
            get
            {
                return "Password Manager";
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override string ProgramPath
        {
            get
            {
                return Application.ExecutablePath;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override string ProgramArguments
        {
            get
            {
                return string.Empty;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override bool IsForAllUsers
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
    }
}
