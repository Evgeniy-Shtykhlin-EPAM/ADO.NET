namespace TaskLibrary.Repository
{
    public class SqlBaseRepository
    {
        protected readonly string ConnectionString;
        public SqlBaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
