using System;
using System.Linq;
using Password.Classes.Core;

namespace Password.Classes
{
    public class PasswordTypes : CustomTable<PasswordDocument, PasswordType>
    {
        public PasswordTypes(PasswordDocument owner) : base(owner)
        {
        }

        protected override string GetElementName()
        {
            return "type";
        }

        protected override PasswordType NewRow()
        {
            return new PasswordType(this);
        }

        public override bool CanRemove(PasswordType row)
        {
            return Owner.Passwords.Count(x => x.PasswordType.Equals(row)) == 0;
        }

        public override void Remove(PasswordType passwordType)
        {
            var rows = Owner.Passwords.Where(x => x.PasswordType.Equals(passwordType));
            foreach (var row in rows)
                Owner.Passwords.Remove(row);

            base.Remove(passwordType);
        }
    }
}