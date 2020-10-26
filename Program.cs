using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineDemo
{
     public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
    }

    interface IProductService
    {
        void GetPriceByType(Product product);
        int GetTotalPrice(List<Product> products);
    }

    public class ProductService : IProductService
    {
        public void GetPriceByType(Product product)
        {
            switch (product.Id.ToUpper())
            {
                case "A":
                    product.Price = 50;

                    break;
                case "B":
                    product.Price = 30;

                    break;
                case "C":
                    product.Price = 20;

                    break;
                case "D":
                    product.Price = 15;
                    break;
            }
        }

        public int GetTotalPrice(List<Product> products)
        {
            int counterOfA = 0;
            int priceOfA = 50;
            int counterOfB = 0;
            int priceOfB = 30;
            int counterOfC = 0;
            int priceOfC = 20;
            int counterOfD = 0;
            int priceOfD = 15;

            foreach (Product pr in products)
            {
                switch (pr.Id.ToUpper())
                {
                    case "A":
                        counterOfA += 1;
                        break;
                    case "B":
                        counterOfB += 1;
                        break;
                    case "C":
                        counterOfC += 1;
                        break;
                    case "D":
                        counterOfD += 1;
                        break;
                }
            }
            int totalPriceOfA = (counterOfA / 3) * 130 + (counterOfA % 3 * priceOfA);
            int totalPriceOfB = (counterOfB / 2) * 45 + (counterOfB % 2 * priceOfB);
            int totalPriceofCandD;
            if (counterOfC == counterOfD)
            {
                totalPriceofCandD = counterOfC * 30;
            }
            else
            {
                totalPriceofCandD = (counterOfC * priceOfC) + (counterOfD * priceOfD);
            }
            return totalPriceOfA + totalPriceOfB + totalPriceofCandD;
        }
    }

    class HandleProductService
    {
        private IProductService _productService;

        public HandleProductService(IProductService productService)  
        {  
            this._productService = productService;  
        }

        public int CalculatePrice(List<Product> products)  
        {
            return this._productService.GetTotalPrice(products);  
        }  
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Total number of order");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Enter the type of product:A,B,C or D");
                String type = Console.ReadLine();
                Product p = new Product();
                p.Id = type;
                products.Add(p);
            }

            ProductService productServiceObj = new ProductService();
            HandleProductService handleProductServiceObj=new HandleProductService(productServiceObj);
            int totalPrice = handleProductServiceObj.CalculatePrice(products);
            Console.WriteLine("Total price:" + totalPrice);
            Console.ReadLine();
        }
    }
}
