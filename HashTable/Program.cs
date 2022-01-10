using System;
using System.Collections;

namespace HashTable
{
    public class Book
    {
        public string name;
        public int pages;
        public Book(string name, int pages)
        {
            this.name = name;
            this.pages = pages;
        }
        public Book()
        {

        }
    }
    class Program
    {
        public static void AddBook(Hashtable books)
        {
            Console.WriteLine("How many books to add? ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter book {0} author: ", i + 1);
                string author = Console.ReadLine();
                Console.WriteLine("Enter book {0} name: ", i + 1);
                string bookName = Console.ReadLine();
                Console.WriteLine("Enter book {0} pages: ", i + 1);
                int pages = Convert.ToInt32(Console.ReadLine());
                books.Add(author, new Book(bookName, pages)); //key - author, value - book object
            }
            Console.Clear();
            Console.WriteLine("Books added!");
        }
        public static void DisplayBooks(Hashtable books)
        {
            foreach (DictionaryEntry item in books)
            {
                Console.WriteLine("Author: {0}, Book name: {1}, Book pages: {2} ", item.Key, (item.Value as Book).name, (item.Value as Book).pages); //item.Value as Book jo nav zināms kādas key un value vērtības pie hashtable
            }
        }
        public static void DeleteByKey(Hashtable books)
        {
            Console.WriteLine("Enter key to delete (author name): ");
            string keyToDelete = Console.ReadLine();
            if (books.ContainsKey(keyToDelete))
            {
                books.Remove(keyToDelete);
                Console.WriteLine("Book with key {0} removed!", keyToDelete);
            }
            else
            {
                Console.WriteLine("No such key found!");
            }
        }
        public static void InfoByKey(Hashtable books)
        {
            Console.WriteLine("Enter key to search by: ");
            string keyToSearch = Console.ReadLine();
            if (books.ContainsKey(keyToSearch))
            {
                Console.WriteLine("Key found!");
                Book foundBook = new Book(); //object that will save information about saved book
                foundBook = books[keyToSearch] as Book;
                Console.WriteLine("Book name: {0}, Book pages: {1}", foundBook.name, foundBook.pages);
            }
            else
            {
                Console.WriteLine("No such key found!");
            }
        }
        static void Main(string[] args)
        {
            Hashtable books = new Hashtable();

            Console.WriteLine("MENU");
            Console.WriteLine("=====================");
            int choice = 0;
            do
            {
                Console.WriteLine("Choose your action: \n\n[1] Add new book to HashTable\n[2] Display HashTable\n[3] Delete HashTable element by key\n[4] Display a HashTable value by key\n[5] Clear HashTable\n[6] Exit\n");
                Console.WriteLine("");
                int userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (userInput)
                {
                    case 1:
                        AddBook(books);
                        break;
                    case 2:
                        DisplayBooks(books);
                        break;
                    case 3:
                        DeleteByKey(books);
                        break;
                    case 4:
                        InfoByKey(books);
                        break;
                    case 5:
                        books.Clear();
                        Console.Clear();
                        Console.WriteLine("Hashtable cleared!");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Theres no such choice");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 6);
        }
    }
}
