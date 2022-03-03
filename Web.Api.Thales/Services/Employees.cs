using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.Api.Thales.Interfaces;


namespace Web.Api.Thales.Services
{
    public class Employees : IEmployees
    {
        public async Task<EmployeesResult> GerEmployees()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://dummy.restapiexample.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");

            Console.WriteLine("Consumiendo API");
            HttpResponseMessage response = await client.GetAsync("http://dummy.restapiexample.com/api/v1/employees");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<EmployeesResult>(json);
                return model;
            }
            else // code 429 (Too many request)
                return null;
        }

        public async Task<EmployeeResult> GerEmployee(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://dummy.restapiexample.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");

            Console.WriteLine("Consumiendo API");
            HttpResponseMessage response = await client.GetAsync(string.Format("http://dummy.restapiexample.com/api/v1/employee/{0}", id));
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<EmployeeResult>(json);

                if (model.data == null)
                    throw new Exception("Not Found");

                return model;
            }
            else // code 429 (Too many request)
                return null;
        }
    }
}
