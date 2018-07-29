using System;

using Xamarin.Forms;

namespace GetAroundApp.Views
{
    public class Timeline : ContentPage
    {
        public Timeline()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

