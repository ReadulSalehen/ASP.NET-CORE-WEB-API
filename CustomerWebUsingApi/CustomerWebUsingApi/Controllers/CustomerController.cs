using CustomerWebUsingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CustomerWebUsingApi.Controllers
{
    public class CustomerController : Controller
    {
        private string url = "https://localhost:7070/api/Customers/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Customer>>(result);
                if(data != null)
                {
                    customers = data;
                }
            }
            return View(customers);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer cus)
        {
            string data = JsonConvert.SerializeObject(cus);
            StringContent content = new StringContent(data, Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Customet Added..";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer cus = new Customer();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Customer>(result);
                if (data != null)
                {
                    cus = data;
                }
            }
            return View(cus);
        }


        [HttpPost]
        public IActionResult Edit(Customer cus)
        {
            string data = JsonConvert.SerializeObject(cus);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + cus.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Customet Updated..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Customer cus = new Customer();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Customer>(result);
                if (data != null)
                {
                    cus = data;
                }
            }
            return View(cus);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer cus = new Customer();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Customer>(result);
                if (data != null)
                {
                    cus = data;
                }
            }
            return View(cus);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Customet Deleted..";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
