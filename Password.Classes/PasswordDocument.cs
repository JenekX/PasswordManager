using System;
using System.Xml.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class InvalidPasswordException : Exception
    {
    }

    public class PasswordDocument
    {
        private string _fileName;

        private readonly Fields _passwordFields;
        private readonly PasswordTypes _passwordTypes;
        private readonly Passwords _passwords;

        public PasswordDocument()
        {
            IsLoaded = false;
            _fileName = string.Empty;
            DocumentPassword = string.Empty;

            _passwordFields = new Fields(this);
            _passwordTypes = new PasswordTypes(this);
            _passwords = new Passwords(this);
        }

        public void CreateNew(string password)
        {
            IsLoaded = false;
            _fileName = string.Empty;
            DocumentPassword = password;

            _passwordFields.Clear();
            _passwordTypes.Clear();
            _passwords.Clear();
        }

        public void Load(string fileName, string password)
        {
            string tempPassword = DocumentPassword;
            try
            {
                DocumentPassword = password;

                var document = XDocument.Load(fileName);

                var configurationNode = document.Element("configuration");
                if (configurationNode == null)
                    throw new NullReferenceException();

                var passwordAttr = configurationNode.Attribute("password");
                if (passwordAttr == null)
                    throw new NullReferenceException();

                if (!passwordAttr.Value.CompareDocumentPassword(password))
                    throw new InvalidPasswordException();

                var fieldsNode = configurationNode.Element("fields");
                _passwordFields.Load(fieldsNode);

                var typesNode = configurationNode.Element("types");
                _passwordTypes.Load(typesNode);

                var passwordsNode = configurationNode.Element("passwords");
                _passwords.Load(passwordsNode);

                _fileName = fileName;
                IsLoaded = true;
            }
            catch
            {
                DocumentPassword = tempPassword;
                throw;
            }
        }

        public void Save()
        {
            if (!IsLoaded)
                throw new Exception();

            var document = new XDocument();

            var passwordAttr = new XAttribute("password", DocumentPassword.EncodeDocumentPassword());
            var configurationNode = new XElement("configuration", passwordAttr);

            var fieldsNode = new XElement("fields");
            _passwordFields.Save(fieldsNode);

            var typesNode = new XElement("types");
            _passwordTypes.Save(typesNode);

            var passwordsNode = new XElement("passwords");
            _passwords.Save(passwordsNode);

            configurationNode.Add(fieldsNode, typesNode, passwordsNode);

            document.Add(configurationNode);
            document.Save(_fileName);
        }

        public void SaveAs(string fileName)
        {
            _fileName = fileName;
            IsLoaded = true;

            Save();
        }

        public Fields Fields
        {
            get
            {
                return _passwordFields;
            }
        }

        public PasswordTypes Types
        {
            get
            {
                return _passwordTypes;
            }
        }

        public Passwords Passwords
        {
            get
            {
                return _passwords;
            }
        }

        public string DocumentPassword
        {
            get;
            set;
        }

        public bool IsLoaded
        {
            get;
            private set;
        }
    }
}