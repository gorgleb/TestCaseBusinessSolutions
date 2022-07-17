using Microsoft.AspNetCore.Mvc;
using TestCaseBusinessSolutions.DataAccess.Repository.IRepository;
using TestCaseBusinessSolutions.Models;
using TestCaseBusinessSolutions.Models.ViewModels;

namespace TestCaseBusinessSolutions.Web.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            OrderItem orderItem = new();
            
            if (id == 0 || id == null)
            {

                return View(orderItem);
            }
            else
            {
                orderItem = _unitOfWork.OrderItem.GetFirstOrDefault(u => u.Id == id);
                return View(orderItem);
            }


        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(OrderItem obj)
        {

            //if (ModelState.IsValid)
            //{

                if (obj.Id == 0)
                {
                    _unitOfWork.OrderItem.Add(obj);
                    TempData["success"] = "Product  created sucessfully";
                }
                else
                {
                    _unitOfWork.OrderItem.Update(obj);
                    TempData["success"] = "Product  updated sucessfully";
                }
                _unitOfWork.Save();
                return RedirectPermanent("/Home/Index");
            //}
            //return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var orderItemFromDbFirst = _unitOfWork.OrderItem.GetFirstOrDefault(u => u.Id == id);
            if (orderItemFromDbFirst == null)
            {
                return NotFound();
            }
            return View(orderItemFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.OrderItem.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.OrderItem.Remove(obj);
            _unitOfWork.Save();
            return RedirectPermanent("/Home/Index");


        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {

            IEnumerable<OrderItem> orderItems;

            orderItems = _unitOfWork.OrderItem.GetAll();




            return new JsonResult(new { data = orderItems });
        }
        #endregion
    }
}

