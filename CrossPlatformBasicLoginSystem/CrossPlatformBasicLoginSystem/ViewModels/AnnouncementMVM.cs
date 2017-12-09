using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformBasicLoginSystem.ServicesHandler;
using System.Runtime.CompilerServices;
using CrossPlatformBasicLoginSystem.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrossPlatformBasicLoginSystem.ViewModels
{
    
        public class AnnouncementMVM : INotifyPropertyChanged
        {
            private List<Announcement> _employeeList;
            private Announcement _selectAnnouncement = new Announcement();
            public List<Announcement> employeelist
            {
                get { return _employeeList; }
                set
                {
                    _employeeList = value;
                    OnPropertyChanged();
                }
            }
            public Announcement SelectAnnouncement
            {
                get { return _selectAnnouncement; }   
                set
                {
                _selectAnnouncement = value;
                OnPropertyChanged();
                }
            }
            
            public Command PostCommand
            {
            get
            {
                return new Command(async() =>
                {
                    var announcementServices = new AnnouncementServices();
                    await announcementServices.PostAnnouncementAsync(_selectAnnouncement);
                });
            }
            }


            public AnnouncementMVM()
            {
                InitializeDataAsync();
            }

            private async Task InitializeDataAsync()
            {
                var employeeServices = new AnnouncementServices();
                employeelist = await employeeServices.GetAnnouncementAsync();
                
            }


            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        //this is for pull to refresh....
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await InitializeDataAsync();

                    IsRefreshing = false;
                });
            }
        }
    }
    
}
