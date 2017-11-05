﻿using System;
using Xamarin.Forms;
namespace Askmethat.XForms.Controls.Buttons
{
    public class AmcIconedButton : Button
    {
        public AmcIconedButton()
        {
        }

        /// <summary>
        /// The button icon
        /// </summary>
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(propertyName: nameof(Icon),
                                    returnType: typeof(string),
                                    declaringType: typeof(AmcIconedButton),
                                    defaultValue: ""
                                    );

        public static readonly BindableProperty IconAlignmentProperty =
            BindableProperty.Create(propertyName: nameof(IconAlignment),
                                    returnType: typeof(IconAlignment),
                                    declaringType: typeof(AmcIconedButton),
                                    defaultValue: IconAlignment.Left
                                    );

        public static readonly BindableProperty TextMarginProperty =
           BindableProperty.Create(propertyName: nameof(TextMargin),
                                   returnType: typeof(int),
                                   declaringType: typeof(AmcIconedButton),
                                   defaultValue: 0
                                   );

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        public IconAlignment IconAlignment
        {
            get { return (IconAlignment)GetValue(IconAlignmentProperty); }
            set { SetValue(IconAlignmentProperty, value); }
        }

        public int TextMargin
        {
            get { return (int)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }
    }

    public enum IconAlignment
    {
        Left,
        Right
    }

}
