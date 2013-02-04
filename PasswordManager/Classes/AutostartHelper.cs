using Microsoft.Win32;

namespace PasswordManager.Classes
{
    public class AutostartHelper
    {
        public virtual string ProgramName
        {
            get;
            set;
        }

        public virtual string ProgramPath
        {
            get;
            set;
        }

        public virtual string ProgramArguments
        {
            get;
            set;
        }

        public virtual bool IsForAllUsers
        {
            get;
            set;
        }

        private RegistryKey Open()
        {
            var key = IsForAllUsers ? Registry.LocalMachine : Registry.CurrentUser;
            key = key.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            return key;
        }

        private string GetFullProgramPath()
        {
            if (string.IsNullOrEmpty(ProgramArguments))
                return ProgramPath;

            return string.Format("{0} {1}", ProgramPath, ProgramArguments);
        }

        public bool Register()
        {
            var key = Open();
            key.SetValue(ProgramName, GetFullProgramPath());

            return true;
        }

        public bool Unregister()
        {
            var key = Open();
            key.DeleteValue(ProgramName);

            return true;
        }

        public bool IsRegistred
        {
            get
            {
                var key = Open();
                return key.GetValue(ProgramName) != null;
            }
            set
            {
                if (IsRegistred == value)
                    return;

                if (value)
                    Register();
                else
                    Unregister();
            }
        }
    }
}