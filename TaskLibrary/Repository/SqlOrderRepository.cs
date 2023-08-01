using System.Data;
using System.Data.SqlClient;
using TaskLibrary.Entities;
using TaskLibrary.Interfaces;

namespace TaskLibrary.Repository
{
    public class SqlOrderRepository: SqlBaseRepository, IOrderRepository
    {
        private static IRepository Repository => new SqlRepository();

        public SqlOrderRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"select Id, CreatedDate, UpdatedDate, ProductId, StatusId from [dbo].[Order]";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var order = new Order();

                        order.Id = Convert.ToInt32(reader["Id"]);

                        order.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        order.UpdatedDate = order.UpdatedDate == null ? DateTime.MinValue : Convert.ToDateTime(reader["UpdatedDate"]);

                        order.ProductId = Convert.ToInt32(reader["ProductId"]);
                        order.Product = Repository.ProductRepository.GetProductById(order.ProductId);

                        var statId = Convert.ToInt32(reader["StatusId"]);
                        order.Status = Enum.Parse<Status>(statId.ToString());

                        orders.Add(order);
                    }
                    return orders;
                }
            }
        }

        //public Order GetOrderById(int id)
        //{
        //    var order = new Order();
        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();

        //        var cmdText = $"select Id, CreatedDate, UpdatedDate, ProductId, StatusId from [dbo].[Order] where Id =@Id";

        //        using (var cmd = new SqlCommand(cmdText, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@id", id);
        //            var reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                order.Id = Convert.ToInt32(reader["Id"]);
        //                order.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
        //                order.UpdatedDate = order.UpdatedDate == null ? DateTime.MinValue : Convert.ToDateTime(reader["UpdatedDate"]);
        //                order.ProductId = Convert.ToInt32(reader["ProductId"]);
        //                order.StatusId = Convert.ToInt32(reader["StatusId"]);
        //            }
        //        }
        //    }
        //    return order;
        //}



        //Use disconected model here
        public Order GetOrderById(int id)
        {
            var order = new Order();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"select Id, CreatedDate, UpdatedDate, ProductId, StatusId from [dbo].[Order] where Id ={id}";

                var adapter = new SqlDataAdapter(cmdText, connection);

                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    order.Id = Convert.ToInt32(dr[0].ToString());
                    order.CreatedDate = Convert.ToDateTime(dr[1]);
                    order.UpdatedDate = order.UpdatedDate == null ? DateTime.MinValue : Convert.ToDateTime(dr[2]);
                    order.ProductId = Convert.ToInt32(dr[3]);
                    order.Product = Repository.ProductRepository.GetProductById(order.ProductId);

                    order.StatusId = Convert.ToInt32(dr[4]);
                    order.Status = Enum.Parse<Status>(order.StatusId.ToString());
                }
            }
            return order;
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"update [dbo].[Order] set UpdatedDate = @updatedDate, StatusId = @statusId" +
                              $" where Id = @id";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("id", order.Id);
                    cmd.Parameters.AddWithValue("@updatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@statusId", order.StatusId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddOrder(Order order)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var cmdText = $"Insert into [dbo].[Order](CreatedDate, ProductId, StatusId)" +
                              $" values(@createdDate, @productId, @statusId)";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@createdDate", order.CreatedDate);
                    cmd.Parameters.AddWithValue("@productId", order.ProductId);
                    cmd.Parameters.AddWithValue("@statusId", order.StatusId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"delete from [dbo].[Order] where Id = @id";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Order> GetOrdersFilteredByProductId(int productId)
        {
            var orders = new List<Order>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = "sp_FetchOrdersByProductId";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productId", productId);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var order = new Order();

                        order.Id = Convert.ToInt32(reader["Id"]);

                        order.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        order.UpdatedDate = order.UpdatedDate == null ? DateTime.MinValue : Convert.ToDateTime(reader["UpdatedDate"]);

                        order.ProductId = Convert.ToInt32(reader["ProductId"]);
                        order.Product = Repository.ProductRepository.GetProductById(order.ProductId);

                        var statId = Convert.ToInt32(reader["StatusId"]);
                        order.Status = Enum.Parse<Status>(statId.ToString());

                        orders.Add(order);
                    }
                    return orders;
                }
            }
        }

        public int DeleteOrdersInBulkByProductId(int productId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"delete from [dbo].[Order] where ProductId = @productId";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
