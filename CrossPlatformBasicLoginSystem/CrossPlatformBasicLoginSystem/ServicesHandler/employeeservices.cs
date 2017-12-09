using CrossPlatformBasicLoginSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;


namespace CrossPlatformBasicLoginSystem.ServicesHandler
{
    public class employeeservices 
    {

       public async Task<List<employee>> GetEmployeesAsync()
        {
            //    var list = new List<employee>
            //{
            //    new employee
            //    {
            //        Emp_Name = "Mohamed",
            //        Password = "It"
            //    },
            //    new employee
            //    {
            //        Emp_Name = "Lanjiao",
            //        Password = "It kek"
            //    },
            //};
            //    return list;
            RestClient<employee> restClient = new RestClient<employee>();
            var employeeList = await restClient.GetAsync();
            return employeeList;
        }
      

    }
}
