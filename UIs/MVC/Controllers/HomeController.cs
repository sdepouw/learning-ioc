using System.Linq;
using System.Web.Mvc;
using LearningNinject.Core.Interfaces.External;
using LearningNinject.DependencyResolution;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWidgetRepository widgetRepository = DependencyResolverInstance.Resolver.Resolve<IWidgetRepository>();
        private readonly IPaymentService paymentService = DependencyResolverInstance.Resolver.Resolve<IPaymentService>();

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