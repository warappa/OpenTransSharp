namespace OpenTransSharp
{
    /// <summary>
    /// For <see cref="MeansOfTransport"/>.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public static class MeansOfTransportTypeValues
    {
        /// <summary>
        /// The goods will be transported by air.
        /// </summary>
        public const string Air = "air";

        /// <summary>
        /// The goods will be transported by sea.
        /// </summary>
        public const string Maritime = "maritime";

        /// <summary>
        /// The goods are transported "multi-modally". This could be used to describe a container, for example, which is directly connected to the goods.
        /// </summary>
        public const string Multimodal = "multimodal";

        /// <summary>
        /// The goods will be transported by rail.
        /// </summary>
        public const string Rail = "rail";

        /// <summary>
        /// The goods will be transported by road.
        /// </summary>
        public const string Road = "road";
    }
}
