using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Envelope", Namespace = Constants.NsSoapEnv)]
    public class CardInfoResponseMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
        public string Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
        public CardInfoResponseBody Body { get; set; }

        public CardInfoResponseMessage()
        {
            Xmlns.Add("SOAP-ENV", Constants.NsSoapEnv);
        }
    }

    [XmlRoot(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
    public struct CardInfoResponseBody
    {
        [XmlElement(ElementName = "CardInfoResponse", Namespace = Constants.NsService)]
        public CardInfoResponse CardInfoResponse { get; set; }
    }

    [XmlRoot(ElementName = "CardInfoResponse", Namespace = Constants.NsService)]
    public class CardInfoResponse
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Result", Namespace = Constants.NsService)]
        public Result Result { get; set; }

        [XmlElement(ElementName = "CardInformation", Namespace = Constants.NsService)]
        public CardInformation CardInformation { get; set; }

        public CardInfoResponse()
        {
            Xmlns.Add("ns2", Constants.NsService);
        }
    }

    [XmlRoot(ElementName = "CardInformation", Namespace = Constants.NsService)]
    public struct CardInformation
    {
        [XmlElement(ElementName = "sessionId", Namespace = Constants.NsService)]
        public string SessionId { get; set; }

        [XmlElement(ElementName = "tariff", Namespace = Constants.NsService)]
        public Tariff[] Tariffs { get; set; }

        [XmlElement(ElementName = "company", Namespace = Constants.NsService)]
        public Company Company { get; set; }

        [XmlElement(ElementName = "info", Namespace = Constants.NsService)]
        public CardCheck Info { get; set; }

        [XmlElement(ElementName = "warningMsg", Namespace = Constants.NsService)]
        public string[] WarningMessages { get; set; }
    }

    [XmlRoot(ElementName = "tariff", Namespace = Constants.NsService)]
    public struct Tariff
    {
        [XmlElement(ElementName = "id", Namespace = Constants.NsService)]
        public string Id { get; set; }

        [XmlElement(ElementName = "otype", Namespace = Constants.NsService)]
        public int Otype { get; set; }

        [XmlElement(ElementName = "text", Namespace = Constants.NsService)]
        public string Text { get; set; }

        [XmlElement(ElementName = "minSumInt", Namespace = Constants.NsService)]
        public int MinSumInt { get; set; }

        [XmlElement(ElementName = "maxSumInt", Namespace = Constants.NsService)]
        public int MaxSumInt { get; set; }

        [XmlElement(ElementName = "unaccountedResidueInfo", Namespace = Constants.NsService)]
        public string UnaccountedResidueInfo { get; set; }

        [XmlElement(ElementName = "unaccountedResidueSum", Namespace = Constants.NsService)]
        public int UnaccountedResidueSum { get; set; }
    }

    [XmlRoot(ElementName = "company", Namespace = Constants.NsService)]
    public struct Company
    {
        [XmlElement(ElementName = "name", Namespace = Constants.NsService)]
        public string Name { get; set; }

        [XmlElement(ElementName = "address", Namespace = Constants.NsService)]
        public string Address { get; set; }

        [XmlElement(ElementName = "phone", Namespace = Constants.NsService)]
        public string Phone { get; set; }
    }

    [XmlRoot(ElementName = "info", Namespace = Constants.NsService)]
    public struct CardCheck
    {
        [XmlElement(ElementName = "otype", Namespace = Constants.NsService)]
        public int Otype { get; set; }

        [XmlElement(ElementName = "text", Namespace = Constants.NsService)]
        public string Text { get; set; }

        [XmlElement(ElementName = "unaccountedResidueInfo", Namespace = Constants.NsService)]
        public string UnaccountedResidueInfo { get; set; }

        [XmlElement(ElementName = "unaccountedResidueSum", Namespace = Constants.NsService)]
        public int UnaccountedResidueSum { get; set; }
    }
}
