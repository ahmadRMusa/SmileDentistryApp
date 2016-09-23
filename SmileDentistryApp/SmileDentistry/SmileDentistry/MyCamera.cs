using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace SmileDentistry
{
    public class MyCamera : ContentPage
    {
        public MyCamera()
        {
            Padding = new Thickness(20, Device.OnPlatform(40, 20, 0), 10, 20);            
            //Padding = new Thickness(10, 30, 10, 20);
            IPictureTaker pictureTake = DependencyService.Get<IPictureTaker>();
            pictureTake.SnapPic();
            var theImage = new Image
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            MessagingCenter.Subscribe<IPictureTaker, string>(this, "pictureTaken", (sender, arg) => { theImage.Source = ImageSource.FromFile(arg); });
            Content = new StackLayout
            {
                Spacing = 20,
                // Children = { theButton, theImage }
                Children = { theImage }
            };
        }
    }
}
