﻿namespace BMEcatSharp;

/// <summary>
/// For <see cref="Startvalue"/> and <see cref="Endvalue"/>.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public enum Intervaltype
{
    /// <summary>
    /// Value included<br/>
    /// <br/>
    /// Indicates that the value is part of the domain.
    /// </summary>
    [XmlEnum("include")]
    Include,
    /// <summary>
    /// Value excluded<br/>
    /// <br/>
    /// Indicates that the value is not part of the domain.
    /// </summary>
    [XmlEnum("exclude")]
    Exclude,
    //[EditorBrowsable(EditorBrowsableState.Never)]
    Undefined
}
