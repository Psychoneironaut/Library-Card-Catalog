using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Card_Catalog
{
    class CardCatalog
    {
        private static string _fileName;

        public static List<Book> myBooks = new List<Book>()
        {
                new Book() { Title = "Huck Finn", Author = "Mark Twain", YearPublished = 1920, Price = 10m },
                new Book() { Title = "Tom Sawyer", Author = "Mark Twain", YearPublished = 1925, Price = 17m },
                new Book() { Title = "Harry Potter", Author = "J.K. Rowling", YearPublished = 2005, Price = 9m },
        };

        public static string CardCatalogName(string fileName)
        {
            _fileName = fileName;
            return _fileName;
        }

        public void ListBooks(List<Book> myBooks)
        {
            var bookList = from book in myBooks
                           orderby book.Author descending
                           select book;

            foreach (var book in bookList)
            {
                Console.WriteLine("\nTitle: {0}\nAuthor: {1}\nPublished: {2}\nPrice: {3:C}", book.Title, book.Author, book.YearPublished, book.Price);
            }

            Program.CheckList();
        }
        
        public void AddBook(List<Book> myBooks)
        {
            //TODO: Make sure the user can't crash the app by inputting the wrong data type
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author name: ");
            string author = Console.ReadLine();
            Console.Write("Enter publishing year: ");
            int yearPublished = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            myBooks.Add(new Book() { Title = title, Author = author, YearPublished = yearPublished, Price = price });

            Program.CheckList();
        }

        public void SaveAndExit()
        {
            XML.WriteXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + _fileName + ".xml", myBooks);
        }
    }
}
