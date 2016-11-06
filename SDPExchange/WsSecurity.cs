using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "WsSecurity", Namespace = Constants.NsWsse)]
    public class WsSecurity
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlAttribute(AttributeName = "mustUnderstand", Namespace = Constants.NsSoapEnv)]
        public string MustUnderstand { get; set; }

        [XmlElement(ElementName = "UserNameToken", Namespace = Constants.NsWsse)]
        public UserNameToken UserNameToken { get; set; }

        public WsSecurity()
        {
            Xmlns.Add("wsse", Constants.NsWsse);
        }
    }

    [XmlRoot(ElementName = "UserNameToken", Namespace = Constants.NsWsse)]
    public class UserNameToken
    {

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "UserName", Namespace = Constants.NsWsse)]
        public string UserName { get; set; }

        [XmlElement(ElementName = "Password", Namespace = Constants.NsWsse)]
        public Password Password { get; set; }
        
        public UserNameToken()
        {
            Xmlns.Add("wsu", Constants.NsWsu);
        }
    }

    [XmlRoot(ElementName = "Password", Namespace = Constants.NsWsse)]
    public class Password
    {
        [XmlAttribute(AttributeName = "Type")]
        public string Type = Constants.PasswordType;

        [XmlText]
        public string Value { get; set; }
    }
}
