using System;
using System.Web.UI;
using LearningIoC.DependencyResolution;
using LearningNinject.Core.Interfaces.External;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var widgetRepository = Resolver.Get<IWidgetRepository>();
            WidgetsLabel.Text = string.Join(", ", widgetRepository.FetchWidgets());
        }
    }
}