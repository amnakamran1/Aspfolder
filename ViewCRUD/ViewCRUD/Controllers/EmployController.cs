using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using ViewCRUD.Models;


namespace ViewCRUD.Controllers
{
    public class EmployController : Controller
    {
        private string url = "https://localhost:7180/api/StudentApi/";
        private HttpClient client =new HttpClient();
        [HttpGet]
        public  IActionResult Index()
        {
            List<Study>Emplee = new List<Study>();         
            HttpResponseMessage response =  client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                // ڈیٹا کو ڈیسیریلائز کریں
                var data = JsonConvert.DeserializeObject<List<Study>>(result);
                if (data != null)
                {
                    Emplee = data;
                }
            }  // ویو میں ڈیٹا بھیجیں
                return View(Emplee);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(Study sty)
        { string data=JsonConvert.SerializeObject(sty);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response=client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_success"] = "Data inserted..";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Study mess = new Study();
            HttpResponseMessage message = client.GetAsync(url+Id).Result;
            if (message.IsSuccessStatusCode)
            {
                string result = message.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Study>(result);
                if (data != null)
                {
                    mess = data;
                }
            }
            return View(mess);
        }
        [HttpPost]

        public IActionResult Edit(Study mess)
        {
            string data = JsonConvert.SerializeObject(mess);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url+mess.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Updated_success"] = "Data Updated..";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            Study mess = new Study();
            HttpResponseMessage message = client.GetAsync(url + Id).Result;
            if (message.IsSuccessStatusCode)
            {
                string result = message.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Study>(result);
                if (data != null)
                {
                    mess = data;
                }
            }
            return View(mess);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Study mess = new Study();
            HttpResponseMessage message = client.GetAsync(url + Id).Result;
            if (message.IsSuccessStatusCode)
            {
                string result = message.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Study>(result);
                if (data != null)
                {
                    mess = data;
                }
            }
            return View(mess);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Deletemess(int Id)
        {
            
            HttpResponseMessage message = client.DeleteAsync(url + Id).Result;
            if (message.IsSuccessStatusCode)
            {
                TempData["Deleted_success"] = "Data Deleted..";
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
