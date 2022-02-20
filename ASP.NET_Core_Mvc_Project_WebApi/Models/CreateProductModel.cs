namespace ASP.NET_Core_Mvc_Project_WebApi.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
