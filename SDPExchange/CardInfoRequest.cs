using System;
using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "CardInfoRequest", Namespace = Constants.NsService)]
    public class CardInfoRequest : SoapMessage
    {
        private string _version;
        private string _agentId;
        private string _salepointId;
        private int _sysnum;
        private int _regionId;

        [XmlElement(ElementName = "version", Namespace = Constants.NsService)]
        public string Version {
            get { return _version ?? "";}
            set
            {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("version", "не может быть null"));
                _version = value;
            }
        }

        [XmlElement(ElementName = "agentId", Namespace = Constants.NsService)]
        public string AgentId
        {
            get { return _agentId ?? ""; }
            set
            {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("agentId", "не может быть null"));
                if (value.Length > 4)
                    throw new FormatException(Routines.GenerateErrorCaption("agentId", "длина > 4", value));
                _agentId = value;
            }
        }

        [XmlElement(ElementName = "salepointId", Namespace = Constants.NsService)]
        public string SalepointId
        {
            get { return _salepointId ?? ""; }
            set
            {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("salepointId", "не может быть null"));
                if (value.Length > 4)
                    throw new FormatException(Routines.GenerateErrorCaption("salepointId", "длина > 4", value));
                _salepointId = value;
            }
        }

        [XmlElement(ElementName = "sysNum", Namespace = Constants.NsService)]
        public string SysNum
        {
            get { return _sysnum.ToString(); }
            set
            {
                if (int.TryParse(value, out _sysnum)) return;
                throw new InvalidCastException(Routines.GenerateErrorCaption("sysNum", "невозможно привести к int", value));
            }
        }

        [XmlElement(ElementName = "regionId", Namespace = Constants.NsService)]
        public string RegionId
        {
            get { return _regionId.ToString(); }
            set
            {
                if (int.TryParse(value, out _regionId)) return;
                throw new InvalidCastException(Routines.GenerateErrorCaption("regionId", "невозможно привести к int", value));
            }
        }

        [XmlElement(ElementName = "deviceID", Namespace = Constants.NsService)]
        public string DeviceId { get; set; }
    }
}
