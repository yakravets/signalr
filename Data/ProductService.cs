namespace BlazorServerSignalRApp.Data
{
    public class ProductService
    {
        public Task<IQueryable<Product>> GetProducts()
        {
            IQueryable<Product> products = new[]
            {
                new Product(1, "Суміщення 1 міс.", "", 2.99),
                new Product(2, "Суміщення 2 міс.", "", 5.98),        
                new Product(3, "Суміщення 3 міс.", "", 8.97),        
                new Product(4, "Суміщення 4 міс.", "", 11.96),        
                new Product(5, "Суміщення 5 міс.", "", 14.95),        
                new Product(6, "Суміщення 6 міс.", "", 17.94),        
            }.AsQueryable();

            return Task.FromResult(products);
        }
    }
}
