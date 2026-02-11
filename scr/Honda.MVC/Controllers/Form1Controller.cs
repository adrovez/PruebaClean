using Honda.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Honda.MVC.Controllers
{
    public class Form1Controller : Controller
    {
        // GET: Form1
        public ActionResult Index()
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            List<TablaCodigoViewModel> model = new List<TablaCodigoViewModel>();
            var result = client.getListarTablaCodigo("");

            foreach (var item in result)
            {
                model.Add(new TablaCodigoViewModel
                {
                    ID = item.Id,
                    CODIGO = item.Codigo,
                    DESCRIPCION = item.Descripcion
                });
            }

            return View(model);
        }

        // GET: Form1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            TablaCodigoViewModel result = new TablaCodigoViewModel();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44323/api/codigo/buscar/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsronResult = await response.Content.ReadAsStringAsync();
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<TablaCodigoViewModel>(jsronResult);
            }

            return View(result);
        }

        // GET: Form1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Form1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Form1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Form1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
