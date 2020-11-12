namespace BelleChao.Data.Models
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
