using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Askmethat.XForms.Controls.Animations
{
    public static class FontAttributeAnimation
    {
        public static Task<bool> FontAttributeTo(this VisualElement self, FontAttributes toAttribute, Action<FontAttributes> callback, uint length = 250, Easing easing = null)
        {
            Func<double, FontAttributes> transform = (t) => toAttribute;
            return FontAttributeANimation(self, "FontAttributeTo", transform, callback, length, easing);
        }

        public static void CancelAnimation(this VisualElement self) => self.AbortAnimation("ColorTo");

        static Task<bool> FontAttributeANimation(VisualElement element, string name, Func<double, FontAttributes> transform, Action<FontAttributes> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<FontAttributes>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }
    }
}
