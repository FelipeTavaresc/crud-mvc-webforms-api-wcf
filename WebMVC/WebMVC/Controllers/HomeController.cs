using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private const string URL_API = "http://localhost:60112/api/";
        public ActionResult Index()
        {
            IEnumerable<Cliente> clientes = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL_API);
                var response = httpClient.GetAsync("cliente");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<IList<Cliente>>();
                    read.Wait();
                    clientes = read.Result;
                }
                else
                {
                    clientes = Enumerable.Empty<Cliente>();
                    ModelState.AddModelError(string.Empty, "Erro.");
                }
                return View(clientes);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (cliente == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL_API);
                var post = httpClient.PostAsJsonAsync<Cliente>("Cliente", cliente);
                post.Wait();
                var result = post.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Erro.");
            return View(cliente);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Cliente cliente = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL_API);
                var response = httpClient.GetAsync($"cliente/{id.ToString()}");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var read = result.Content.ReadAsAsync<Cliente>();
                    read.Wait();
                    cliente = read.Result;
                }
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (cliente == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL_API);
                var put = httpClient.PutAsJsonAsync<Cliente>("cliente/", cliente);
                put.Wait();
                var result = put.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Cliente cliente = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL_API);
                var delete = httpClient.DeleteAsync($"cliente/{id.ToString()}");
                delete.Wait();
                var result = delete.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            return View(cliente);
        }
    }
}