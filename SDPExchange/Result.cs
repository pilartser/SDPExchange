using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Result", Namespace = Constants.NsService)]
    public struct Result
    {
        private string _resultCodeText;

        [XmlElement(ElementName = "resultCode", Namespace = Constants.NsService)]
        public int ResultCode { get; set; }

        [XmlElement(ElementName = "resultCodeText", Namespace = Constants.NsService)]
        public string ResultCodeText {
            get { return _resultCodeText ?? ""; }
            set { _resultCodeText = value; }
        }
    }
}
