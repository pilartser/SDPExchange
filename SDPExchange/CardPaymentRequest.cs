using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Envelope", Namespace = Constants.NsSoapEnv)]
    public class CardPaymentRequestMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
        public CardPaymentRequestHeader Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
        public CardPaymentRequestBody Body { get; set; }

        public CardPaymentRequestMessage()
        {
            Xmlns.Add("ser", Constants.NsService);
            Xmlns.Add("soapenv", Constants.NsSoapEnv);
        }
    }

    [XmlRoot(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
    public struct CardPaymentRequestHeader
    {
        [XmlElement(ElementName = "Security", Namespace = Constants.NsWsse)] public WsSecurity Security { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
    public struct CardPaymentRequestBody
    {
        [XmlElement(ElementName = "CardPaymentRequest", Namespace = Constants.NsService)]
        public CardPaymentRequest CardPaymentRequest { get; set; }
    }

    [XmlRoot(ElementName = "CardPaymentrequest", Namespace = Constants.NsService)]
    public struct CardPaymentRequest
    {
        [XmlElement(ElementName = "agentId", Namespace = Constants.NsService)]
        public string AgentId { get; set; }

        [XmlElement(ElementName = "salepointId", Namespace = Constants.NsService)]
        public string SalepointId { get; set; }

        [XmlElement(ElementName = "version", Namespace = Constants.NsService)]
        public string Version { get; set; }

        [XmlElement(ElementName = "sessionId", Namespace = Constants.NsService)]
        public string SessionId { get; set; }

        [XmlElement(ElementName = "tariffId", Namespace = Constants.NsService)]
        public string TariffId { get; set; }

        //Задается в копейках!!!
        [XmlElement(ElementName = "paymentSum", Namespace = Constants.NsService)]
        public int PaymentSum { get; set; }
        
        [XmlElement(ElementName = "paymentInfo", Namespace = Constants.NsService)]
        public string PaymentInfo { get; set; }

        [XmlElement(ElementName = "IDPaymentInfo", Namespace = Constants.NsService)]
        public string IdPaymentInfo { get; set; }
    }
}
