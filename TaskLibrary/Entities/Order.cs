namespace TaskLibrary.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
