using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformBasicLoginSystem.Models
{
    public class Announcement
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string title { get; set; }
        public string Message { get; set; }
        public string time { get; set; }
    }
}
