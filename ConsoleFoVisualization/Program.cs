using TaskLibrary.Entities;
using TaskLibrary.Interfaces;
using TaskLibrary.Repository;

namespace ConsoleFoVisualization
{
    internal class Program
    {
        private static IRepository Repository => new SqlRepository();


        static void OperateProduct()
        {
            int exit = 0;

            while (exit != 4)
            {
                Console.WriteLine("The list of the Product:");
                var products = Repository.ProductRepository.GetProducts();

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id} {product.Name} {product.Description} {product.Weight} {product.Height} {product.Width} {product.Length}");
                }

                Console.WriteLine("---");

                Console.WriteLine("To add new product please click 1");
                Console.WriteLine("To update selected product please click 2");
                Console.WriteLine("To delete selected product please click 3");
                Console.WriteLine("For exit 4");


                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        AddNewProduct();
                        break;
                    }
                    case 2:
                    {
                        UpdateExistingProduct();
                        break;
                    }
                    case 3:
                    {
                        DeleteProduct();
                        break;
                    }
                    case 4:
                    {
                        exit = 4;
                        break;
                    }
                }

                Console.Clear();
            }
        }
        static void AddNewProduct()
        {
            var product = new Product();

            try
            {
                Console.WriteLine("Please enter product name:");
                product.Name = Console.ReadLine();

                Console.WriteLine("Please enter product description:");
                product.Description = Console.ReadLine();

                Console.WriteLine("Please enter product weight:");
                product.Weight = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Please enter product height:");
                product.Height = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Please enter product width:");
                product.Width = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Please enter product length:");
                product.Length = Convert.ToSingle(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input is invalid. Please enter correct data!!!");
            }

            try
            {
                Repository.ProductRepository.AddProduct(product);
            }
            catch
            {
                Console.WriteLine("Unknown exception. Please try again!");
            }
        }

        static void UpdateExistingProduct()
        {
            Console.WriteLine("Please enter Id of the product which you want to update");
            var id = Convert.ToInt32(Console.ReadLine());

            var product = Repository.ProductRepository.GetProductById(id);

            if (product == null)
            {
                Console.WriteLine($"There is no any products with Id is {id}");
            }
            else
            {
                try
                {
                    Console.WriteLine("Please enter product new name:");
                    product.Name = Console.ReadLine();

                    Console.WriteLine("Please enter product new description:");
                    product.Description = Console.ReadLine();


                    Console.WriteLine("Please enter product new weight:");
                    product.Weight = Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("Please enter product new height:");
                    product.Height = Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("Please enter product new width:");
                    product.Width = Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("Please enter product new length:");
                    product.Length = Convert.ToSingle(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Input is invalid. Please enter correct data!!!");
                }

                Repository.ProductRepository.UpdateProduct(product);
            }
        }

        static void DeleteProduct()
        {
            Console.WriteLine("Please enter Id of the product which you want to delete");
            var id = Convert.ToInt32(Console.ReadLine());

            var product = Repository.ProductRepository.GetProductById(id);

            if (product != null)
            {
                Repository.ProductRepository.DeleteProduct(id);
            }
            else
            {
                Console.WriteLine($"There is no any product whose Id is {id}");
            }
        }


        static void OperateOrder()
        {
            int exit = 0;

            while (exit != 9)
            {
                Console.WriteLine("The list of the Orders:");
                var orders = Repository.OrderRepository.GetOrders();

                foreach (var order in orders)
                {
                    Console.WriteLine($"OrderId: {order.Id} Order created date: {order.CreatedDate} Order product name: {order.Product.Name} Order updated date: {order.UpdatedDate} Order status: {order.Status}");
                }

                Console.WriteLine("---");

                Console.WriteLine("To add new order please click 1");
                Console.WriteLine("To update selected order please click 2");
                Console.WriteLine("To delete selected order please click 3");
                Console.WriteLine("To fetch orders by productId please click 4");
                Console.WriteLine("To bulk delete orders by productId please click 5");
                Console.WriteLine("For exit 9");

                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            AddNewOrder();
                            break;
                        }
                    case 2:
                        {
                            UpdateExistingOrder();
                            break;
                        }
                    case 3:
                        {
                            DeleteOrder();
                            break;
                        }
                    case 4:
                    {
                        FetchOrdersByProductId();
                        break;
                    }
                    case 5:
                    {
                        DeleteInBulkOrdersByProductId();
                        break;
                    }
                    case 9:
                        {
                            exit = 9;
                            break;
                        }
                }
                Console.Clear();
            }
        }

        static void AddNewOrder()
        {
            var order = new Order();

            try
            {
                Console.WriteLine("Please enter order StatusId:\n" +
                                  "1-NotStarted\n"+
                                  "2-Loading\n"+
                                  "3-InProgress\n" +
                                  "4-Arrived\n" +
                                  "5-Unloading\n" +
                                  "6-Cancelled\n" +
                                  "7-Done\n");
                order.StatusId = Convert.ToInt32(Console.ReadLine());

                order.CreatedDate= DateTime.Now;

                Console.WriteLine("Please enter product Id:");
                order.ProductId = Convert.ToInt32(Console.ReadLine()) ;
            }
            catch
            {
                Console.WriteLine("Input is invalid. Please enter correct data!!!");
            }

            try
            {
                Repository.OrderRepository.AddOrder(order);
            }
            catch
            {
                Console.WriteLine("Unknown exception. Please try again!");
            }
        }

        static void UpdateExistingOrder()
        {
            Console.WriteLine("Please enter Id of the order which you want to update");
            var id = Convert.ToInt32(Console.ReadLine());

            var order = Repository.OrderRepository.GetOrderById(id);

            if (order == null)
            {
                Console.WriteLine($"There is no any orders with Id is {id}");
            }
            else
            {
                Console.WriteLine("Founded order:");
                Console.WriteLine($"OrderId: {order.Id} Order created date: {order.CreatedDate} Order product name: {order.Product.Name} Order updated date: {order.UpdatedDate} Order status: {order.Status}");

                Console.WriteLine("Press any key:");
                Console.ReadKey();

                try
                {
                    Console.WriteLine("Please enter new order statusId:\n" +
                                      "1-NotStarted\n" +
                                      "2-Loading\n" +
                                      "3-InProgress\n" +
                                      "4-Arrived\n" +
                                      "5-Unloading\n" +
                                      "6-Cancelled\n" +
                                      "7-Done\n");
                    order.StatusId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Input is invalid. Please enter correct data!!!");
                }

                Repository.OrderRepository.UpdateOrder(order);
            }
        }

        static void DeleteOrder()
        {
            Console.WriteLine("Please enter Id of the order which you want to delete");
            var id = Convert.ToInt32(Console.ReadLine());

            var order = Repository.OrderRepository.GetOrderById(id);

            if (order != null)
            {
                Repository.OrderRepository.DeleteOrder(id);
            }
            else
            {
                Console.WriteLine($"There is no any order whose Id is {id}");
            }
        }

        static void FetchOrdersByProductId()
        {
            Console.WriteLine("Please enter productId for orders which you want to find");
            var id = Convert.ToInt32(Console.ReadLine());

            var product = Repository.ProductRepository.GetProductById(id);

            if (product != null)
            {
                var fetchedOrders=Repository.OrderRepository.GetOrdersFilteredByProductId(id);

                Console.WriteLine("Fetched orders:\n");

                foreach (var fetchedOrder in fetchedOrders)
                {
                    Console.WriteLine($"OrderId: {fetchedOrder.Id} Order created date: {fetchedOrder.CreatedDate} Order product name: {fetchedOrder.Product.Name} Order updated date: {fetchedOrder.UpdatedDate} Order status: {fetchedOrder.Status}");
                }
            }
            else
            {
                Console.WriteLine($"There is no any order whose Id is {id}");
            }

            Console.WriteLine("Press any key fo continue");
            Console.ReadKey();
        }

        static void DeleteInBulkOrdersByProductId()
        {
            Console.WriteLine("Please enter productId for orders which you want to delete");
            var id = Convert.ToInt32(Console.ReadLine());

            var product = Repository.ProductRepository.GetProductById(id);

            if (product != null)
            {
                var x=Repository.OrderRepository.DeleteOrdersInBulkByProductId(id);

                Console.WriteLine($"Deleted {x} rows");
            }
            else
            {
                Console.WriteLine($"There is no any order whose Id is {id}");
            }

            Console.WriteLine("Press any key fo continue");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Work with Product table");
            OperateProduct();

            Console.WriteLine("Work with Order table");
            OperateOrder();

            Console.ReadKey();
        }
    }
}