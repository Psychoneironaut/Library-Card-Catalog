using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Card_Catalog
{
    class Program
    {
        public static string fileName = "";

        // Don't really need this, but leave it for now
        

        static void Main(string[] args)
        {
            GetFileName();
            CheckList();
            
            //Console.ReadLine();
        }

        public static void CheckList()
        {
            CardCatalog cardCatalog = new CardCatalog();

            Console.WriteLine("\nEnter 1 to list all books.");
            Console.WriteLine("Enter 2 to add a book.");
            Console.WriteLine("Enter 3 to save and exit.");

            // This could crash the program if the user inputs the wrong data type
            int userValue = Convert.ToInt32(Console.ReadLine());

            switch (userValue)
            {
                case (int)(UserOptions.listOfBooks):
                    cardCatalog.ListBooks(CardCatalog.myBooks);
                    break;
                case (int)(UserOptions.addBook):
                    cardCatalog.AddBook(CardCatalog.myBooks);
                    break;
                case (int)(UserOptions.saveAndExit):
                    cardCatalog.SaveAndExit();
                    break;
                default:
                    CheckList();
                    break;
            }
        }   
        
        public static void GetFileName()
        {
            Console.Write("Enter the name of the file: ");
            fileName = Console.ReadLine();
            CardCatalog.CardCatalogName(fileName);
            XML.ReadXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + fileName + ".xml");
        }     
    }
}
