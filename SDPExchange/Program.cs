using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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
        private const int dummyPaymentSum = 10000;
        private const string dummyPaymentInfo = "1234_465789";
        private const string dummyIdPaymentInfo = "1A2B3C";

        private const string dummyCheq = "Выполнено что-то там...";
        private const int dummyFullSum = 20000;

        public static WsSecurity security = Routines.CreateWsSecurity(dummyUser, dummyPassword);

        public static SoapMessage CardInfoRequestMessage;

        public static SoapMessage CardPaymentRequestMessage;

        public static SoapMessage CardPaymentResponseMessage;


        public static SoapMessage CardInfoResponseMessage;


        private static void Main()
        {
            FillDummies();

            /*Routines.PrintAfterSerializeObject(typeof(CardInfoRequestMessage), CardInfoRequestMessage,
                CardInfoRequestMessage?.Xmlns);
            var reqCardInfo = (CardInfoRequestMessage) Routines.DeSerializeObject(typeof(CardInfoRequestMessage), "CardInfoRequest.xml");
            if (reqCardInfo != null)
                Routines.PrintAfterSerializeObject(typeof(CardInfoRequestMessage), reqCardInfo,
                    reqCardInfo.Xmlns);
            */


            Routines.PrintAfterSerializeObject(typeof (SoapMessage), CardInfoRequestMessage, nsRequest);
            Routines.PrintAfterSerializeObject(typeof (SoapMessage), CardPaymentRequestMessage, nsRequest);
            Routines.PrintAfterSerializeObject(typeof(SoapMessage), CardPaymentResponseMessage, nsResponse);
            Routines.PrintAfterSerializeObject(typeof (SoapMessage), CardInfoResponseMessage, nsResponse);
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
                CardInfoRequestMessage = new SoapMessage
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

                CardPaymentRequestMessage = new SoapMessage()
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

                CardPaymentResponseMessage = new SoapMessage()
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
                new SoapMessage()
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
                                    Otype = 1,
                                    Text = "Льготный",
                                    MinSumInt = 1500,
                                    MaxSumInt = 1000000,
                                    UnaccountedResidueInfo = "У вас есть какие то деньги..",
                                    UnaccountedResidueSum = 1000
                                },
                                new Tariff
                                {
                                    Id = "13",
                                    Otype = 1,
                                    Text = "НеЛьготный",
                                    MinSumInt = 1000,
                                    MaxSumInt = 1500000,
                                    UnaccountedResidueInfo = "У вас есть какие то деньги",
                                    UnaccountedResidueSum = 5000
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
                                    Otype = 4,
                                    Text = "Номер 00006060 серия 12 Season Unlimited Действует по 10.08.13",
                                    UnaccountedResidueInfo = "При формировании суммы оплаты использована сумма остатка",
                                    UnaccountedResidueSum = 5000
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
