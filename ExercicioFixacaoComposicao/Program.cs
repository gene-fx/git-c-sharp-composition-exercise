using System;
using System.Globalization;
using ExercicioFixacaoComposicao.Entities;

namespace ExercicioFixacaoComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.WriteLine();

            Console.Write("Name: ");
            string nameCli = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nameCli) == true || string.IsNullOrEmpty(nameCli) == true)
            {
                Console.WriteLine();
                Console.Write("Enter a valid name: ");
                nameCli = Console.ReadLine();
            }

            Console.Write("Email: ");
            string emailCli = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(emailCli) == true || string.IsNullOrEmpty(emailCli) == true)
            {
                Console.WriteLine();
                Console.Write("Enter a valid email: ");
                emailCli = Console.ReadLine();
            }

            Console.Write("Birth date (DD/MM/YYYY): ");
            string bDayCliInput = Console.ReadLine();
            DateTime bDayCli;
            while (DateTime.TryParse(bDayCliInput, out bDayCli) == false)
            {
                Console.Write("Enter a valid date format (DD/MM/YYYY): ");
                bDayCliInput = Console.ReadLine();
            }
            bDayCli = DateTime.Parse(bDayCliInput);


            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.WriteLine();

            Console.WriteLine("These are the valid options for the order status:");
            Console.WriteLine("PandingPayment");
            Console.WriteLine("Processing");
            Console.WriteLine("Shipperd");
            Console.WriteLine("Delivered");
            Console.Write("Status: ");

            string orderStatus = Console.ReadLine().Substring(0, 2).ToLower();
            while (orderStatus.Equals("pa") == false && orderStatus.Equals("pr") == false
                && orderStatus.Equals("sh") == false && orderStatus.Equals("de") == false)
            {
                Console.WriteLine();
                Console.WriteLine("These are the valid options:");
                Console.WriteLine("PandingPayment");
                Console.WriteLine("Processing");
                Console.WriteLine("Shipperd");
                Console.WriteLine("Delivered");
                Console.WriteLine();
                Console.Write("Enter a valid status: ");
                orderStatus = Console.ReadLine().Substring(0, 2).ToLower();
            }

            Client client = new Client(nameCli, emailCli, bDayCli);
            Order order = new Order(DateTime.Now, orderStatus, client);

            Console.Write("How many items to this order?: ");
            int orderQtd = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("Order from: ");
            Console.WriteLine(client);
            for (int i = 1; i <= orderQtd; i++)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                while (string.IsNullOrEmpty(prodName) == true && string.IsNullOrWhiteSpace(prodName) == true)
                {
                    Console.Write("Enter a valid name for a product: ");
                    prodName = Console.ReadLine();
                }

                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                while (prodPrice <= 0)
                {
                    Console.WriteLine("Product price cant be 0 or less!");
                    Console.Write("Enter a valid price: ");
                    prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                Console.WriteLine("Quantity: ");
                int prodQtd = int.Parse(Console.ReadLine());
                while(prodQtd <= 0)
                {
                    Console.WriteLine("Product quantity cant be 0 or less!");
                    Console.Write("Enter a valid quantity: ");
                    prodQtd = int.Parse(Console.ReadLine());
                }

                Product product = new Product(prodName, prodPrice);
                OrderItem item = new OrderItem(prodQtd, product);
                order.AddItem(item);

                Console.WriteLine();
                Console.WriteLine($"Order #{i}: {product}, {item}");
            }

            Console.Clear();
            Console.WriteLine(order);
        }
    }
}
