using System;

namespace Library.Infrastracture
{
    public class LabelAttribute :Attribute
    {
        public string LabelText { get; set; }
        public LabelAttribute(string labelText)
        {
            LabelText = labelText;
        }
    }
}
