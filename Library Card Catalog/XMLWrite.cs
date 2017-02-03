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
                if (reader == null)
                {
                    WriteXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + Program.fileName + ".xml", CardCatalog.myBooks);
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






        /*public static void WriteXML(string fileName, List<Book> myBooks)
        {
            Book overview = new Book();

            var writer =
                new XmlSerializer(typeof(Book));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + fileName + ".xml";
            FileStream file = File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }

        public static void ReadXML(string fileName)
        {
            try
            {
                XmlSerializer reader =
                new XmlSerializer(typeof(Book));
                var file = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + fileName + ".xml");
                Book overview = (Book)reader.Deserialize(file);
                file.Close();
            }
            catch(Exception)
            {
                Program.CheckList(); 
            }
            
        }*/
    }
}
