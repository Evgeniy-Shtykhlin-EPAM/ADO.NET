namespace TaskLibrary.Entities
{
    public class Product
    {
        //Weight, Height, Width, Length
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
    }
}