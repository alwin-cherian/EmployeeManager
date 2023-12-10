using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Employee> employeesList = _db.Employees.ToList();
            return View(employeesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Employee employeeFromDb = _db.Employees.FirstOrDefault(x => x.Id == id);
            if(employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if(ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
                return NotFound();

            Employee employeeFromDb = _db.Employees.Find(id);
            if(employeeFromDb == null)
                return NotFound();

            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Employee? employee = _db.Employees.Find(id);
            if(employee == null)
                return NotFound();

            _db.Employees.Remove(employee);
            _db.SaveChanges();
            TempData["success"] = "Employee Deleted successfully";
            return RedirectToAction("Index");
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> employeesList = _db.Employees.ToList();
            return Json(new { data = employeesList });
        }
        #endregion
    }
}
