using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformBasicLoginSystem.Models;
using CrossPlatformBasicLoginSystem.RestClient;
using Newtonsoft.Json;
using System.Net.Http;

namespace CrossPlatformBasicLoginSystem.ServicesHandler
{
     public class AnnouncementServices
     {
        public async Task<List<Announcement>> GetAnnouncementAsync()
        {
            
            RestClient<Announcement> restClient = new RestClient<Announcement>();
            var employeeList = await restClient.GetAsync();
            return employeeList;
        }
        //delete ni if x jadi....
        
        
        public async Task PostAnnouncementAsync(Announcement announcement)
        {
            RestClient<Announcement> restClient = new RestClient<Announcement>();
            var announcementList = await restClient.PostAsync(announcement);
        }
    }
}
