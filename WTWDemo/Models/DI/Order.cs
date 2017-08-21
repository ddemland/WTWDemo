
namespace WTWDemo.Models.DI
{
    public class Order
    {
        public int ProductId { get; private set; }

        public Order(int productId)
        {
            ProductId = productId;
        }
    }
}