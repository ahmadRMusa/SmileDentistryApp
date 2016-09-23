using SmileDentistry.Helpers;
using SmileDentistry.ViewModels;
using SmileDentistry.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SmileDentistry
{
    public static class ViewModelLocator
    {
        static SmilesViewModel smilesviewmodel;
        public static SmilesViewModel SmilesViewModel
        => smilesviewmodel ?? (smilesviewmodel = new SmilesViewModel());

        static DetailsViewModel detailsVM;
        public static DetailsViewModel DetailsViewModel
        => detailsVM ?? (detailsVM = new DetailsViewModel(SmileDentistryHelper.Smiles[0]));
    }


    public class App : Application
    {
        private int v;

        public App()
        {
            //The root page of your application
            //var content = new ContentPage
            //{
            //    Title = "SmileDentistry",
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            //MainPage = new NavigationPage(content);

            MainPage = new NavigationPage(new TutorialPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#2196F3")
            };
        }

        public App(string path)
        {
            //this.v = v;
            MainPage = new EmailPage(path);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
