using System;
using Askmethat.XForms.Controls.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AmcIconedButton), typeof(Askmethat.XForms.Controls.ButtonRenderers.AmcIconedButtonRenderer))]
namespace Askmethat.XForms.Controls.ButtonRenderers
{
    public class AmcIconedButtonRenderer : ButtonRenderer
    {
        public AmcIconedButtonRenderer()
        {
        }
    }
}
