namespace OnlineShopping.DMS.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
