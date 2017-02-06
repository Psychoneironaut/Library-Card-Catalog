using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Library_Card_Catalog
{
    class XML
    {
        public static void WriteXML(string filePath, List<Book> book, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, book);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public static List<Book> ReadXML(string filePath)
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                reader = new StreamReader(filePath);
                return (List<Book>)serializer.Deserialize(reader);
            }
            catch
            {
                Console.Write("Do you want to create New file? (Y/N)");
                if (Vaildation.IsYorN(Console.ReadLine()))
                {
                    WriteXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + Program.fileName + ".xml", CardCatalog.myBooks);
                }
                else
                {
                    Environment.Exit(0);
                }

                return CardCatalog.myBooks;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
