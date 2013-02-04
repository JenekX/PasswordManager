using System.Xml.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class Field : CustomTableRow<Fields>
    {
        public Field(Fields parent, string name = "", bool isEncrypt = false) : base(parent)
        {
            Name = name;
            IsEncrypt = isEncrypt;
        }

        public override void Load(XElement node)
        {
            base.Load(node);
            
            Name = node.GetAttributeValue("name");
            IsEncrypt = node.GetAttributeValue("encrypt").ToBool();
        }

        public override void Save(XElement node)
        {
            base.Save(node);

            node.Add(new XAttribute("name", Name), new XAttribute("encrypt", IsEncrypt));
        }

        public string Name
        {
            get;
            set;
        }

        public bool IsEncrypt
        {
            get;
            set;
        }
    }
}