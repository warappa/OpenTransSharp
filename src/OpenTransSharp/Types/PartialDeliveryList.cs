using OpenTransSharp.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OpenTransSharp;

/// <summary>
/// (Partial shipment list)<br/>
/// <br/>
/// The element contains information related to items of outstanding partial shipments.<br/>
/// Every partial shipment supposes a PARTIAL_DELIVERY element containing the expected delivery date (DELIVERY_DATE) and quantity (QUANTITY).<br/>
/// <br/>
/// Caution:<br/>
/// The element is only allowed to be used if the element DELIVERY_COMPLETED specifies the value 'FALSE'.<br/>
/// <br/>
/// XML-namespace: OpenTrans
/// </summary>
public class PartialDeliveryList
{
    /// <summary>
    /// <inheritdoc cref="PartialDeliveryList"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public PartialDeliveryList() { }

    /// <summary>
    /// <inheritdoc cref="PartialDeliveryList"/>
    /// </summary>
    /// <param name="partialDeliveries"></param>
    public PartialDeliveryList(IEnumerable<PartialDelivery> partialDeliveries)
    {
        if (partialDeliveries is null)
        {
            throw new ArgumentNullException(nameof(partialDeliveries));
        }

        PartialDeliveries = partialDeliveries.ToList();
    }
    /// <summary>
    /// (required) Partial shipment<br/>
    /// <br/>
    /// Information to a partial shipment.
    /// </summary>
    [OpenTransXmlElement("PARTIAL_DELIVERY")]
    public List<PartialDelivery> PartialDeliveries { get; set; } = new List<PartialDelivery>();
}
