using CrossPlatformBasicLoginSystem.MenuItems;
using CrossPlatformBasicLoginSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossPlatformBasicLoginSystem
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            //this is for sidemenu bar....
            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            // credit to amirvuk blogspot for guide to menu bar...
            var page1 = new MasterPageItem() { Title = "View Announcement", Icon = "itemIcon1.png", TargetType = typeof(Announcement) };
            var page2 = new MasterPageItem() { Title = "Apply Leave", Icon = "itemIcon2.png", TargetType = typeof(ApplyLeave) };
            var page3 = new MasterPageItem() { Title = "Post Announcement", Icon = "itemIcon5.png", TargetType = typeof(PostAnnouncement) };
            var page4 = new MasterPageItem() { Title = "MyProfile", Icon = "itemIcon5.png", TargetType = typeof(ViewProfile) };
            var page5 = new MasterPageItem() { Title = "Log Out", Icon = "itemIcon5.png", TargetType = typeof(LoginPage) };
            
            //var page4 = new MasterPageItem() { Title = "Log Out", Icon = "itemIcon5.png", TargetType = typeof(LoginPage) };


            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Announcement)));
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

    }
}
