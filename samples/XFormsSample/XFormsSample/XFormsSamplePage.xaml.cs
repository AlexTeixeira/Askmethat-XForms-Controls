using Xamarin.Forms;
using XFormsSample.Entries;
using XFormsSample.Buttons;

namespace XFormsSample
{
    public partial class XFormsSamplePage : ContentPage
    {
        public XFormsSamplePage()
        {
            InitializeComponent();

        }

        async void AmcIconedButtonClick(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CustomIconedButton()));
        }

        async void AmcBorderEntryClick(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CustomBorderedEntry()));
        }
    }
}
