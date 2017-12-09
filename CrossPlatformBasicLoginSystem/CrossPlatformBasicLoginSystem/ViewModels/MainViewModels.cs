using CrossPlatformBasicLoginSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformBasicLoginSystem.ServicesHandler;
using System.Runtime.CompilerServices;


namespace CrossPlatformBasicLoginSystem.ViewModels
{
    public class MainViewModels : INotifyPropertyChanged
    {
        private List<employee> _employeeList;

        public List<employee> employeelist
        {
            get { return _employeeList; }
            set
            {
                _employeeList = value;
                OnPropertyChanged();
            }
        }

        public MainViewModels()
        {
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var employeeServices = new employeeservices();
            employeelist = await employeeServices.GetEmployeesAsync();
        }
       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
