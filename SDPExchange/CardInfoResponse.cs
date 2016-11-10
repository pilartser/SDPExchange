using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace SDPExchange
{
    [XmlRoot(ElementName = "CardInfoResponse", Namespace = Constants.NsService)]
    public class CardInfoResponse: SoapMessage
    {
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns = new XmlSerializerNamespaces();

        [XmlElement(ElementName = "Result", Namespace = Constants.NsService)]
        public Result Result { get; set; }

        [XmlElement(ElementName = "CardInformation", Namespace = Constants.NsService)]
        public CardInformation CardInformation { get; set; }

        public CardInfoResponse()
        {
            Xmlns.Add("ns2", Constants.NsService);
        }
    }

    [XmlRoot(ElementName = "CardInformation", Namespace = Constants.NsService)]
    public struct CardInformation
    {
        private string _sessionId;
        private Tariff[] _tariffs;

        [XmlElement(ElementName = "sessionId", Namespace = Constants.NsService)]
        public string SessionId {
            get { return _sessionId ?? ""; }
            set {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("sessionId", "не может быть null"));
                _sessionId = value;
            }
        }

        [XmlElement(ElementName = "tariff", Namespace = Constants.NsService)]
        public Tariff[] Tariffs {
            get { return _tariffs; }
            set
            {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("tariff",
                        "должен быть задан хотя бы один тариф"));
                _tariffs = value;
            }
        }

        [XmlElement(ElementName = "company", Namespace = Constants.NsService)]
        public Company Company { get; set; }

        [XmlElement(ElementName = "info", Namespace = Constants.NsService)]
        public CardCheck Info { get; set; }

        [XmlElement(ElementName = "warningMsg", Namespace = Constants.NsService)]
        public string[] WarningMessages { get; set; }
    }

    [XmlRoot(ElementName = "tariff", Namespace = Constants.NsService)]
    public struct Tariff
    {
        private int _id;
        private int _otype;
        private string _text;
        private int _minSumInt;
        private int _maxSumInt;
        private string _unaccountedResidueInfo;
        private int _unaccountedResidueSum;

        [XmlElement(ElementName = "id", Namespace = Constants.NsService)]
        public string Id {
            get { return _id.ToString(); }
            set
            {
                if (int.TryParse(value, out _id)) return;
                throw new InvalidCastException(Routines.GenerateErrorCaption("id",
                    "невозможно привести к int", value));
            }
        }

        [XmlElement(ElementName = "otype", Namespace = Constants.NsService)]
        public string Otype {
            get { return _otype.ToString(); }
            set
            {
                if (!int.TryParse(value, out _otype))
                    throw new InvalidCastException(Routines.GenerateErrorCaption("otype", "невозможно привести к int", value));
                if (!Enumerable.Range(0, 3).Contains(_otype))
                    throw new FormatException(Routines.GenerateErrorCaption("otype", "не в диапазоне (0,2)", value));
            }
        }

        [XmlElement(ElementName = "text", Namespace = Constants.NsService)]
        public string Text {
            get { return _text ?? ""; }
            set
            {
                if (value == null)
                    throw new FormatException(Routines.GenerateErrorCaption("text", "не может быть null"));
                _text = value;
            }
        }

        [XmlElement(ElementName = "minSumInt", Namespace = Constants.NsService)]
        public string MinSumInt
        {
            get { return _minSumInt.ToString(); }
            set
            {
                if (!int.TryParse(value, out _minSumInt))
                    throw new InvalidCastException(Routines.GenerateErrorCaption("minSumInt",
                        "невозможно привести к int", value));
            }
        }

        [XmlElement(ElementName = "maxSumInt", Namespace = Constants.NsService)]
        public string MaxSumInt {
            get { return _maxSumInt.ToString(); }
            set
            {
                if (!int.TryParse(value, out _maxSumInt))
                    throw new InvalidCastException(Routines.GenerateErrorCaption("maxSumInt",
                        "невозможно привести к int", value));
            }
        }

        [XmlElement(ElementName = "unaccountedResidueInfo", Namespace = Constants.NsService)]
        public string UnaccountedResidueInfo
        {
            get { return _unaccountedResidueInfo ?? ""; }
            set { _unaccountedResidueInfo = value; }
        }

        [XmlElement(ElementName = "unaccountedResidueSum", Namespace = Constants.NsService)]
        public string UnaccountedResidueSum {
            get { return _unaccountedResidueSum.ToString(); }
            set { int.TryParse(value, out _unaccountedResidueSum); }
        }
    }

    [XmlRoot(ElementName = "company", Namespace = Constants.NsService)]
    public struct Company
    {
        private string _name;
        private string _address;
        private string _phone;

        [XmlElement(ElementName = "name", Namespace = Constants.NsService)]
        public string Name {
            get { return _name ?? ""; }
            set { _name = value; }
        }

        [XmlElement(ElementName = "address", Namespace = Constants.NsService)]
        public string Address {
            get { return _address ?? ""; }
            set { _address = value; }
        }

        [XmlElement(ElementName = "phone", Namespace = Constants.NsService)]
        public string Phone {
            get { return _phone ?? ""; }
            set { _phone = value; }
        }
    }

    [XmlRoot(ElementName = "info", Namespace = Constants.NsService)]
    public struct CardCheck
    {
        private int _otype;
        private string _text;
        private string _unaccountedResidueInfo;
        private int _unaccountedResidueSum;

        [XmlElement(ElementName = "otype", Namespace = Constants.NsService)]
        public string Otype {
            get { return _otype.ToString(); }
            set
            {
                if (!int.TryParse(value, out _otype))
                    throw new InvalidCastException(Routines.GenerateErrorCaption("otype", "невозможно привести к int", value));
                if (!Enumerable.Range(4,2).Contains(_otype))
                    throw new FormatException(Routines.GenerateErrorCaption("otype", "не в диапазоне (4,5)", _otype));
            }
        }

        [XmlElement(ElementName = "text", Namespace = Constants.NsService)]
        public string Text {
            get { return _text ?? ""; }
            set { _text = value; }
        }

        [XmlElement(ElementName = "unaccountedResidueInfo", Namespace = Constants.NsService)]
        public string UnaccountedResidueInfo {
            get { return _unaccountedResidueInfo ?? ""; }
            set { _unaccountedResidueInfo = value; }
        }

        [XmlElement(ElementName = "unaccountedResidueSum", Namespace = Constants.NsService)]
        public string UnaccountedResidueSum {
            get { return _unaccountedResidueSum.ToString(); }
            set {
                if (!int.TryParse(value, out _unaccountedResidueSum))
                    throw new InvalidCastException(Routines.GenerateErrorCaption("unaccountedResidueSum", "невозможно привести к int", value));
            }
        }
    }
}
