using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "CardPaymentrequest", Namespace = Constants.NsService)]
    public class CardPaymentRequest: SoapBodyContent
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
