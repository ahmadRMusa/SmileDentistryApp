
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Media;
using Android.Content;
using Android.Content.Res;
using SmileDentistry.Views;
using Android.Preferences;

[assembly: Dependency(typeof(SmileDentistry.Droid.MainActivity))]
namespace SmileDentistry.Droid
{
    [Activity(Label = "SmileDentistry", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPictureTaker
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();           
            LoadApplication(new App());

            

        }


        public void SnapPic()
        {
            var activity = Forms.Context as Activity;
            var picker = new MediaPicker(activity);// new CircleActivity());
            var intent = picker.GetTakePhotoUI(new StoreCameraMediaOptions
            {
                Name = "SmileDentistry.jpg",
                Directory = "SmileApp"
            });
            activity.StartActivityForResult(intent, 1);
        }


        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled)
                return;

            var mediaFile = await data.GetMediaFileExtraAsync(Forms.Context);
            var path = mediaFile.Path;
            System.Diagnostics.Debug.WriteLine(mediaFile.Path);
            MessagingCenter.Send<IPictureTaker, string>(this, "pictureTaken", mediaFile.Path);
            LoadApplication(new App(path));           
        }
    }
}

