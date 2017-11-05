using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Askmethat.XForms.Controls.Buttons;

namespace XFormsSample.Buttons
{
    public partial class CustomIconedButton : ContentPage
    {
        public CustomIconedButton()
        {
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem
            {
                Name = "Done",
                Command = new Command(() => Navigation.PopModalAsync()),
            });

        }
    }
}
