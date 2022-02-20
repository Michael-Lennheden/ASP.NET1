namespace ASP.NET_Core_Mvc_Project_Web_Api.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }
        public CategoryModel(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
