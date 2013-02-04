using System;
using System.Xml.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class PasswordFields : CustomTable<PasswordDocument, Field>
    {
        protected override string GetElementName()
        {
            return "field";
        }

        protected override Field NewRow()
        {
            throw new NotSupportedException();
        }

        public PasswordFields(PasswordDocument owner) : base(owner)
        {
        }

        public new void Add(Field field)
        {
            base.Add(field);
        }

        public void AddRange(Field[] fields)
        {
            foreach (var field in fields)
                Add(field);
        }

        public override void Load(XElement node)
        {
            Clear();

            var elements = node.Elements();
            foreach (var element in elements)
            {
                var id = element.GetAttributeValue("id").ToGuid();
                var item = Owner.Fields[id];
                Add(item);
            }
        }

        public override void Save(XElement node)
        {
            var elementName = GetElementName();

            foreach (var item in this)
            {
                var elem = new XElement(elementName, new XAttribute("id", item.ID));
                node.Add(elem);
            }
        }
    }
}