using System;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    public static class UnitExtensions
    {
        public static string? GetXmlName(this Unit? unit)
        {
            if (unit is null)
            {
                return null;
            }

            var memberInfo = typeof(Unit).GetMember(unit.ToString());
            if (memberInfo.Length == 0)
            {
                return unit.ToString();
            }

            var attributes = memberInfo[0].GetCustomAttributes(typeof(XmlEnumAttribute), false);
            if (attributes.Length == 0)
            {
                return unit.ToString();
            }

            var attribute = (XmlEnumAttribute)attributes[0];
            return attribute.Name;
        }
        
        public static Unit? GetStandardUnit(string? unitString)
        {
            return unitString is null ? null : Enum.TryParse<Unit>(unitString, out var parsedUnit) ? parsedUnit : null;
        }
    }
}
