namespace TaskLibrary.Interfaces
{
    public interface IRepository
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
