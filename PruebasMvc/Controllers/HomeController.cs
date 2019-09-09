using PruebasMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebasMvc.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var persona = this.GetPersona();
            this.SetTempData(null);

            return View(persona);
        }

        [Route("About/{idEmpleado}")]
        public ActionResult About(int idEmpleado)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public PartialViewResult RenderSeleccionTrabajos(string rubro)
        {
            this.SetTempData(rubro);
            var persona = this.GetPersona();
            ViewData.TemplateInfo.HtmlFieldPrefix = "Profesion";
            return PartialView("_seleccionTrabajo", persona.Profesion);
        }
            
        public ActionResult Guardar(Persona ee)
        {
            SetTempData(null);
            return View("Index", ee);
        }

        private Persona GetPersona()
        {
            var persona = new Persona();
            persona.Id = 1;
            persona.Nombre = "Pepe";
            persona.Profesion = new Profesion();

            return persona;
        }

        private void SetTempData(string filtroRubro)
        {
            var rubros = new List<string>() { "IT", "Abogacia" };

            var trabajos = new List<Trabajo>
            {
                new Trabajo() { Id = 1, Descripcion = "Desarrollador", Rubro = "IT" },
                new Trabajo() { Id = 2, Descripcion = "Tester", Rubro = "IT" },
                new Trabajo() { Id = 3, Descripcion = "Analista", Rubro = "IT" },
                new Trabajo() { Id = 4, Descripcion = "PM", Rubro = "IT" },
                new Trabajo() { Id = 5, Descripcion = "Penal", Rubro = "Abogacia" },
                new Trabajo() { Id = 6, Descripcion = "Civil", Rubro = "Abogacia" },
                new Trabajo() { Id = 7, Descripcion = "Comercial", Rubro = "Abogacia" }
            };

            if (!String.IsNullOrWhiteSpace(filtroRubro)) {
                trabajos = trabajos.Where(x => x.Rubro == filtroRubro).ToList();
            }

            TempData["Rubros"] = rubros;
            TempData["PosiblesEmpleos"] = trabajos;
        }
    }
}