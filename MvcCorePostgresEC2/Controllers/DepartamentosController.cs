using Microsoft.AspNetCore.Mvc;
using MvcCorePostgresEC2.Models;
using MvcCorePostgresEC2.Repositories;

namespace MvcCorePostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            List<Departamento> depts = await this.repo.GetDepartamentosAsync();
            return View(depts);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repo.CReateDepartamentoAsync(departamento.DeptNo, departamento.Nombre, departamento.Loc);
            return RedirectToAction("Index");
        }
    }
}
