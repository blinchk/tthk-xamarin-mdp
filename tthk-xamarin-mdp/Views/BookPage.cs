using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace tthk_xamarin_mdp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class BookPage : ContentPage
    {
        private readonly string readMoreUrl;
        public BookPage(ImageSource image, string name, string text, string referenceUrl)
        {
            var pageImage = new Image()
            {
                Source = image
            };
            var pageHeader = new Label()
            {
                Text = name
            };
            var pageText = new Label()
            {
                Text = text
            };
            var readMoreButton = new Button()
            {
                Text = "Узнать больше"
            };
            readMoreUrl = referenceUrl;
            readMoreButton.Clicked += ReadMoreButtonOnClicked;
            var stackLayout = new StackLayout()
            {
                Children = { pageHeader, pageImage, pageText, readMoreButton }
            };
            var scrollView = new ScrollView() // Content of page can be large
            {
                Content = stackLayout
            };
            Content = scrollView;
        }

        private async void ReadMoreButtonOnClicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(readMoreUrl);
        }
    }
}