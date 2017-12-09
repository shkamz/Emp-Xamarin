using CrossPlatformBasicLoginSystem.ServicesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformBasicLoginSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
       
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(EntryUsername.Text, EntryPassword.Text);
            
            if (getLoginDetails)
            {
                await DisplayAlert("Login success", "You are login as " + EntryUsername.Text, "Okay", "Cancel");
                //var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string f = EntryUsername.Text;
                App.Current.Properties["Name"] = f; // assign username utk access dari mana2.....
               
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }

    }
}