using System;
using System.Xml.Linq;

namespace Password.Classes.Core
{
    public abstract class CustomTableRow
    {
        protected CustomTableRow()
        {
            ID = Guid.NewGuid();
        }

        public virtual void Load(XElement node)
        {
            ID = node.GetAttributeValue("id").ToGuid();
        }

        public virtual void Save(XElement node)
        {
            node.Add(new XAttribute("id", ID));
        }

        public override bool Equals(object obj)
        {
            var row = obj as CustomTableRow;
            return row != null && row.ID == ID;
        }
        
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public Guid ID
        {
            get;
            private set;
        }
    }

    public abstract class CustomTableRow<TParent> : CustomTableRow where TParent : class
    {
        protected CustomTableRow(TParent parent)
        {
            Parent = parent;
        }

        public bool Equals(CustomTableRow<TParent> row)
        {
            return row.ID == ID;
        }

        public TParent Parent
        {
            get;
            private set;
        }
    }
}