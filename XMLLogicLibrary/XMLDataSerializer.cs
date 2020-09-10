using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace XMLLogicLibrary
{
    public static class XMLDataSerializer
    {
        public static void SerializeUsers(Object Users)
        {
            XDocument newDocument = new XDocument();
            using (var writer = newDocument.CreateWriter())
            {
                DataContractSerializer serializer = new DataContractSerializer(Users.GetType());
                serializer.WriteObject(writer, Users);
            }
            XMLFileManager.FileInstance = newDocument;
        }

        public static Object DeserializeUsers(Object Users)
        {
            FileStream fileStream = new FileStream(XMLFileManager.FilePath, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
            DataContractSerializer serializer = new DataContractSerializer(Users.GetType());
            Object deserializedUsers = serializer.ReadObject(reader, true);
            reader.Close();
            fileStream.Close();
            return deserializedUsers;
        }
    }
}
