using System;
using System.Web.UI;
using LearningIoC.Core.Interfaces.External;
using LearningIoC.DependencyResolution;

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