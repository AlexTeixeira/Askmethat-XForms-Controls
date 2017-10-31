using Xamarin.Forms;

namespace XFormsSample
{
    public partial class XFormsSamplePage : ContentPage
    {
        public XFormsSamplePage()
        {
            InitializeComponent();

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MyEntry.FontSize = 10;
        }
    }
}
