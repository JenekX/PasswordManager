using System.Xml.Linq;
using Password.Classes.Core;
using System.Linq;

namespace Password.Classes
{
    public class PasswordValues : CustomTable<PasswordDocument, PasswordValue>
    {
        public PasswordValues(Password parent) : base(parent.Parent.Owner)
        {
            Parent = parent;
        }

        protected override string GetElementName()
        {
            return "value";
        }

        protected override PasswordValue NewRow()
        {
            return new PasswordValue(this);
        }

        public void SetValues(PasswordFields fields)
        {
            Clear();

            foreach (var field in fields)
            {
                var value = Add();
                value.Field = field;
            }
        }

        public override void Load(XElement node)
        {
            var elements = node.Elements();
            foreach (var element in elements)
            {
                var fieldID = element.GetAttributeValue("field").ToGuid();
                var field = this.Single(x => x.Field.ID == fieldID);
                var value = element.GetAttributeValue("value");
                field.Value = field.Field.IsEncrypt ? value.DecodePassword(Owner.DocumentPassword) : value;
            }
        }

        public Password Parent
        {
            get;
            private set;
        }
    }
}