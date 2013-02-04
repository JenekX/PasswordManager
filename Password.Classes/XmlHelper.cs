using System;
using System.Xml.Linq;

namespace Password.Classes
{
    internal static class XmlHelper
    {
        public static string GetAttributeValue(this XElement node, string name)
        {
            var attr = node.Attribute(name);
            if (attr == null)
                throw new NullReferenceException();

            return attr.Value;
        }
    }
}