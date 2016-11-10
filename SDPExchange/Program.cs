using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SDPExchange.SdpService;

namespace SDPExchange
{
    internal class Program
    {
        private static readonly XmlSerializerNamespaces nsRequest =
            new XmlSerializerNamespaces(new[]
            {new XmlQualifiedName("ser", Constants.NsService), new XmlQualifiedName("soapenv", Constants.NsSoapEnv)});

        private static readonly XmlSerializerNamespaces nsResponse = new XmlSerializerNamespaces(new [] { new XmlQualifiedName("SOAP-ENV", Constants.NsSoapEnv)});

        private const string dummyVersion = "1";
        private const string dummyAgentId = "5231";
        private const string dummySalepointId = "1";
        private const string dummySysNum = "123456890";
        private const string dummyRegionId = "62";
        private const string dummyDeviceId = "1234";

        private const string dummyUser = "adminnimda";
        private const string dummyPassword = "1q2w3e";

        private const string dummySessionId = "02160329091126606000000000002345";
        private const string dummyTariffId = "13";
        private const string dummyTariffType1 = "0";
        private const string dummyTariffType2 = "1";
        private const int dummyPaymentSum = 10000;
        private const string dummyPaymentInfo = "1234_465789";
        private const string dummyIdPaymentInfo = "1A2B3C";

        private const string dummyCheq = "Выполнено что-то там...";
        private const int dummyFullSum = 20000;

        public static WsSecurity security = Routines.CreateWsSecurity(dummyUser, dummyPassword);

        public static SoapEnvelope CardInfoRequestMessage;

        public static SoapEnvelope CardPaymentRequestMessage;

        public static SoapEnvelope CardPaymentResponseMessage;


        public static SoapEnvelope CardInfoResponseMessage;


        private static void Main()
        {
            FillDummies();
            SdpService.SdpServiceClient sdp = new SdpServiceClient() {ClientCredentials = { UserName = { UserName = "admin", Password = "1"}}};
            
            SdpService.CardInfoRequest request1 = new SdpService.CardInfoRequest
            {
                deviceId = "0",
                regionId = 62,
                sysNum = 6060,
                agentId = "qedqd",
                salepointId = "wqe",
                version = "1"
            };

            //Console.WriteLine(request1.ToString());
            //sdp.ClientCredentials.UserName.UserName = "admin";
            //sdp.ClientCredentials.UserName.Password = "1";
            sdp.Open();
            try
            {
                var res = sdp.CardInfo(request1).Result;
            }
            catch (FaultException fe)
            {
                Console.WriteLine(fe.Message);
            }
            
            //SdpService.CardInfo ci = sdp.CardInfo(request1).CardInformation;
            /*
            WebRequest req = WebRequest.Create("http://195.182.143.219:8484/SDPServer-1.0-SNAPSHOT/SDPendpoints");
            HttpWebRequest httpreq = (HttpWebRequest)req;
            httpreq.Method = "POST";
            httpreq.ContentType = "text/xml; charset=utf-8";
            httpreq.Headers.Add("SOAPAction:CardInfoRequest");
            httpreq.ProtocolVersion = HttpVersion.Version11;
            httpreq.Credentials = CredentialCache.DefaultCredentials;
            Stream str = httpreq.GetRequestStream();
            StreamWriter strwriter = new StreamWriter(str, Encoding.ASCII);
            XmlSerializer xs = new XmlSerializer(typeof(SoapEnvelope));
            xs.Serialize(strwriter, CardInfoRequestMessage, CardInfoRequestMessage.Xmlns);
            //strwriter.Write(soaprequest.ToString());
            strwriter.Close();
            HttpWebResponse res;
            try
            {
                 res = (HttpWebResponse) httpreq.GetResponse();
                StreamReader rdr = new StreamReader(res.GetResponseStream());
                string result = rdr.ReadToEnd();
                Console.WriteLine(result);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }
            */
            //return result;
            /*Routines.PrintAfterSerializeObject(typeof(CardInfoRequestMessage), CardInfoRequestMessage,
                CardInfoRequestMessage?.Xmlns);
            var reqCardInfo = (CardInfoRequestMessage) Routines.DeSerializeObject(typeof(CardInfoRequestMessage), "CardInfoRequest.xml");
            if (reqCardInfo != null)
                Routines.PrintAfterSerializeObject(typeof(CardInfoRequestMessage), reqCardInfo,
                    reqCardInfo.Xmlns);
            */


            //Routines.PrintAfterSerializeObject(typeof (SoapEnvelope), CardInfoRequestMessage, nsRequest);
            //Routines.PrintAfterSerializeObject(typeof (SoapEnvelope), CardPaymentRequestMessage, nsRequest);
            //Routines.PrintAfterSerializeObject(typeof(SoapEnvelope), CardPaymentResponseMessage, nsResponse);
            //Routines.PrintAfterSerializeObject(typeof (SoapEnvelope), CardInfoResponseMessage, nsResponse);

            //var test = Routines.DeSerializeObject(typeof (SoapEnvelope), "CardInfoResponse.xml");
            //Routines.PrintAfterSerializeObject(typeof(SoapEnvelope), test, nsResponse);
            /*
                PropertyInfo propertyInfo =
                type.GetProperties().SingleOrDefault(
                        prop => prop.HasAttributeWithValue<XmlElementAttribute>(
                                a => a.ElementName == elementName
                            )
                    );
            if (propertyInfo == null)
            {
                return "NOT FOUND";
            }
            return propertyInfo.Name;
            */
            /*
            WriteSerializedObject(typeof(CardInfoRequestMessage), cardInfoRequestMessage, "CardInfoRequest.xml",
                cardInfoRequestMessage.Xmlns);
            WriteSerializedObject(typeof(CardPaymentRequestMessage), cardPaymentRequestMessage, "CardPaymentRequest.xml",
                cardPaymentRequestMessage.Xmlns);
            WriteSerializedObject(typeof(CardPaymentResponseMessage), cardPaymentResponseMessage, "CardPaymentResponse.xml",
                cardPaymentResponseMessage.Xmlns);
            WriteSerializedObject(typeof(CardInfoResponseMessage), cardInfoResponseMessage, "CardInfoResponseMessage.xml",
                cardInfoResponseMessage.Xmlns);
                */
            Console.ReadLine();
        }

        private static void FillDummies()
        {
            try
            {
                CardInfoRequestMessage = new SoapEnvelope
                {
                    Xmlns = nsRequest,
                    Header = {Security = security},
                    Body =
                    {
                        Content = new CardInfoRequest
                        {
                            AgentId = dummyAgentId,
                            DeviceId = dummyDeviceId,
                            RegionId = dummyRegionId,
                            SalepointId = dummySalepointId,
                            SysNum = dummySysNum,
                            Version = dummyVersion
                        }
                    }
                };

                CardPaymentRequestMessage = new SoapEnvelope
                {
                    Xmlns = nsRequest,
                    Header = {Security = security},
                    Body =
                    {
                        Content =
                            new CardPaymentRequest
                            {
                                AgentId = dummyAgentId,
                                SalepointId = dummySalepointId,
                                Version = dummyVersion,
                                SessionId = dummySessionId,
                                TariffId = dummyTariffId,
                                //В копейках
                                PaymentSum = dummyPaymentSum,
                                PaymentInfo = dummyPaymentInfo,
                                IdPaymentInfo = dummyIdPaymentInfo
                            }
                    }
                };

                CardPaymentResponseMessage = new SoapEnvelope
                {
                    Xmlns = nsResponse,
                    Body = 
                    {
                        Content = new CardPaymentResponse
                        {
                            Result = new Result(),
                            CardPaymentInformation = new CardPaymentInformation
                            {
                                SessionId = dummySessionId,
                                Cheq = dummyCheq,
                                FullSum = dummyFullSum
                            }
                        }
                    }
                };

                CardInfoResponseMessage =
                new SoapEnvelope
                {
                    Xmlns = nsResponse,
                    Body = 
                    {
                        Content = new CardInfoResponse
                        {
                            Result = new Result(),
                            CardInformation = new CardInformation
                            {
                                SessionId = dummySessionId,
                                Tariffs = new[]
                                {
                                new Tariff
                                {
                                    Id = "11",
                                    Otype = dummyTariffType1,
                                    Text = "Льготный",
                                    MinSumInt = "1500",
                                    MaxSumInt = "1000000",
                                    UnaccountedResidueInfo = "У вас есть какие то деньги..",
                                    UnaccountedResidueSum = "1000"
                                },
                                new Tariff
                                {
                                    Id = "13",
                                    Otype = dummyTariffType2,
                                    Text = "НеЛьготный",
                                    MinSumInt = "1000",
                                    MaxSumInt = "1500000",
                                    UnaccountedResidueInfo = "У вас есть какие то деньги",
                                    UnaccountedResidueSum = "5000"
                                }
                                },
                                Company = new Company
                                {
                                    Name = "Testing",
                                    Address = "Петровка,38",
                                    Phone = "(1)555-555"
                                },
                                Info = new CardCheck
                                {
                                    Otype = "4",
                                    Text = "Номер 00006060 серия 12 Season Unlimited Действует по 10.08.13",
                                    UnaccountedResidueInfo = "При формировании суммы оплаты использована сумма остатка",
                                    UnaccountedResidueSum = "5000"
                                },
                                WarningMessages = new[]
                                {
                                "Какое-то предупреждение 1",
                                "Еще какое-то предупреждение"
                                }
                            }
                        }
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
