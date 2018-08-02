using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using GetAroundApp.Models;
using GetAroundApp.ViewModels;

using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetAroundApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        readonly IEnumerable<ScheduleTime> schedule;

        public event EventHandler TimeSelected;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

        }

        public ItemDetailPage()
        {
            InitializeComponent();



            var item = new Item
            {
                Text = "Details",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;

            Stream stream = new FileStream("Schedule.json", FileMode.Open);

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                schedule = JsonConvert.DeserializeObject<IEnumerable<ScheduleTime>>(json);
            }

            SchedulePicker.ItemsSource = schedule.Select (s => s.attributes.departure_time.ToString ()).Take (10).ToList ();
        }

        public void OnPickerSelectedIndexChanged (object sender, EventArgs args)
        {
            TimeSelected?.Invoke (this, null);
        }
    }
}