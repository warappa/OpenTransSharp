using System;

namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="PublicKey.Type"/>.
    /// </summary>
    public static class PublicKeyTypeValues
    {
        public static string PGP(Version version) => $"PGP-{version}";
    }
}
