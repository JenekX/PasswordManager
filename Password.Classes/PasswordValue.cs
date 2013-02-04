using System;
using System.Xml.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class PasswordValue : CustomTableRow<PasswordValues>
    {
        public override void Load(XElement node)
        {
            throw new NotSupportedException();
        }

        public override void Save(XElement node)
        {
            var value = Field.IsEncrypt ? Value.EncodePassword(Parent.Owner.DocumentPassword) : Value;

            node.Add(new XAttribute("field", Field.ID), new XAttribute("value", value));
        }

        public PasswordValue(PasswordValues parent) : base(parent)
        {
            Field = null;
            Value = string.Empty;
        }

        public Field Field
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
}