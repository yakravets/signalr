namespace BlazorServerSignalRApp.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Count { get; set; } = 0;

        public Product(int id, string name, string imageUrl, double price, int count = 0)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
            Price = price;
            Count = count;
        }
    }
}
