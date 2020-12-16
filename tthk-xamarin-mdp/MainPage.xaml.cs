using System;
using System.Collections.Generic;
using Xamarin.Forms;
using tthk_xamarin_mdp.Views;

namespace tthk_xamarin_mdp
{
    public partial class MainPage
    {
        /* Прошу нести салфетки и готовиться вытирать слёзы. В настоящем ТЗ я бы никогда так не сделал,
           но Xamarin не особо хорошо работает с Embedded-файлами отличными от изображений, а писать отдельный
           API для этого приложения не особо хочется. Пример, который снизу - так делать НЕ НАДО! */
        private static List<string> pageNames = new List<string>()
        {
            "Pages",
            "Layouts",
            "Views",
            "Cells",
            "Buttons",
            "DatePicker",
            "Slider",
            "Switch",
            "RadioButton",
            "RefreshView"
        };

        private static List<string> pageDetails = new List<string>()
        {
            "The most simple element of Xamarin",
            "Layouts for arrange elements",
            "Views for elements' movement",
            "Cells for tables and etc",
            "Buttons for click it",
            "DatePicker for pick a date (LMAO)",
            "Slider for slide and get value",
            "Switches for switch something",
            "Radiobuttons for check a value, but not a radio",
            "RefreshView to give an ability refresh views"
        };

        private static List<string> pageTexts = new List<string>()
        {
            "All the page types that are described below derive from the Xamarin.Forms Page class. These visual elements occupy all or most of the screen. A Page object represents a ViewController in iOS and a Page in the Universal Windows Platform. On Android, each page takes up the screen like an Activity, but Xamarin.Forms pages are not Activity objects",
            "The Layout and Layout<T> classes in Xamarin.Forms are specialized subtypes of views that act as containers for views and other layouts. The Layout class itself derives from View. A Layout derivative typically contains logic to set the position and size of child elements in Xamarin.Forms applications.",
            "Views are user-interface objects such as labels, buttons, and sliders that are commonly known as controls or widgets in other graphical programming environments. The views supported by Xamarin.Forms all derive from the View class.",
            "Xamarin.Forms cells can be added to ListViews and TableViews. A cell is a specialized element used for items in a table and describes how each item in a list should be rendered. The Cell class derives from Element, from which VisualElement also derives.A cell is not itself a visual element; it is instead a template for creating a visual element.",
            "The Button responds to a tap or click that directs an application to carry out a particular task. The Button is the most fundamental interactive control in all of Xamarin.Forms. The Button usually displays a short text string indicating a command, but it can also display a bitmap image, or a combination of text and an image. The user presses the Button with a finger or clicks it with a mouse to initiate that command.",
            "Internally, the DatePicker ensures that Date is between MinimumDate and MaximumDate, inclusive. If MinimumDate or MaximumDate is set so that Date is not between them, DatePicker will adjust the value of Date. All eight properties are backed by BindableProperty objects, which means that they can be styled, and the properties can be targets of data bindings. The Date property has a default binding mode of BindingMode.TwoWay, which means that it can be a target of a data binding in an application that uses the Model-View-ViewModel (MVVM) architecture.",
            "The Xamarin.Forms Slider is a horizontal bar that can be manipulated by the user to select a double value from a continuous range.",
            "The Xamarin.Forms Switch control is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value. The Switch class inherits from View.",
            "The Xamarin.Forms RadioButton is a type of button that allows users to select one option from a set. Each option is represented by one radio button, and you can only select one radio button in a group. The RadioButton class inherits from the Button class.",
            "The RefreshView is a container control that provides pull to refresh functionality for scrollable content. Therefore, the child of a RefreshView must be a scrollable control, such as ScrollView, CollectionView, or ListView."
        };

        private static List<string> pageImages = new List<string>()
        {
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/pages-images/contentpage-large.png",
            "https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/controls/layouts-images/layouts-sml.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/views-images/swipeview-large.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/cells-images/textcell-large.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker-images/daysbetweendatesselect.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button-images/basicbuttonclick-large.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider-images/basicslidercode-large.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/switch-images/switch-states-default.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton-images/radiobutton-states.png",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/refreshview-images/default-progress-circle.png"
        };

        private static List<string> pageReferences = new List<string>()
        {
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/pages",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/layouts",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/views",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/cells",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/slider",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/switch",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/radiobutton",
            "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/refreshview"
        };

        public MainPage()
        {
            Title = "Xamarin.Forms Elements";
            InitializeComponent();
            var itemsList = GenerateMasterMenuItems();
            profileImage.Source = ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Xamarin-logo.svg/1280px-Xamarin-logo.svg.png"));
            aboutList.ItemsSource = itemsList;
            aboutList.ItemSelected += AboutListOnItemSelected;
            var aboutPage = new AboutPage();
            Detail = new NavigationPage(aboutPage);
        }

        private void AboutListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = e.SelectedItem as MasterMenuItem;
            var selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage(selectedPage);
            IsPresented = false;
        }

        public static List<MasterMenuItem> GenerateMasterMenuItems()
        {
            List<MasterMenuItem> masterMenuItems = new List<MasterMenuItem>();
            for (int i = 0; i < pageNames.Count; i++)
            {
                var currentPage = new BookPage(ImageSource.FromUri(new Uri(pageImages[i])), pageNames[i], pageTexts[i], pageReferences[i]);
                masterMenuItems.Add(new MasterMenuItem()
                {
                    Text = pageNames[i],
                    Detail = pageDetails[i],
                    ImagePath = ImageSource.FromUri(new Uri(pageImages[i])),
                    TargetPage = currentPage
                });
            }
            return masterMenuItems;
        }
    }
}