using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFormsSample.Entries
{
    public partial class CustomBorderedEntry : ContentPage
    {
        public CustomBorderedEntry()
        {
            InitializeComponent();
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MyEntry.FontSize = 10;
        }
    }
}
