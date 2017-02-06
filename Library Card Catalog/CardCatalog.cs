using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library_Card_Catalog
{
    class CardCatalog
    {
        private static string _fileName;
        public static int addBookCount = 0;
        public static List<Book> myBooks = new List<Book>();

        public static string CardCatalogName(string fileName)
        {
            _fileName = fileName;
            //
            CardCatalog.myBooks = XML.ReadXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + fileName + ".xml");
            return _fileName;
        }

        public static void ListBooks(string fileName, List<Book> mybooks)
        {
            Console.Clear();

            //we can use if we want to sort something later...
            /*
            var bookList = from book in myBooks
                           orderby book.Author descending
                           select book;
            */

            foreach (var book in mybooks)
            {
                Console.WriteLine("\nTitle: {0}\nAuthor: {1}\nPublished: {2}\nPrice: {3:C}", book.Title, book.Author, book.YearPublished, book.Price);
            }

            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
            Program.CheckList();
        }

        public static void AddBook(List<Book> books)
        {
            Console.Clear();

            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            Console.Write("Enter publishing year: ");
            int yearPublished = Vaildation.IsInt(Console.ReadLine(), "publishing year again");

            Console.Write("Enter price: ");
            decimal price = Vaildation.IsDecimal(Console.ReadLine());

            books.Add(new Book() { Title = title, Author = author, YearPublished = yearPublished, Price = price });

            addBookCount++;
            Console.WriteLine("You added {0} book(s).", addBookCount);
            Console.Write("Do you want add another book? (Y/N)");
            if (Vaildation.IsYorN(Console.ReadLine()))
            {
                AddBook(books);
            }

            Program.CheckList();
        }

        public static void SaveAndExit()
        {
            XML.WriteXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + _fileName + ".xml", myBooks);
        }
    }
}
