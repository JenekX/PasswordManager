using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

using Password.Classes;
using PasswordManager.Classes;

namespace PasswordManager
{
    internal partial class PasswordTypeTabControl : UserControl
    {
        private Configuration _configuration;
        private PasswordDocument _document;
        private string _filter;

        public PasswordTypeTab FindTypeTab(PasswordType passwordType)
        {
            return Tabs.FirstOrDefault(tab => tab.PasswordType.Equals(passwordType));
        }

        private void AddTypeTab(PasswordType passwordType)
        {
            var tab = new PasswordTypeTab(passwordType, Configuration);
            Tabs.Add(tab);
        }

        private void Fill()
        {
            Tabs.Clear();

            if (Configuration == null || Document == null)
                return;

            foreach (var passwordType in _document.Types)
                AddTypeTab(passwordType);

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            foreach (var tab in Tabs)
                tab.Filter = Filter;
        }

        public PasswordTypeTabControl()
        {
            InitializeComponent();
            
            Tabs = new PasswordTypeTabCollection(tcPasswordTypes.TabPages);
        }
        
        public void AddPassword(bool needChoosePasswordType)
        {
        	var password = Document.Passwords.Add();
        	
        	if (!needChoosePasswordType && SelectedTab != null)
        		password.PasswordType = SelectedTab.PasswordType;
        	
        	var args = new PasswordAddEventArgs(password, needChoosePasswordType);
        	
        	if (OnAddPassword != null)
        		OnAddPassword(this, args);
        	
        	if (!args.Success)
        	{
        		Document.Passwords.Remove(password);
        		return;
        	}
        		
        	UpdateTabs();

            var tab = FindTypeTab(password.PasswordType);
            if (tab == null)
                return;
            
            tab.SelectedPassword = password;
            SelectedTab = tab;
        }
        
        public void RemovePassword()
        {
        	var tab = SelectedTab;
            if (tab == null)
                return;

            var password = tab.SelectedPassword;
            if (password == null)
                return;

            var args = new PasswordEventArgs(password);
            
            if (OnRemovePassword != null)
            	OnRemovePassword(this, args);
            
            if (!args.Success)
            	return;

            Document.Passwords.Remove(password);
            tab.UpdatePasswords();
        }

        public void EditPassword()
        {
        	var tab = SelectedTab;
            if (tab == null)
                return;

            var password = tab.SelectedPassword;
            if (password == null)
                return;

            var args = new PasswordEventArgs(password);
            
            if (OnEditPassword != null)
            	OnEditPassword(this, args);
            
            if (!args.Success)
            	return;
            
            tab.UpdatePasswords();
        }
        
        public void UpdateTabs()
        {
            var visited = Tabs.ToDictionary(x => x, y => false);

            foreach (var passwordType in Document.Types)
            {
                var tab = Tabs.SingleOrDefault(t => t.PasswordType.Equals(passwordType));
                if (tab == null)
                    AddTypeTab(passwordType);
                else
                {
                    tab.UpdatePasswords();
                    visited[tab] = true;
                }
            }

            var tabs = visited.Where(x => !x.Value).Select(x => x.Key).ToArray();
            foreach (var tab in tabs)
                Tabs.Remove(tab);

            int count = 0;
            tabs = Tabs.ToArray();
            var types = Document.Types.ToArray();
            for (int i = 0; i < tabs.Length; i++)
                if (tabs[i].PasswordType.Equals(types[i]))
                    count++;

            if (tabs.Length == count)
                return;

            int j = 0;
            foreach (var documentType in Document.Types)
            {
                var tab = tabs.Single(x => x.PasswordType.Equals(documentType));
                Tabs.Remove(tab);
                Tabs.Insert(j++, tab);
            }

            ApplyFilter();
        }

        public Configuration Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                _configuration = value;

                Fill();
            }
        }

        public PasswordDocument Document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value;

                Fill();
            }
        }

        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value ?? string.Empty;

                ApplyFilter();
            }
        }

        public PasswordTypeTabCollection Tabs
        {
            get;
            private set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PasswordTypeTab SelectedTab
        {
            get
            {
                return tcPasswordTypes.SelectedTab as PasswordTypeTab;
            }
            set
            {
                tcPasswordTypes.SelectTab(value);
            }
        }
        
        public event EventHandler<PasswordAddEventArgs> OnAddPassword;
        public event EventHandler<PasswordEventArgs> OnRemovePassword;
        public event EventHandler<PasswordEventArgs> OnEditPassword;
    }
    
    internal class PasswordEventArgs : EventArgs
    {
    	public PasswordEventArgs(Password.Classes.Password password)
    	{
    		Success = false;
    		Password = password;
    	}
    	
        public bool Success
        {
            get;
            set;
        }

        public Password.Classes.Password Password
        {
            get;
            private set;
        }
    }
    
    internal class PasswordAddEventArgs : PasswordEventArgs
    {
    	public PasswordAddEventArgs(Password.Classes.Password password, bool needChoosePasswordType) : base(password)
    	{
    		NeedChoosePasswordType = needChoosePasswordType;
    	}
    	
    	public bool NeedChoosePasswordType
    	{
    		get;
    		set;
    	}
    }
}