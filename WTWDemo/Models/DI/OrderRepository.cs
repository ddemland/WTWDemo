
namespace WTWDemo.Models.DI
{
    public class OrderRepository
    {
        private static int m_nextOrderId;

        public int Insert(Order order)
        {
            return m_nextOrderId ++;
        }
    }
}