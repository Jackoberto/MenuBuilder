using System;

namespace MenuBuilder
{
    public class ExtraOptionAttribute : Attribute
    {
        public readonly string Description;
        public ExtraOptionAttribute(string description) => Description = description;
    }
}
