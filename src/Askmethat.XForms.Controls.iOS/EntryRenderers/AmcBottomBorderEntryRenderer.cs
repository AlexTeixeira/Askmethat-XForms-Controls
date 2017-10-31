using System;
using Askmethat.XForms.Controls.Entries;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AmcBottomBorderEntry), typeof(Askmethat.XForms.Controls.EntryRenderers.AmcBottomBorderEntryRenderer))]
namespace Askmethat.XForms.Controls.EntryRenderers
{
    public class AmcBottomBorderEntryRenderer : EntryRenderer
    {

        AmcBottomBorderEntry element;
        UITextField textField;
        public AmcBottomBorderEntryRenderer()
        {
        }


        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public new static void Init()
        {
            var temp = DateTime.Now;
        }

        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (AmcBottomBorderEntry)this.Element;
            textField = this.Control;
            if (element != null)
            {
                element.BackgroundColor = Color.Transparent;
                element.PlaceholderColor = element.LineColor;

                DrawBorder();
            }
        }


        /// <summary>
        /// Draws the border.
        /// </summary>
        void DrawBorder()
        {
            var height = element.HeightRequest.Equals(-1) ? this.Frame.Height : element.HeightRequest;
            var width = element.WidthRequest.Equals(-1) ? this.Frame.Width : element.WidthRequest;
            textField.Layer.MasksToBounds = true;

            //Update width & height for element
            element.WidthRequest = width;
            element.HeightRequest = height;

            CALayer bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, height - 10, width - 25, 1f),
                BorderWidth = 2.0f,
                BorderColor = element.LineColor.ToCGColor()
            };

            textField.Layer.AddSublayer(bottomBorder);
            textField.BorderStyle = UITextBorderStyle.None;
        }
    }
}
