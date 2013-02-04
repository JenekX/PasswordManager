using System;
using System.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class Fields : CustomTable<PasswordDocument, Field>
    {
        protected override string GetElementName()
        {
            return "field";
        }

        protected override Field NewRow()
        {
            return new Field(this);
        }

        public Fields(PasswordDocument owner) : base(owner)
        {
        }

        public override bool CanRemove(Field field)
        {
            return Owner.Types.Count(x => x.Fields.Any(y => y.Equals(field))) == 0;
        }
        
        public override void Remove(Field field)
        {
            var types = Owner.Types.Where(x => x.Fields.Any(y => y.Equals(field)));
            foreach (var type in types)
                type.Fields.Remove(field);

            base.Remove(field);
        }
    }
}