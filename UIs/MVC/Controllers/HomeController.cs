using System.Linq;
using System.Web.Mvc;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.DependencyResolution;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWidgetRepository widgetRepository = Resolver.Instance.Get<IWidgetRepository>();
        private readonly IPaymentService paymentService = Resolver.Instance.Get<IPaymentService>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // Let's make a payment when the user visits the about page!
            string myWidget = widgetRepository.FetchWidgets().Last();
            paymentService.MakePaymentForWidget(myWidget);

            ViewBag.Message = string.Format("Payment made for the '{0}' widget!", myWidget);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}