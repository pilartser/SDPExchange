using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "CardPaymentResponse", Namespace = Constants.NsService)]
    public class CardPaymentResponse : SoapBodyContent
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Result", Namespace = Constants.NsService)]
        public Result Result { get; set; }

        [XmlElement(ElementName = "CardPaymentInformation", Namespace = Constants.NsService)]
        public CardPaymentInformation CardPaymentInformation { get; set; }

        public CardPaymentResponse()
        {
            Xmlns.Add("ns2", Constants.NsService);
        }
    }

    [XmlRoot(ElementName = "CardPaymentInformation", Namespace = Constants.NsService)]
    public struct CardPaymentInformation
    {
        [XmlElement(ElementName = "sessionId", Namespace = Constants.NsService)]
        public string SessionId { get; set; }

        [XmlElement(ElementName = "cheq", Namespace = Constants.NsService)]
        public string Cheq { get; set; }

        [XmlElement(ElementName = "fullSum", Namespace = Constants.NsService)]
        public int FullSum { get; set; }
    }
}
