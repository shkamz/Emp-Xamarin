using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformBasicLoginSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewProfile : ContentPage
    {

        public class employee
        {

            public string Emp_Id { get; set; }
            public string Emp_Name { get; set; }
            public string Password { get; set; }
        }

        public ViewProfile()
        {
            InitializeComponent();
            InitializeDataAsync();
        }
        private const string WebServiceUrl = "http://192.168.1.78:8084/api/employees1/getname/";
        
        

       
       private async Task InitializeDataAsync()
       {
            //get current username..
            string ff = App.Current.Properties["Name"].ToString();

            //string f = EntryUser.Text;
            //string f = "steve";

            employee bsObj = new employee();

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + ff);

            dynamic bsObject = JsonConvert.DeserializeObject<dynamic>(json);
            string name = bsObject["Emp_name"];
            string age = bsObject["Emp_Age"];
            string IC = bsObject["NRIC"];
            string Race = bsObject["Race"];
            string Role = bsObject["Role"];
            string Tel = bsObject["Tel"];
            string dept = bsObject["Emp_Department"];
            string dob = bsObject["DOB"];
            string nan = bsObject["Nationality"];
            EntryName.Text = name;
            EntryAge.Text = age;
            EntryIC.Text = IC;
            EntryRole.Text = Role;
            EntryTel.Text = Tel;
            EntryDept.Text = dept;
            EntryRace.Text = Race;
            EntryDOB.Text = dob;
            EntryNan.Text = nan;
       }   
    }
}