using System;
using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "Envelope", Namespace = Constants.NsSoapEnv)]
    public class CardInfoRequestMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Header", Namespace = Constants.NsSoapEnv)] public CardInfoRequestHeader Header;

        [XmlElement(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
        public CardInfoRequestBody Body;

        public CardInfoRequestMessage()
        {
            Xmlns.Add("ser", Constants.NsService);
            Xmlns.Add("soapenv", Constants.NsSoapEnv);
            
        }
    }

    [XmlRoot(ElementName = "Header", Namespace = Constants.NsSoapEnv)]
    public struct CardInfoRequestHeader
    {
        [XmlElement(ElementName = "Security", Namespace = Constants.NsWsse)] public WsSecurity Security;
    }

    [XmlRoot(ElementName = "Body", Namespace = Constants.NsSoapEnv)]
    public struct CardInfoRequestBody
    {
        [XmlElement(ElementName = "CardInfoRequest", Namespace = Constants.NsService)]
        public CardInfoRequest CardInfoRequest;
    }

    

    [XmlRoot(ElementName = "CardInfoRequest", Namespace = Constants.NsService)]
    public struct CardInfoRequest
    {
        private string _agentId;
        private string _salepointId;
        private int _sysnum;
        private int _regionId;

        [XmlElement(ElementName = "agentId", Namespace = Constants.NsService)]
        public string AgentId {
            get { return _agentId; }
            set
            {
                if (value == null) throw new FormatException("FormatException: agentId is null");
                if (value.Length <= 4) _agentId = value; else throw new FormatException($"FormatException: agentId.Length > 4, value \"{value}\""); }
        }

        [XmlElement(ElementName = "salepointId", Namespace = Constants.NsService)]
        public string SalepointId
        {
            get { return _salepointId; }
            set { if (value == null) throw new FormatException("FormatException: salepointId is null");
                  if (value.Length <= 4) _salepointId = value; else throw  new FormatException($"FormatException: salepointId.Length > 4, value \"{value}\"");}
        }

        [XmlElement(ElementName = "version", Namespace = Constants.NsService)] public string Version;

        [XmlElement(ElementName = "sysNum", Namespace = Constants.NsService)]
        public string SysNum {
            get { return _sysnum.ToString(); }
            set
            {
                if (int.TryParse(value, out _sysnum)) return;
                _sysnum = 0;
                throw new InvalidCastException($"CastException: _sysnum, value \"{value}\"");
            } 
        }

        [XmlElement(ElementName = "regionId", Namespace = Constants.NsService)]
        public string RegionId {
            get { return _regionId.ToString();}
            set
            {
                if (int.TryParse(value, out _regionId)) return;
                _regionId = 0;
                throw new InvalidCastException($"CastException: _regionId, value \"{value}\"");
            } 
        }

        [XmlElement(ElementName = "deviceID", Namespace = Constants.NsService)] public string DeviceId;
    }

}
