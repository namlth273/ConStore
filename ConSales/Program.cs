using System;

namespace ConSales
{
    class Program
    {
        private static IStoreService _storeService = new StoreService();

        static void Main(string[] args)
        {
            ShowStores();
            //ShowClothes();

            Console.WriteLine("- Key in which clothe type you want to buy with option below:");
            Console.WriteLine("---- 1 for T-Shirt");
            Console.WriteLine("---- 2 for Dress Shirt");
            var type = Console.ReadLine();
            Console.WriteLine("- Key in which clothe size you want to buy with option below:");
            Console.WriteLine("---- 1 for S (Small)");
            Console.WriteLine("---- 2 for M (Medium)");
            var size = Console.ReadLine();
            Console.WriteLine("- Key in which clothe color you want to buy with option below:");
            Console.WriteLine("---- 1 for Red");
            Console.WriteLine("---- 2 for Blue");
            var color = Console.ReadLine();

            Console.WriteLine("- You have select clothe with below option:");
            ShowTypeOption(type);
            ShowSizeOption(size);
            ShowColorOption(color);
            Console.WriteLine("---- Quantity default is 1");

            var removeClotheParam = new RemoveClotheParam();
            removeClotheParam.Name = GetTypeOption(type);
            removeClotheParam.Size = GetSizeOption(size);
            removeClotheParam.Color = GetColorOption(color);

            _storeService.RemoveClothe(removeClotheParam);

            Console.WriteLine("---------------------- Your order is successfully placed!");

            //ShowStores();

            Console.ReadLine();
        }

        public static void ShowClothes()
        {
            var allClothes = _storeService.GetAllClothes();
            foreach (var clothe in allClothes)
            {
                Console.WriteLine($"Clothe name: {clothe.Name}");
            }
        }

        static void ShowTypeOption(string type)
        {
            if (type == "1")
            {
                Console.WriteLine($"---- T-Shirt");

            }
            else if (type == "2")
            {
                Console.WriteLine($"---- Dress-Shirt");
            }
        }

        static void ShowSizeOption(string type)
        {
            if (type == "1")
            {
                Console.WriteLine($"---- Size: S (Small)");

            }
            else if (type == "2")
            {
                Console.WriteLine($"---- Size: M (Medium)");
            }
        }

        static void ShowColorOption(string type)
        {
            if (type == "1")
            {
                Console.WriteLine($"---- Color: Red");

            }
            else if (type == "2")
            {
                Console.WriteLine($"---- Color: Blue");
            }
        }

        static string GetTypeOption(string type)
        {
            if (type == "1")
            {
                return "T-Shirt";

            }
            else if (type == "2")
            {
                return "Dress Shirt";
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        static string GetSizeOption(string type)
        {
            if (type == "1")
            {
                return "S";

            }
            else if (type == "2")
            {
                return "M";
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        static string GetColorOption(string type)
        {
            if (type == "1")
            {
                return "Red";
            }
            else if (type == "2")
            {
                return "Blue";
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        public static void ShowStores()
        {
            Console.WriteLine("Welcome to ConSales!");

            var allStores = _storeService.GetAllStores();
            foreach (var store in allStores)
            {
                Console.WriteLine($"- Clothe name: {store.Name}");
                Console.WriteLine($"---- Quantity in stock: {store.Quantity}");
                Console.WriteLine($"---- Retail Price: {store.RetailPrice}");
                Console.WriteLine($"---- Size: {store.Size}");
                Console.WriteLine($"---- Color: {store.Color}");
                Console.WriteLine($"- Next Item...");
            }
        }
    }
}
