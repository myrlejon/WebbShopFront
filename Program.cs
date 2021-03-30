using System;
using WebbShopAPI.Database;
using System.Linq;
using WebbShopAPI.Models;
using WebbShopAPI;

namespace WebbShopFront
{
    class Program : Menu
    {
        static void Main(string[] args)
        {
            var API = new WebbShopAPI.WebbShopAPI();
            var seeder = new Seeder();
            var menu = new Menu();

            Seeder.Seed();
            bool isAdmin = menu.Intro();
            if (isAdmin == true)
            {
                menu.AdminMenu();
            }
            
        }
    }
}
