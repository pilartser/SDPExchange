using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Envelope", Namespace = Constants.NsSoapEnv)]
    public class SoapMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
        public SoapHeader Header;

        [XmlElement(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
        public SoapBody Body;

        public SoapMessage()
        {
            Header = new SoapHeader();
            Body = new SoapBody();
        }
    }

    [XmlRoot(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
    public struct SoapHeader
    {
        [XmlElement(ElementName = "Security", Namespace = Constants.NsWsse)]
        public WsSecurity Security;
    }

    [XmlRoot(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
    public class SoapBody
    {
        [XmlElement(typeof(CardInfoRequest), ElementName = "CardInfoRequest", Namespace = Constants.NsService)]
        [XmlElement(typeof(CardPaymentRequest), ElementName = "CardPaymentRequest", Namespace = Constants.NsService)]
        [XmlElement(typeof(CardInfoResponse), ElementName = "CardInfoResponse", Namespace = Constants.NsService)]
        [XmlElement(typeof(CardPaymentResponse), ElementName = "CardPaymentResponse", Namespace = Constants.NsService)]
        public SoapBodyContent Content;
    }

    public abstract class SoapBodyContent
    {
    }
}
