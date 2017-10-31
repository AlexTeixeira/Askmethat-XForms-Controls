using System;
using Askmethat.XForms.Controls.Entries;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AmcBottomBorderEntry), typeof(Askmethat.XForms.Controls.EntryRenderers.AmcBottomBorderEntryRenderer))]
namespace Askmethat.XForms.Controls.EntryRenderers
{
    public class AmcBottomBorderEntryRenderer : EntryRenderer
    {
        AmcBottomBorderEntry element;
        FormsEditText formEditText;
        public AmcBottomBorderEntryRenderer()
        {
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            element = (AmcBottomBorderEntry)Element;
            formEditText = this.Control;


            if (element != null)
            {
                element.BackgroundColor = Xamarin.Forms.Color.Transparent;
                element.PlaceholderColor = element.LineColor;
                DrawBorder();
            }
        }

        void DrawBorder()
        {
            var ourCustomColorHere = element.LineColor.ToAndroid();
            Control.Background.SetColorFilter(ourCustomColorHere, Android.Graphics.PorterDuff.Mode.SrcAtop);
        }
    }
}
