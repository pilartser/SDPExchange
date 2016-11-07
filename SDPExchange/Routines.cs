using System;
using System.IO;
using System.Xml.Serialization;

namespace SDPExchange
{
    class Routines
    {
        public static void PrintAfterSerializeObject(Type type, object serialized, XmlSerializerNamespaces xmlns = null)
        {
            if (serialized == null) return;
            Console.WriteLine("\n*********************");
            try
            {
                using (var ms = new MemoryStream())
                {
                    XmlSerializer xs = new XmlSerializer(type);
                    StreamWriter myStreamWriter = new StreamWriter(ms);
                    if (xmlns != null)
                        xs.Serialize(myStreamWriter, serialized, xmlns);
                    else
                        xs.Serialize(myStreamWriter, serialized);
                    ms.Position = 0;
                    Console.Write(new StreamReader(ms).ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("\n*********************");
        }

        public static object DeSerializeObject(Type type, string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(type);
                    //var xr = XmlReader.Create(fs);
                    return xs.Deserialize(fs);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static void WriteSerializedObject(Type type, object serialized, string path, XmlSerializerNamespaces xmlns = null)
        {
            try
            {
                var xs = new XmlSerializer(type);
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    StreamWriter myStreamWriter = new StreamWriter(fs);
                    if (xmlns != null)
                        xs.Serialize(myStreamWriter, serialized, xmlns);
                    else
                        xs.Serialize(myStreamWriter, serialized);
                    Console.WriteLine($"File {path} successfully created!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
        }

        public static WsSecurity CreateWsSecurity(string user, string password)
        {
            return new WsSecurity
            {
                MustUnderstand = "0",
                UserNameToken = new UserNameToken {UserName = user, Password = new Password {Value = password}}
            };
        }
    }
}
