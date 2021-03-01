using System.ComponentModel;

namespace OpenTransSharp
{
    /// <summary>
    /// (Package dimensions)<br/>
    /// <br/>
    /// This element contains information on the package dimension from the view of business logistics.<br/>
    /// <br/>
    /// XML-namespace: OpenTrans
    /// </summary>
    public class PackageDimensions
    {
        /// <summary>
        /// (optional) Volume<br/>
        /// <br/>
        /// Volume in cubic meters (m³).
        /// </summary>
        [BMEXmlElement("VOLUME")]
        public decimal? Volume { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool VolumeSpecified => Volume.HasValue;

        /// <summary>
        /// (optional) Weight<br/>
        /// <br/>
        /// Weight in kilogram (kg).
        /// </summary>
        [BMEXmlElement("WEIGHT")]
        public decimal? Weight { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WeightSpecified => Weight.HasValue;

        /// <summary>
        /// (optional) Length<br/>
        /// <br/>
        /// Length in meters (m).
        /// </summary>
        [BMEXmlElement("LENGTH")]
        public decimal? Length { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LengthSpecified => Length.HasValue;

        /// <summary>
        /// (optional) Width<br/>
        /// <br/>
        /// Width in meters (m).
        /// </summary>
        [BMEXmlElement("WIDTH")]
        public decimal? Width { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WidthSpecified => Width.HasValue;

        /// <summary>
        /// (optional) Depth<br/>
        /// <br/>
        /// Depth in meters (m).
        /// </summary>
        [BMEXmlElement("DEPTH")]
        public decimal? Depth { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DepthSpecified => Depth.HasValue;
    }
}
