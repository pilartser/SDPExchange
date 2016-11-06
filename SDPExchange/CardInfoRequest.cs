using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Envelope", Namespace = Constants.NsSoapEnv)]
    public class CardInfoRequestMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
        public CardInfoRequestHeader Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
        public CardInfoRequestBody Body { get; set; }

        public CardInfoRequestMessage()
        {
            Xmlns.Add("ser", Constants.NsService);
            Xmlns.Add("soapenv", Constants.NsSoapEnv);
            
        }
    }

    [XmlRoot(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
    public struct CardInfoRequestHeader
    {
        [XmlElement(ElementName = "Security", Namespace = Constants.NsWsse)]
        public WsSecurity Security { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
    public struct CardInfoRequestBody
    {
        [XmlElement(ElementName = "CardInfoRequest", Namespace = Constants.NsService)] public CardInfoRequest CardInfoRequest;
    }

    [XmlRoot(ElementName = "CardInfoRequest", Namespace = Constants.NsService)]
    public struct CardInfoRequest
    {
        [XmlElement(ElementName = "agentId", Namespace = Constants.NsService)]
        public string AgentId { get; set; }

        [XmlElement(ElementName = "salepointId", Namespace = Constants.NsService)]
        public string SalepointId { get; set; }

        [XmlElement(ElementName = "version", Namespace = Constants.NsService)]
        public string Version { get; set; }

        [XmlElement(ElementName = "sysNum", Namespace = Constants.NsService)]
        public int SysNum { get; set; }

        [XmlElement(ElementName = "regionId", Namespace = Constants.NsService)]
        public int RegionId { get; set; }

        [XmlElement(ElementName = "deviceID", Namespace = Constants.NsService)]
        public string DeviceId { get; set; }
    }

}
