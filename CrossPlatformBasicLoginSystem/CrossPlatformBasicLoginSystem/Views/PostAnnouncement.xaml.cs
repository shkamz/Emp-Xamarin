using CrossPlatformBasicLoginSystem.ServicesHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformBasicLoginSystem.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformBasicLoginSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostAnnouncement : ContentPage
    {
        public class test
        {
           
            public int ID { get; set; }
            public string Username { get; set; }
            public string title { get; set; }
            public string Message { get; set; }
            public TimeSpan time { get; set; }
        }

        public PostAnnouncement()
        {
            InitializeComponent();

        }
        //working at the moment....
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                // Create a new post  
                var lol = new test
                {
                    Username = App.Current.Properties["Name"].ToString(),
                    title = Entrytitle.Text,
                    Message = EntryMsg.Text,
                    time = System.DateTime.Now.TimeOfDay
                };

                // create the request content and define Json  
                var json = JsonConvert.SerializeObject(lol);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // var httpClient = new HttpClient();
                //  send a POST request  
                var uri = "http://192.168.1.78:8084/api/announcements1/";
                var result = await httpClient.PostAsync(uri, content);

                // on error throw a exception  
                result.EnsureSuccessStatusCode();

                // handling the answer  
                var resultString = await result.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<test>(resultString);
                await DisplayAlert("Success", "Announcement is posted.", "OK");
                //await Navigation.PushAsync(new Announcement());

            }
        }
    }
}
