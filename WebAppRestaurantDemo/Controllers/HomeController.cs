using BLL_BusinessLogicLayer.Repositories;
using DAL_DataAccessLayer;
using DAL_DataAccessLayer.Repositories;
using DAL_DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppRestaurantDemo.Controllers
{
    public class HomeController : Controller
    {
        PaymentRepository paymentType = new PaymentRepository();
        ItemRepository item = new ItemRepository();
        CustomerRepository customer = new CustomerRepository();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Item = new SelectList(item.GetAll().ToList(),"ID","ItemName");
            ViewBag.Customer = new SelectList(customer.GetAll().ToList(),"ID","Name");
            ViewBag.PaymentType = new SelectList(paymentType.GetAll().ToList(),"ID","PaymentTypeName");
            return View();
        }
        [HttpGet]
        public JsonResult getItemUnitPrice( int ItemId)
        {
            var unitPrice = item.Get(ItemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel )
        {
            OrderRepository orderRepository = new OrderRepository();
            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.CustomerId = objOrderViewModel.CustomerId;
            order.FinalTotal = objOrderViewModel.FinalTotal;
            order.OrderNumber = string.Format("{0:ddmmyyyyhhmmss}",DateTime.Now);
            order.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            orderRepository.Insert(order);

            int OrderId = order.ID;
            foreach (var item in objOrderViewModel.ListOfOrderDetailsViewModel)
            {
                OrderDetailsRepository orderDetailsRepository = new OrderDetailsRepository();
                var OrderDetails = new OrderDetail();
                OrderDetails.OrderId = OrderId;
                OrderDetails.Quantity = item.Quantity;
                OrderDetails.ItemId = item.ItemId;
                OrderDetails.UnitPrice = item.UnitPrice;
                OrderDetails.Discount = item.Discount;
                OrderDetails.Total = item.Total;
                orderDetailsRepository.Insert(OrderDetails);

                TransactionRepository transactionRepository = new TransactionRepository();
                Transaction transaction = new Transaction();
                transaction.ItemId = item.ItemId;
                transaction.Quantity = item.Quantity;
                transaction.TransactionDate = DateTime.Now;
                transaction.TypeId = 2;
                transactionRepository.Insert(transaction);
 
            }
            return Json("Order has been Successfully placed", JsonRequestBehavior.AllowGet);
        }
    }
}