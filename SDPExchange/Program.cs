using System;
using System.IO;
using System.Xml.Serialization;

namespace SDPExchange
{
    class Program
    {
        static void Main()
        {
            string version = "1";
            string agentId = "1234";
            string salepointId = "1";
            int sysNum = 1234567890;
            int regionId = 62;
            string deviceId = "1234";

            string user = "adminnimda";
            string password = "1q2w3e";

            string sessionId = "02160329091126606000000000002345";
            string tariffId = "13";
            int paymentSum = 10000;
            string paymentInfo = "1234_465789";
            string idPaymentInfo = "1A2B3C";

            string cheq = "Выполнено что-то там...";
            int fullSum = 20000;

            WsSecurity security = new WsSecurity { MustUnderstand = "0", UserNameToken = new UserNameToken { UserName = user, Password = new Password { Value = password } } };
            var cardInfoRequestMessage = new CardInfoRequestMessage
            {
                Header = new CardInfoRequestHeader {Security = security},
                Body =
                    new CardInfoRequestBody
                    {
                        CardInfoRequest =
                            new CardInfoRequest
                            {
                                AgentId = agentId,
                                DeviceId = deviceId,
                                RegionId = regionId,
                                SalepointId = salepointId,
                                SysNum = sysNum,
                                Version = version
                            }
                    }
            };

            PrintAfterSerializeObject(typeof(CardInfoRequestMessage), cardInfoRequestMessage, cardInfoRequestMessage.Xmlns);

            var cardPaymentRequestMessage = new CardPaymentRequestMessage
            {
                Header = new CardPaymentRequestHeader {Security = security},
                Body = new CardPaymentRequestBody
                {
                    CardPaymentRequest = 
                        new CardPaymentRequest
                        {
                            AgentId = agentId,
                            SalepointId = salepointId,
                            Version = version,
                            SessionId = sessionId,
                            TariffId = tariffId,
                            //В копейках
                            PaymentSum = paymentSum,
                            PaymentInfo = paymentInfo,
                            IdPaymentInfo = idPaymentInfo
                        }
                }
            };

            PrintAfterSerializeObject(typeof(CardPaymentRequestMessage), cardPaymentRequestMessage, cardPaymentRequestMessage.Xmlns);

            var cardPaymentResponseMessage = new CardPaymentResponseMessage
            {
                Header = "",
                Body = new CardPaymentResponseBody
                {
                    CardPaymentResponse = new CardPaymentResponse
                    {
                        Result = new Result(),
                        CardPaymentInformation = new CardPaymentInformation
                        {
                            SessionId = sessionId,
                            Cheq = cheq,
                            FullSum = fullSum
                        }
                    }
                }
            };
            PrintAfterSerializeObject(typeof(CardPaymentResponseMessage), cardPaymentResponseMessage, cardPaymentResponseMessage.Xmlns);

            var cardInfoResponseMessage = 
                new CardInfoResponseMessage
                {
                    Header = "",
                    Body = new CardInfoResponseBody
                    {
                        CardInfoResponse = new CardInfoResponse
                        {
                            Result =  new Result(),
                            CardInformation = new CardInformation
                            {
                                SessionId = sessionId,
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
            PrintAfterSerializeObject(typeof(CardInfoResponseMessage), cardInfoResponseMessage, cardInfoResponseMessage.Xmlns);

            Console.ReadKey();
        }

        static void PrintAfterSerializeObject(Type type, object serialized, XmlSerializerNamespaces xmlns = null)
        {
            Console.WriteLine("\n*********************");
            XmlSerializer xs = new XmlSerializer(type);
            using (var ms = new MemoryStream())
            {
                StreamWriter myStreamWriter = new StreamWriter(ms);
                if (xmlns != null)
                    xs.Serialize(myStreamWriter, serialized, xmlns);
                else
                    xs.Serialize(myStreamWriter, serialized);
                ms.Position = 0;
                Console.Write(new StreamReader(ms).ReadToEnd());
            }
            Console.WriteLine("\n*********************");
        }
    }
}
