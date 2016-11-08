using System;
using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "CardInfoRequest", Namespace = Constants.NsService)]
    public class CardInfoRequest: SoapBodyContent
    {
        private string _agentId;
        private string _salepointId;
        private int _sysnum;
        private int _regionId;

        [XmlElement(ElementName = "agentId", Namespace = Constants.NsService)]
        public string AgentId
        {
            get { return _agentId; }
            set
            {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("agentId", "", "не может быть null"));
                if (value.Length <= 4) _agentId = value;
                else throw new FormatException(Routines.GenerateErrorCaption("agentId", value, "длина > 4"));
            }
        }

        [XmlElement(ElementName = "salepointId", Namespace = Constants.NsService)]
        public string SalepointId
        {
            get { return _salepointId; }
            set { if (value == null) throw new FormatException(Routines.GenerateErrorCaption("salepointId", "", "не может быть null"));
                  if (value.Length <= 4) _salepointId = value; else throw  new FormatException(Routines.GenerateErrorCaption("salepointId", value, "длина > 4"));}
        }

        [XmlElement(ElementName = "version", Namespace = Constants.NsService)] public string Version;

        [XmlElement(ElementName = "sysNum", Namespace = Constants.NsService)]
        public string SysNum {
            get { return _sysnum.ToString(); }
            set
            {
                if (int.TryParse(value, out _sysnum)) return;
                _sysnum = 0;
                throw new InvalidCastException(Routines.GenerateErrorCaption("sysNum", value, "не int"));
            } 
        }

        [XmlElement(ElementName = "regionId", Namespace = Constants.NsService)]
        public string RegionId {
            get { return _regionId.ToString();}
            set
            {
                if (int.TryParse(value, out _regionId)) return;
                _regionId = 0;
                throw new InvalidCastException(Routines.GenerateErrorCaption("regionId", value, "не int"));
            } 
        }

        [XmlElement(ElementName = "deviceID", Namespace = Constants.NsService)] public string DeviceId;
    }

}
