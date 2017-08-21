
using System.Web.Mvc;
using WTWDemo.DIModules;
using WTWDemo.Models.DI;
using WTWDemo.Models.UI;

namespace WTWDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService m_orderService;

        [HttpGet]

        public ActionResult Index()
        {
            var container = new Container();
            container.Register<HomeController, HomeController>();
            container.Register<IOrderService, OrderService>(LifeCycle.Singleton);
            container.Register<IOrderRepository, OrderRepository>(LifeCycle.Singleton);

            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProductInput productInput)
        {
            var orderId = new Order(productInput.ProductID);

            return View("ProductResults", orderId);
        }
    }
}