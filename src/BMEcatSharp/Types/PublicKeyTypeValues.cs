namespace BMEcatSharp;

/// <summary>
/// For <see cref="PublicKey.Type"/>.<br/>
/// <br/>
/// XML-namespace: BMECAT
/// </summary>
public static class PublicKeyTypeValues
{
    public static string PGP(Version version) => $"PGP-{version}";
}
