using System;
using Askmethat.XForms.Controls.Animations;
using Xamarin.Forms;

namespace Askmethat.XForms.Controls.Entries
{
    public class AmcBottomBorderEntry : Entry
    {
        public AmcBottomBorderEntry()
        {
            this.Focused += this.OnFocused;
            this.Unfocused += this.OnUnFocused;
        }

        /// <summary>
        /// The line color property.
        /// </summary>
        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(propertyName: nameof(LineColor),
                                    returnType: typeof(Xamarin.Forms.Color),
                                    declaringType: typeof(AmcBottomBorderEntry),
                                    defaultValue: Color.White);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        void OnFocused(object sender, FocusEventArgs ev)
        {
            var animation = new Animation();

            animation.Add(0, 1, new Animation(v => this.FontSize = v, this.FontSize, this.FontSize *= 1.2, Easing.SpringIn));

            animation.Commit(this, "FocusAnimation", finished: async (arg1, arg2) =>
            {
                await this.FontAttributeTo(FontAttributes.Bold, v => this.FontAttributes = v, 1000, Easing.SpringIn);
            });

        }

        void OnUnFocused(object sender, FocusEventArgs ev)
        {
            var animation = new Animation();

            animation.Add(0, 1, new Animation(v => this.FontSize = v, this.FontSize, this.FontSize /= 1.2, Easing.SpringIn));

            animation.Commit(this, "FocusAnimation", finished: async (arg1, arg2) =>
            {
                await this.FontAttributeTo(FontAttributes.None, v => this.FontAttributes = v, 1000, Easing.SpringIn);
            });
        }
    }
}
