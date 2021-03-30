using System;
using WebbShopAPI.Models;

namespace WebbShopFront
{
    public class Menu
    {
        public string spacing = "                                            ";
        public int X = 0;
        public int Y = 0;
        public int MaxWidth { get; set; } = 120;

        public bool Intro()
        {
            bool adminUser = false;

            var API = new WebbShopAPI.WebbShopAPI();
            Console.WindowHeight = 30;
            Console.WindowWidth = 120;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            SetPos(0, 0);

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine(@"
                                   _      __    __   __   ______
                                  | | /| / /__ / /  / /  / __/ /  ___  ___
                                  | |/ |/ / -_) _ \/ _ \_\ \/ _ \/ _ \/ _ \
                                  |__/|__/\__/_.__/_.__/___/_//_/\___/ .__/
                                                          /_/

                                            (1) Logga in
                                            (2) Exit

                                  ");
                Console.Write(spacing + "    ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write(spacing + "Username: ");
                    string username = Console.ReadLine();
                    Console.Write(spacing + "Password: ");
                    string password = Console.ReadLine();
                    var loginID = API.Login(username, password);
                    var userIsAdmin = API.IsAdmin(username);

                    if (loginID > 0)
                    {
                        if (userIsAdmin == true)
                        {
                            adminUser = true;
                        }
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine(spacing + "Incorrect username or password.");
                        Console.ReadKey();
                    }
                }
                else if (input == "2")
                {
                    System.Environment.Exit(1);
                }
            }
                return adminUser;
        }

        public void AdminMenu()
        {
            bool adminMenu = true;
            var API = new WebbShopAPI.WebbShopAPI();
            while (adminMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
                                     ___     __      _
                                    / _ |___/ /_ _  (_)__  __ _  ___ ___  __ __
                                   / __ / _  /  ' \/ / _ \/  ' \/ -_) _ \/ // /
                                  /_/ |_\_,_/_/_/_/_/_//_/_/_/_/\__/_//_/\_,_/

                              ");
                Console.WriteLine(spacing + "(1) Add a book");
                Console.WriteLine(spacing + "(2) Add amount of books");
                Console.WriteLine(spacing + "(3) List all users");
                Console.WriteLine(spacing + "(4) Search for a user\n");
                Console.Write(spacing + "      ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        SetAmount();
                        break;
                    case "3":
                        ListAllUsers();
                        break;
                    case "4":
                        break;


                    
                }
            }
        }

        public void SearchUser()
        {

        }

        public void ListAllUsers()
        {
            var API = new WebbShopAPI.WebbShopAPI();
            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);

            var listAll = API.ListUsers(adminID);

            Console.WriteLine("\n" + spacing + "~ Users ~\n");
            foreach (var user in listAll)
            {
                Console.WriteLine(spacing + user.Name);
            }
            Console.ReadLine();
        }

        public void SetAmount()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();
            Console.Write(spacing + "Amount: ");
            string amountInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);
            int amount = Convert.ToInt32(amountInput);

            var setAmount = API.SetAmount(adminID, bookID, amount);

            if (setAmount == true)
            {
                Console.WriteLine(spacing + $"Added amount by {amount}");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (setAmount == false)
            {
                Console.WriteLine("Failed to add book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        public void AddBook()
        {
            var API = new WebbShopAPI.WebbShopAPI();

            Console.Write(spacing + "Admin ID: ");
            string adminInput = Console.ReadLine();
            Console.Write(spacing + "Book ID: ");
            string bookInput = Console.ReadLine();
            Console.Write(spacing + "Title: ");
            string title = Console.ReadLine();
            Console.Write(spacing + "Author: ");
            string author = Console.ReadLine();
            Console.Write(spacing + "Price: ");
            string priceInput = Console.ReadLine();
            Console.Write(spacing + "Amount: ");
            string amountInput = Console.ReadLine();

            int adminID = Convert.ToInt32(adminInput);
            int bookID = Convert.ToInt32(bookInput);
            int price = Convert.ToInt32(priceInput);
            int amount = Convert.ToInt32(amountInput);

            var bookAdd = API.AddBook(adminID, bookID, title, author, price, amount);

            if (bookAdd == true)
            {
                Console.WriteLine(spacing + $"Added {title}.");
                Console.Write(spacing);
                Console.ReadLine();
            }
            else if (bookAdd == false)
            {
                Console.WriteLine("Failed to add book.");
                Console.Write(spacing);
                Console.ReadLine();
            }
        }

        public void SetPos(int x = -1, int y = -1)
        {
            if (x < 0)
            {
                x = X;
            }

            if (y < 0)
            {
                y = Y;
            }

            Console.SetCursorPosition(x, y);
            X = x;
            Y = y;
        }
    }
}