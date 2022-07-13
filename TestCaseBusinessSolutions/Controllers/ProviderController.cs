using Microsoft.AspNetCore.Mvc;
using TestCaseBusinessSolutions.DataAccess.Data;
using TestCaseBusinessSolutions.DataAccess.Repository.IRepository;
using TestCaseBusinessSolutions.Models;
using System;

namespace TestCaseBusinessSolutions.Web.Controllers
{
    public class ProviderController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public ProviderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Provider> objProviderList = _unitOfWork.Provider.GetAll();
            return View(objProviderList);
        }
        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Provider obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Provider.Add(obj);
                _unitOfWork.Save();
                TempData["sucсess"] = "Category Created sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            //var categoryFromDb= _db.Categories.Find(id);
            var ProviderFromDbFirst = _unitOfWork.Provider.GetFirstOrDefault(u => u.Id == id);
            if (ProviderFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ProviderFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Provider obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Provider.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var providerFromDbFirst = _unitOfWork.Provider.GetFirstOrDefault(u => u.Id == id);
            if (providerFromDbFirst == null)
            {
                return NotFound();
            }
            return View(providerFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Provider.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Provider.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted sucessfully";
            return RedirectToAction("Index");


        }
    }
}
