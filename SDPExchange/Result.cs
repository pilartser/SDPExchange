using System.Xml.Serialization;

namespace SoapTest1
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
