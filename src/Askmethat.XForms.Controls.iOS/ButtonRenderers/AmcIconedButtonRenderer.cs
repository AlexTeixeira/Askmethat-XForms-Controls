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
        readonly nfloat topAndBottomInset = 10f;
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
                uiButton.SetTitle(element.Text, UIControlState.Normal);

                uiButton.LayoutMargins = new UIEdgeInsets(0, 0, 0, 0);

                var width = element.WidthRequest.Equals(-1) ? uiButton.Bounds.Width : uiButton.CurrentImage.Size.Width;
                width = !element.HorizontalOptions.Alignment.ToString().Contains("Fill") && element.WidthRequest.Equals(-1) ? 0 : width;

                switch (element.IconAlignment)
                {
                    case IconAlignment.Left:
                        uiButton.ImageEdgeInsets = new UIEdgeInsets(10, 0, 10, width);
                        uiButton.TitleEdgeInsets = new UIEdgeInsets(0, 0, 0, element.TextMargin);
                        uiButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
                        break;
                    case IconAlignment.Right:
                        uiButton.ImageEdgeInsets = new UIEdgeInsets(10, width, 10, 0);
                        uiButton.TitleEdgeInsets = new UIEdgeInsets(0, element.TextMargin, 0, 0);
                        uiButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
                        uiButton.SemanticContentAttribute = UISemanticContentAttribute.ForceRightToLeft;
                        break;
                }


            }
        }

    }
}

