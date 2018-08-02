using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GetAroundApp.Models;

namespace GetAroundApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        //async void Save_Clicked(object sender, EventArgs e)
        //{
        //    MessagingCenter.Send(this, "AddItem", Item);
        //    await Navigation.PopModalAsync();
        //}
        private async void Clicked(object sender, EventArgs e)
        {
            var itemDetailPage = new ItemDetailPage();
            itemDetailPage.TimeSelected += ItemDetailPage_TimeSelected;

            await Navigation.PushAsync(itemDetailPage);
        }

        void ItemDetailPage_TimeSelected (object sender, EventArgs e)
        {
            FirstA.Text = "Harvard";
            FirstB.Text = "Broadway";
        }
    }
}