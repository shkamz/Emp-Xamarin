using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformBasicLoginSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplyLeave : ContentPage
    {
        public partial class leavework
        {
            public int Leave_Id { get; set; }
            public string Leave_Status { get; set; }
            public System.DateTime Leave_Date { get; set; }
            public System.DateTime Leave_EndDate { get; set; }
            public string Leave_Desc { get; set; }
            public string Emp_name { get; set; }
            public string Leave_Type { get; set; }
        }

        public ApplyLeave()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                // Create a new post  
                var lol = new leavework
                {
                    Leave_Date = datepicker.Date,
                    Leave_EndDate = dateendpicker.Date,
                    Leave_Status = "Pending",
                    Leave_Desc = EntryReason.Text,
                    Emp_name = App.Current.Properties["Name"].ToString(),
                    Leave_Type = EntryType.Text
                };

                // create the request content and define Json  
                var json = JsonConvert.SerializeObject(lol);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // var httpClient = new HttpClient();
                //  send a POST request  
                var uri = "http://192.168.1.78:8084/api/leaveworks1";
                //httpClient.DefaultRequestHeaders.ExpectContinue = false;
                var result = await httpClient.PostAsync(uri, content);

                // on error throw a exception  
                result.EnsureSuccessStatusCode();

                // handling the answer  
                var resultString = await result.Content.ReadAsStringAsync();
                var post = JsonConvert.DeserializeObject<leavework>(resultString);

                //await Navigation.PushAsync(new PostAnnouncement());
            }
        }
    }
}