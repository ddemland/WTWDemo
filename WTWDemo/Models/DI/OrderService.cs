
namespace WTWDemo.Models.DI
{
    public class OrderService
    {
        private readonly IOrderRepository m_orderRepository;

        public OrderService(IOrderRepository mOrderRepository)
        {
            this.m_orderRepository = mOrderRepository;
        }

        public int Create(Order order)
        {
            int orderId = m_orderRepository.Insert(order);
            return orderId;
        }
    }
}