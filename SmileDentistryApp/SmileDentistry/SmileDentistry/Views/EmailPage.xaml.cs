using Plugin.Messaging;
using SmileDentistry.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SmileDentistry.Views
{
    public partial class EmailPage : ContentPage
    {
        #region Const
        public EmailPage(string path)
        {
            InitializeComponent();
            lblPath.Text = path;
            lblPath_ios.Text = path;
        }
        #endregion
        #region OnButtonClicked
        void OnButtonClicked(object sender, EventArgs args)
        {
            try
            {
                if (Device.OS == TargetPlatform.iOS)
                {
                    var email = Email_IOS.Text;
                    var confirm = Confirm_IOS.Text;
                    if (email != "")
                    {
                        if (email != confirm)
                        {
                            DisplayAlert("Error", "Email and confirm Email not match", "OK");
                        }
                        else
                        {
                            Sendmail(new EmailViewModel() { FirstName = FirstName_IOS.Text, LastName = LastName_IOS.Text, Phone = Phone_IOS.Text, EmailAddress = Email_IOS.Text, About = About_IOS.Text });
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Enter Email", "OK");
                    }
                }
                if (Device.OS == TargetPlatform.Android)
                {
                    var email = Email_Droid.Text;
                    var confirm = Confirm_Droid.Text;
                    if (email != "")
                    {
                        if (email != confirm)
                        {
                            DisplayAlert("Error", "Email and confirm Email not match", "OK");
                        }
                        else
                        {
                            Sendmail(new EmailViewModel() { FirstName = FirstName_Droid.Text, LastName = LastName_Droid.Text, Phone = Phone_Droid.Text, EmailAddress = Email_Droid.Text, About = About_Droid.Text });
                        }
                    }
                    else
                    {
                        DisplayAlert("Error", "Enter Email", "OK");
                    }
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Error while Email send", "OK");
            }
        }
        //async void OnBackButtonClicked(object sender, EventArgs args)
        //{
        //    //await Navigation.PopModalAsync();            
        //    await Navigation.PushAsync(new MyCamera());
        //    //Navigation.RemovePage(this);
        //}
        #endregion
        #region Send Email Code
        public void Sendmail(EmailViewModel emailviewmodel)
        {
            var ToAddress = emailviewmodel.EmailAddress; //"manmeet.glocify@gmail.com";
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                try
                {
                    string body = string.Format("<html><head></head><body><p>First Name : {0}</p><p>Last Name : {1}</p><p>Email : {2}</p><p>Phone No : {3}</p><p>About Smile : {4}</p> </body></html>", emailviewmodel.FirstName, emailviewmodel.LastName, emailviewmodel.EmailAddress, emailviewmodel.Phone, emailviewmodel.About);
                    var email = new EmailMessageBuilder().To(ToAddress)
                    // .Bcc(new[] { "", "" })
                    .Subject("Smile Dentistry")
                    .BodyAsHtml(body)
                    .WithAttachment(lblPath.Text, "Location of file")
                    .Build();
                    emailMessenger.SendEmail(email);
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", "Error while Email send", "OK");
                }
            }
        }
        #endregion

    }
}
