using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudDepartamentos.Models;
using MvcCoreApiCrudDepartamentos.Services;

namespace MvcCoreApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private ServiceApiDepartamento service;

        public DepartamentosController(ServiceApiDepartamento service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Servidor()
        {
            return View(await this.service.GetDepartamentosAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.service.FindDepartamentoAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteDepartamentoAsync(id);
            return RedirectToAction("Servidor", "Departamentos");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.service.InsertDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Servidor", "Departamentos");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await this.service.FindDepartamentoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            await this.service.UpdateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Servidor", "Departamentos");
        }

        public IActionResult Cliente()
        {
            return View();
        }
    }
}
