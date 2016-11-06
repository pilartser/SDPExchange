using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Result", Namespace = Constants.NsService)]
    public class Result
    {
        [XmlElement(ElementName = "resultCode", Namespace = Constants.NsService)]
        public int ResultCode { get; set; }

        [XmlElement(ElementName = "resultCodeText", Namespace = Constants.NsService)]
        public string ResultCodeText { get; set; }
    }
}
