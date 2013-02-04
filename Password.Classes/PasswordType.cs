using System;
using System.Xml.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class PasswordType : CustomTableRow<PasswordTypes>
    {
        public PasswordType(PasswordTypes parent, string name = "") : base(parent)
        {
            Name = name;
            Fields = new PasswordFields(parent.Owner);
        }

        public override void Load(XElement node)
        {
            base.Load(node);

            Name = node.GetAttributeValue("name");
            
            var fieldsNode = node.Element("fields");
            if (fieldsNode == null)
                throw new Exception();

            Fields.Load(fieldsNode);
        }

        public override void Save(XElement node)
        {
            base.Save(node);

            var fieldsNode = new XElement("fields");
            Fields.Save(fieldsNode);

            node.Add(new XAttribute("name", Name), fieldsNode);
        }

        public string Name
        {
            get;
            set;
        }

        public PasswordFields Fields
        {
            get;
            private set;
        }
    }
}