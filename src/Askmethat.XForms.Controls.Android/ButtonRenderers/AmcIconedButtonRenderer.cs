using System;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Askmethat.XForms.Controls.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android;
using Android.Graphics;

[assembly: ExportRenderer(typeof(AmcIconedButton), typeof(Askmethat.XForms.Controls.ButtonRenderers.AmcIconedButtonRenderer))]
namespace Askmethat.XForms.Controls.ButtonRenderers
{
    public class AmcIconedButtonRenderer : ButtonRenderer
    {
        AmcIconedButton element;
        Android.Widget.Button droidButton;
        public AmcIconedButtonRenderer()
        {
        }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            element = (AmcIconedButton)this.Element;
            droidButton = this.Control;

            ConfigButton();
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

        }

        /// <summary>
        /// Configs the button.
        /// </summary>
        private void ConfigButton()
        {
            SetButtonIcon();
        }

        /// <summary>
        /// Sets the button icon.
        /// </summary>
        private void SetButtonIcon()
        {
            if (!string.IsNullOrEmpty(element.Icon))
            {
                switch (element.IconAlignment)
                {
                    case IconAlignment.Left:

                        droidButton.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Icon), null, null, null);
                        droidButton.TextAlignment = Android.Views.TextAlignment.ViewEnd;
                        droidButton.Gravity = Android.Views.GravityFlags.CenterVertical | Android.Views.GravityFlags.End;
                        droidButton.SetPaddingRelative(element.IconLeftOrRightMargin, 0, element.TextMargin, 0);
                        break;
                    case IconAlignment.Right:
                        droidButton.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Icon), null);
                        droidButton.TextAlignment = Android.Views.TextAlignment.TextStart;
                        droidButton.Gravity = Android.Views.GravityFlags.CenterVertical | Android.Views.GravityFlags.Start;
                        droidButton.SetPaddingRelative(element.TextMargin, 0, element.IconLeftOrRightMargin, 0);
                        break;
                }


            }
        }


        /// <summary>
        /// Gets the drawable.
        /// </summary>
        /// <returns>The drawable.</returns>
        /// <param name="imageName">Image entry image.</param>
        private Drawable GetDrawable(string imageName)
        {

            int resID = Context.Resources.GetIdentifier(imageName, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var bDrawable = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, drawable.IntrinsicWidth, drawable.IntrinsicHeight - element.IconVerticalScale * 2, true));
            bDrawable.SetColorFilter(new LightingColorFilter(element.TextColor.ToAndroid(), element.TextColor.ToAndroid()));
            return bDrawable;
        }
    }
}
