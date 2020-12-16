using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tthk_xamarin_mdp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            ListView listView = new ListView()
            {
                ItemsSource = MainPage.GenerateMasterMenuItems(),
                ItemTemplate = new DataTemplate(() =>
                {
                    Label titleLabel = new Label() { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Text");

                    Label descriptionLabel = new Label();
                    descriptionLabel.SetBinding(Label.TextProperty, "Detail");

                    return new ViewCell()
                    {
                        View = new StackLayout()
                        {
                            Padding = new Thickness(20, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = {titleLabel, descriptionLabel},
                        }
                    };
                }),
                HasUnevenRows = true,
                SelectionMode = ListViewSelectionMode.Single
            };
            listView.ItemSelected += ListViewOnItemSelected;
            Content = listView;
        }

        private void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = e.SelectedItem as MasterMenuItem;
            var selectedPage = selectedMenuItem.TargetPage;
            Navigation.PushAsync(selectedPage);
        }
    }
}