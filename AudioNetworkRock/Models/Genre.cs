using System;
using System.Reflection;

namespace AudioNetworkRock.Models
{
    public enum Genre
    {
        [StringValue("rock")]
        Rock,
        [StringValue("electronic")]
        Electronic,
        [StringValue("classical")]
        Classical
    }

    internal class StringValueAttribute : Attribute
    {
        public string StringValue { get; private set; }

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }

    public static class EnumExtention
    {
        public static string toString(this Genre value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            StringValueAttribute[] attribs = fieldInfo
                .GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 
                ? attribs[0].StringValue 
                : string.Empty;
        }
    }
}