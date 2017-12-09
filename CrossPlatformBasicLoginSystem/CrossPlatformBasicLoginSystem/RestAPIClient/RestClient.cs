using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace CrossPlatformBasicLoginSystem.RestAPIClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "http://192.168.1.78:8084/"; // Put your main host url here
        private const string LoginWebServiceUrl = MainWebServiceUrl + "api/employees1/"; // put your api extension url/uri here

        // This code matches the HTTP Request that we included in our api controller
        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();
            // http://MainHost/api/UserCredentials/username=foo/password=foo. The api value and response value should match in order to return a true status code. 
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);

            return response.IsSuccessStatusCode; // return either true or false
        }
    }
}
