using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformBasicLoginSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Announcement : ContentPage
    {
        public Announcement()
        {
            InitializeComponent();
        }

        public string Username { get; internal set; }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeView());
            
        }
    }
}