using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestCaseBusinessSolutions.DataAccess.Repository.IRepository;
using TestCaseBusinessSolutions.Models;
using TestCaseBusinessSolutions.Models.ViewModels;

namespace TestCaseBusinessSolutions.Web.Controllers
{
    public class OrderController:Controller
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Upsert(int? id)
        {
            OrderVM orderVM = new()
            {
                Order = new(),
                ProviderList = _unitOfWork.Provider.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                   
                }),
            

            };
            if (id == 0 || id == null)
            {

                return View(orderVM);
            }
            else
            {
                orderVM.Order = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
                return View(orderVM);
            }


        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Order obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Order.Add(obj);
                    TempData["success"] = "Product  created sucessfully";
                }
                else
                {
                    _unitOfWork.Order.Update(obj);
                    TempData["success"] = "Product  updated sucessfully";
                }
                _unitOfWork.Save();
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
            var orderFromDbFirst = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
            if (orderFromDbFirst == null)
            {
                return NotFound();
            }
            return View(orderFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Order.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");


        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {

            IEnumerable<Order> orders;
            
            orders = _unitOfWork.Order.GetAll(includeProperties: "Provider");
            
            
           
            
            return new JsonResult(new { data = orders });
        }
        #endregion
    }
}
