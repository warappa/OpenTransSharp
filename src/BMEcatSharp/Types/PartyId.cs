﻿namespace BMEcatSharp;

/// <summary>
/// (ID of the business partner)<br/>
/// <br/>
/// This element contains the unique identifier of the business partner.<br/>
/// PARTY_ID has to be specified if the ADDRESS element is not used in order to uniquely identify the business partner.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public class PartyId
{
    /// <summary>
    /// <inheritdoc cref="PartyId"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PartyId()
    {
        Value = null!;
    }

    /// <summary>
    /// <inheritdoc cref="Party"/>
    /// </summary>
    /// <param name="value"></param>
    public PartyId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"'{nameof(value)}' cannot be null or whitespace.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// <inheritdoc cref="Party"/>
    /// </summary>
    /// <param name="value"></param>
    /// <param name="type">Einige gängige Kodifikationssysteme sind vordefiniert. Für vordefinierte Werte siehe <see cref="PartyTypeValues"/>, es können aber auch ein eigene Werte verwendet werden.</param>
    public PartyId(string value, string? type)
        : this(value)
    {
        Type = type;
    }

    /// <summary>
    /// (optional) This attribute is used to state the coding standard to which the identifier (PARTY_ID) adheres.<br/>
    /// <br/>
    /// The most common coding standards are predefined - see <see cref="PartyTypeValues"/>.<br/>
    /// But custom values are also possible
    /// </summary>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    /// (required)<br/>
    /// <br/>
    /// Max length: 250
    /// </summary>
    [XmlText]
    public string Value { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is PartyId id &&
               Type == id.Type &&
               Value == id.Value;
    }

    public override int GetHashCode()
    {
        var hashCode = 1265339359;
        hashCode = hashCode * -1521134295 + EqualityComparer<string?>.Default.GetHashCode(Type);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
        return hashCode;
    }

    public static bool operator ==(PartyId? left, PartyId? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }
        if (left is null ||
            right is null)
        {
            return false;
        }

        return EqualityComparer<PartyId>.Default.Equals(left, right);
    }

    public static bool operator !=(PartyId? left, PartyId? right)
    {
        return !(left == right);
    }

    public static implicit operator PartyIdRef(PartyId id)
    {
        if (id is null)
        {
            return null!;
        }

        return new PartyIdRef(id.Value, id.Type);
    }
}
