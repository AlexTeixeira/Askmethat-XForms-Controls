using System;
using System.Drawing;
using Askmethat.XForms.Controls.Buttons;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;

[assembly: ExportRenderer(typeof(AmcIconedButton), typeof(Askmethat.XForms.Controls.ButtonRenderers.AmcIconedButtonRenderer))]
namespace Askmethat.XForms.Controls.ButtonRenderers
{
    public class AmcIconedButtonRenderer : ButtonRenderer
    {
        AmcIconedButton element;
        UIButton uiButton;
        public AmcIconedButtonRenderer()
        {
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public new static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            element = (AmcIconedButton)this.Element;
            uiButton = this.Control;

            ConfigButton();
        }


        /// <summary>
        /// Configs the button.
        /// </summary>
        private void ConfigButton()
        {
            uiButton.Frame = new CGRect(150, 20, 200, 50);

            uiButton.LayoutMargins = new UIEdgeInsets(0, 0, 0, 0);
            uiButton.SetTitle(element.Text, UIControlState.Normal);
            SetButtonIcon();
        }

        /// <summary>
        /// Sets the button icon.
        /// </summary>
        private void SetButtonIcon()
        {
            if (!string.IsNullOrEmpty(element.Icon))
            {
                uiButton.SetImage(UIImage.FromBundle(element.Icon), UIControlState.Normal);

                var width = element.WidthRequest.Equals(-1) ? uiButton.Bounds.Width : uiButton.CurrentImage.Size.Width;
                width = !element.HorizontalOptions.Alignment.ToString().Contains("Fill") && element.WidthRequest.Equals(-1) ? 0 : width;
                width = !element.WidthRequest.Equals(-1) ? (nfloat)element.WidthRequest / 2 : width;

                switch (element.IconAlignment)
                {
                    case IconAlignment.Left:
                        uiButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
                        uiButton.SemanticContentAttribute = UISemanticContentAttribute.ForceLeftToRight;
                        uiButton.ImageEdgeInsets = new UIEdgeInsets(element.ImageVerticalScale, 0, element.ImageVerticalScale, width - element.ImageLeftOrRightMargin);
                        uiButton.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, element.TextMargin);
                        break;
                    case IconAlignment.Right:
                        uiButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                        uiButton.SemanticContentAttribute = UISemanticContentAttribute.ForceRightToLeft;
                        uiButton.ImageEdgeInsets = new UIEdgeInsets(element.ImageVerticalScale, width - element.ImageLeftOrRightMargin, element.ImageVerticalScale, 0);
                        uiButton.TitleEdgeInsets = new UIEdgeInsets(0, element.TextMargin, 0, 0);
                        break;
                }


            }
        }

    }
}

