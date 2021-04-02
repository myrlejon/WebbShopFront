using System;
using System.Collections.Generic;
using System.Text;

namespace WebbShopFront.Controllers
{
    class UserMethods
    {
        public string spacing = "                                            ";
        public string spacing2 = "           ";
        public void Logout()
        {
            var menu = new WebbShopFront.Menu();
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var logout = API.Logout(adminID);

            if (logout == true)
            {
                Console.WriteLine(spacing + "Logged out, you will return to main menu.");
                Console.ReadLine();
                menu.Intro();
            }
            else if (logout == false)
            {
                Console.WriteLine(spacing + "Wrong ID.");
                Console.ReadLine();
            }
        }

        public void ListCategories()
        {
            var API = new WebbShopAPI.WebbShopAPI();
            var categories = API.GetCategories();
            
            foreach (var category in categories)
            {
                Console.WriteLine(spacing + category.Name);
            }
            Console.ReadLine();
        }

        public void ListCategoryKeyword()
        {
            Console.Write(spacing + "Name: ");
            string input = Console.ReadLine();
            var API = new WebbShopAPI.WebbShopAPI();
            var categories = API.GetCategories(input);

            foreach (var category in categories)
            {
                Console.WriteLine(spacing + category.Name);
            }
            Console.ReadLine();
        }

        public void ListCategoryID()
        {
            Console.Write(spacing + "ID: ");
            string inputID = Console.ReadLine();
            int ID = Convert.ToInt32(inputID);
            var API = new WebbShopAPI.WebbShopAPI();
            var categories = API.GetCategory(ID);

            foreach (var category in categories)
            {
                Console.WriteLine(spacing + category.Title);
            }
            Console.ReadLine();
        }

        public void GetAvaibleBooks()
        {
            Console.Write(spacing + "Book ID: ");
            string inputID = Console.ReadLine();
            int ID = Convert.ToInt32(inputID);
            var API = new WebbShopAPI.WebbShopAPI();
            var books = API.GetCategory(ID);
            int counter = 0;

            foreach (var book in books)
            {
                counter++;
            }
            Console.WriteLine(spacing + $"There is {counter} amount of books left.");
            Console.ReadLine();
        }

        public void GetBook()
        {
            Console.Write(spacing + "ID: ");
            string inputID = Console.ReadLine();
            int ID = Convert.ToInt32(inputID);
            var API = new WebbShopAPI.WebbShopAPI();

            var book = API.GetBook(ID);

            Console.WriteLine(book);
            Console.ReadLine();
        }

        //TODO: 4 metoder kvar.


    }
}
