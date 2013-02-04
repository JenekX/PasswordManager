using System.Xml.Linq;
using Password.Classes.Core;
using System.Linq;

namespace Password.Classes
{
    public class Password : CustomTableRow<Passwords>
    {
        private PasswordType _passwordType;

        public Password(Passwords parent) : base(parent)
        {
            Values = new PasswordValues(this);
            PasswordType = null;
        }

        public override void Load(XElement node)
        {
            base.Load(node);
            
            var id = node.GetAttributeValue("type").ToGuid();
            PasswordType = Parent.Owner.Types[id];

            var valuesNode = node.Element("values");
            Values.Load(valuesNode);
        }

        public override void Save(XElement node)
        {
            base.Save(node);

            var valuesNode = new XElement("values");
            Values.Save(valuesNode);

            node.Add(new XAttribute("type", PasswordType.ID), valuesNode);
        }

        public PasswordType PasswordType
        {
            get
            {
                return _passwordType;
            }
            set
            {
                if (_passwordType != null)
                {
                    _passwordType.Fields.RowAdded -= FieldsRowAdded;
                    _passwordType.Fields.RowRemoved -= FieldsRowRemoved;
                }

                if (value == null)
                    Values.Clear();
                else
                    Values.SetValues(value.Fields);

                _passwordType = value;

                if (_passwordType != null)
                {
                    _passwordType.Fields.RowAdded += FieldsRowAdded;
                    _passwordType.Fields.RowRemoved += FieldsRowRemoved;
                }
            }
        }

        private void FieldsRowAdded(object sender, PasswordFields.RowEventArgs e)
        {
            var value = Values.Add();
            value.Field = e.Row;
        }

        private void FieldsRowRemoved(object sender, PasswordFields.RowEventArgs e)
        {
            var value = Values.Single(x => x.Field.Equals(e.Row));

            Values.Remove(value);
        }

        public PasswordValues Values
        {
            get;
            set;
        }
    }
}