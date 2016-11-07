using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SDPExchange
{
    internal class Program
    {
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

        public static CardInfoRequestMessage CardInfoRequestMessage;

        public static CardPaymentRequestMessage CardPaymentRequestMessage;

        public static CardPaymentResponseMessage CardPaymentResponseMessage;


        public static CardInfoResponseMessage CardInfoResponseMessage;


        private static void Main()
        {
            FillDummies();
            Routines.PrintAfterSerializeObject(typeof(CardInfoRequestMessage), CardInfoRequestMessage,
                CardInfoRequestMessage?.Xmlns);
            var reqCardInfo = (CardInfoRequestMessage) Routines.DeSerializeObject(typeof(CardInfoRequestMessage), "CardInfoRequest.xml");
            if (reqCardInfo != null)
                Routines.PrintAfterSerializeObject(typeof(CardInfoRequestMessage), reqCardInfo,
                    reqCardInfo.Xmlns);
            
            Console.ReadLine();
            /*
            PrintAfterSerializeObject(typeof (CardInfoRequestMessage), cardInfoRequestMessage,
                cardInfoRequestMessage.Xmlns);
            PrintAfterSerializeObject(typeof (CardPaymentRequestMessage), cardPaymentRequestMessage,
                cardPaymentRequestMessage.Xmlns);
            PrintAfterSerializeObject(typeof (CardPaymentResponseMessage), cardPaymentResponseMessage,
                cardPaymentResponseMessage.Xmlns);
            PrintAfterSerializeObject(typeof (CardInfoResponseMessage), cardInfoResponseMessage,
                cardInfoResponseMessage.Xmlns);

            WriteSerializedObject(typeof(CardInfoRequestMessage), cardInfoRequestMessage, "CardInfoRequest.xml",
                cardInfoRequestMessage.Xmlns);
            WriteSerializedObject(typeof(CardPaymentRequestMessage), cardPaymentRequestMessage, "CardPaymentRequest.xml",
                cardPaymentRequestMessage.Xmlns);
            WriteSerializedObject(typeof(CardPaymentResponseMessage), cardPaymentResponseMessage, "CardPaymentResponse.xml",
                cardPaymentResponseMessage.Xmlns);
            WriteSerializedObject(typeof(CardInfoResponseMessage), cardInfoResponseMessage, "CardInfoResponseMessage.xml",
                cardInfoResponseMessage.Xmlns);
                */
        }

        private static void FillDummies()
        {
            try
            {
                CardInfoRequestMessage = new CardInfoRequestMessage
                {
                    Header = new CardInfoRequestHeader { Security = security },
                    Body = 
                    new CardInfoRequestBody
                    {
                        CardInfoRequest =
                            new CardInfoRequest
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

                CardPaymentRequestMessage = new CardPaymentRequestMessage
                {
                    Header = new CardPaymentRequestHeader { Security = security },
                    Body = new CardPaymentRequestBody
                    {
                        CardPaymentRequest =
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

                CardPaymentResponseMessage = new CardPaymentResponseMessage
                {
                    Header = "",
                    Body = new CardPaymentResponseBody
                    {
                        CardPaymentResponse = new CardPaymentResponse
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
                new CardInfoResponseMessage
                {
                    Header = "",
                    Body = new CardInfoResponseBody
                    {
                        CardInfoResponse = new CardInfoResponse
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
