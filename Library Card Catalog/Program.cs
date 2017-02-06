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

        static void Main(string[] args)
        {
            GetFileName();
            CheckList();
        }

        public static void CheckList()
        {
            Console.Clear();
            Console.WriteLine("You are working in the \"{0}.xml\" file\n\n", fileName);
            Console.WriteLine("1) List all books.");
            Console.WriteLine("2) Add a book.");
            Console.WriteLine("3) Save and exit.");

            int userValue = Vaildation.IsInt(Console.ReadLine(), "Number please");

            switch (userValue)
            {
                case (int)(UserOptions.listOfBooks):
                    CardCatalog.ListBooks(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + fileName + ".xml", CardCatalog.myBooks);
                    break;
                case (int)(UserOptions.addBook):
                    CardCatalog.AddBook(CardCatalog.myBooks);
                    break;
                case (int)(UserOptions.saveAndExit):
                    CardCatalog.SaveAndExit();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid number. Please enter 1, 2, or 3.");
                    CheckList();
                    break;
            }
        }

        public static void GetFileName()
        {
            Console.Write("Enter the name of the file you want to open or create: ");
            fileName = Console.ReadLine();
            CardCatalog.CardCatalogName(fileName);

        }
    }
}
