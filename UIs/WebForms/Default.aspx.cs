using System;
using System.Web.UI;
using LearningNinject.Core.Interfaces.External;
using LearningNinject.DependencyResolution;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var widgetRepository = DependencyResolverInstance.Resolver.Resolve<IWidgetRepository>();
            WidgetsLabel.Text = string.Join(", ", widgetRepository.FetchWidgets());
        }
    }
}