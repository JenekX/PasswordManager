using Password.Classes.Core;

namespace Password.Classes
{
    public class Passwords : CustomTable<PasswordDocument, Password>
    {
        public Passwords(PasswordDocument owner) : base(owner)
        {
        }

        protected override string GetElementName()
        {
            return "password";
        }

        protected override Password NewRow()
        {
            return new Password(this);
        }
    }
}