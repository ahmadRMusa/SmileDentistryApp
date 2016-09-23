using Plugin.Messaging;
using SmileDentistry.Models;
using SmileDentistry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SmileDentistry.Views
{
    public partial class TutorialPage : ContentPage
    {       
        public TutorialPage()
        {
            InitializeComponent();
            BindingContext = new SmilesViewModel();
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        => ((ListView)sender).SelectedItem = null;

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var smile = ((ListView)sender).SelectedItem as Smile;
            if (smile == null)
                return;
            

        }
        void OnButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MyCamera());            
        }
    }
}
