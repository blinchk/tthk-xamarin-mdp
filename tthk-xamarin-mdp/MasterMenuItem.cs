using System;
using Xamarin.Forms;

namespace tthk_xamarin_mdp
{
    public class MasterMenuItem
    {
        public string Text { get; set; }

        public string Detail { get; set; }

        public ImageSource ImagePath { get; set; }

        public ContentPage TargetPage { get; set; }
    }
}