using System.Data.SqlClient;
using TaskLibrary.Interfaces;

namespace TaskLibrary.Repository
{
    public class SqlRepository : IRepository
    {
        private readonly string _connectionString;

        public SqlRepository()
        {
            _connectionString = CreateConnectionString();
        }

        private string CreateConnectionString()
        {
            //Data Source=(localdb)\MSSQLLocalDB;
            //Integrated Security=True;
            //Persist Security Info=False;
            //Pooling=False;
            //Multiple Active Result Sets=False;
            //Connect Timeout=60;
            //Encrypt=False;
            //Trust Server Certificate=False

            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(localdb)\\MSSQLLocalDB";
            builder.InitialCatalog = "db";
            builder.IntegratedSecurity = true;

            string connectionString = builder.ConnectionString;

            return connectionString;
        }

        public IProductRepository ProductRepository  => new SqlProductRepository(_connectionString);
        public IOrderRepository OrderRepository => new SqlOrderRepository(_connectionString);
    }
}
