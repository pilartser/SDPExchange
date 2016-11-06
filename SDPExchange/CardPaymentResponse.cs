using System.Xml.Serialization;

namespace SoapTest1
{
    [XmlRoot(ElementName = "Envelope", Namespace = Constants.NsSoapEnv)]
    public class CardPaymentResponseMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
        public string Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
        public CardPaymentResponseBody
            Body { get; set; }

        public CardPaymentResponseMessage()
        {
            Xmlns.Add("SOAP-ENV", Constants.NsSoapEnv);
        }
    }

    [XmlRoot(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
    public struct CardPaymentResponseBody
    {
        [XmlElement(ElementName = "CardPaymentResponse", Namespace = Constants.NsService)] public CardPaymentResponse
            CardPaymentResponse;
    }

    [XmlRoot(ElementName = "CardPaymentResponse", Namespace = Constants.NsService)]
    public class CardPaymentResponse
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
