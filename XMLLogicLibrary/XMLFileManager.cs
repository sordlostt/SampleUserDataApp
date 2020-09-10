using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XMLLogicLibrary
{
    public static class XMLFileManager
    {
        internal static XDocument FileInstance { get; set; }
        internal static String FilePath {get; private set;} = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SampleDataApp\"+ @"\UserFile.xml";

        /// <summary>
        /// Load the XML database file.
        /// </summary>
        /// <returns>Returns true if file exists, false if doesn't.</returns>
        public static bool LoadFile()
        {
            if(File.Exists(FilePath))
            {
                FileInstance = XDocument.Load(FilePath);
                return true;
            }
            return false;
        }

        public static void CreateEmptyFile()
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SampleDataApp\");
            FileInstance = new XDocument(new XElement("Users"));
            FileInstance.Save(FilePath);
        }

        public static void SaveFile()
        {
            FileInstance.Save(FilePath);
        }
    }
}
