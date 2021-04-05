using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BMEcatSharp
{
    public abstract class PartyRef<TConcrete>
        where TConcrete : PartyRef<TConcrete>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PartyRef()
        {
            Value = null!;
        }

        public PartyRef(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
            }

            Value = value;
        }

        public PartyRef(string value, string? type)
            : this(value)
        {
            Type = type;
        }


        [XmlAttribute("type")]
        public virtual string? Type { get; set; }

        [XmlText]
        public virtual string Value { get; set; }

        public static explicit operator PartyRef<TConcrete>(TConcrete from)
        {
            return from;
        }

        public static explicit operator TConcrete(PartyRef<TConcrete> value)
        {
            return (TConcrete)value;
        }

        public static explicit operator PartyRef<TConcrete>(PartyId partyId)
        {
            if (partyId is null)
            {
                return null!;
            }

            var to = Activator.CreateInstance<TConcrete>();
            to.Value = partyId.Value;
            to.Type = partyId.Type!;
            return to;
        }
    }
}
