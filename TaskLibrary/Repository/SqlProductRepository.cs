using System.Data.SqlClient;
using TaskLibrary.Entities;
using TaskLibrary.Interfaces;

namespace TaskLibrary.Repository
{
    public class SqlProductRepository: SqlBaseRepository, IProductRepository
    {
        public SqlProductRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"select Id, Name, Description, Weight, Height, Width, Length  from Product";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var product = new Product();

                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = Convert.ToString(reader["Name"]);
                        product.Description = Convert.ToString(reader["Description"]);

                        product.Weight = Convert.ToSingle(reader["Weight"]);
                        product.Height = Convert.ToSingle(reader["Height"]);
                        product.Width = Convert.ToSingle(reader["Width"]);
                        product.Length = Convert.ToSingle(reader["Length"]);

                        products.Add(product);
                    }
                    return products;
                }
            }
        }

        public Product GetProductById(int id)
        {
            var product = new Product();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"select Id, Name, Description, Weight, Height, Width, Length from Product where Id=@Id";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        

                        product.Id = Convert.ToInt32(reader["Id"]);
                        product.Name = Convert.ToString(reader["Name"]);
                        product.Description = Convert.ToString(reader["Description"]);

                        product.Weight = Convert.ToSingle(reader["Weight"]);
                        product.Height = Convert.ToSingle(reader["Height"]);
                        product.Width = Convert.ToSingle(reader["Width"]);
                        product.Length = Convert.ToSingle(reader["Length"]);
                    }
                }
            }
            return product;
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cmdText = $"update Product set Name = @name, Description = @description, Weight = @weight, Height = @height, Width=@width, Length=@length" +
                              $" where Id = @id";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("id", product.Id);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@weight", product.Weight);
                    cmd.Parameters.AddWithValue("@height", product.Height);
                    cmd.Parameters.AddWithValue("@width", product.Width);
                    cmd.Parameters.AddWithValue("@length", product.Length);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var cmdText = $"Insert into Product(Name, Description, Weight, Height, Width, Length)" +
                              $" values(@name, @description, @weight, @height, @width, @length)";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@weight", product.Weight);
                    cmd.Parameters.AddWithValue("@height", product.Height);
                    cmd.Parameters.AddWithValue("@width", product.Width);
                    cmd.Parameters.AddWithValue("@length", product.Length);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string cmdText = $"delete from Product where Id = @id";

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
