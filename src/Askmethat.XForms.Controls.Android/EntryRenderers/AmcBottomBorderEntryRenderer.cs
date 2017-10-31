using System;
using Android.Graphics;
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
                DrawElement();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            element = (AmcBottomBorderEntry)Element;
            formEditText = this.Control;


            if (element != null)
            {
                DrawElement();
            }
        }

        /// <summary>
        /// Draws the element.
        /// </summary>
        void DrawElement()
        {
            formEditText.Background.SetColorFilter(Xamarin.Forms.Color.Transparent.ToAndroid(), PorterDuff.Mode.SrcAtop);
            element.PlaceholderColor = element.LineColor;

            var ourCustomColorHere = element.LineColor.ToAndroid();
            Control.Background.SetColorFilter(ourCustomColorHere, Android.Graphics.PorterDuff.Mode.SrcAtop);
        }
    }
}
