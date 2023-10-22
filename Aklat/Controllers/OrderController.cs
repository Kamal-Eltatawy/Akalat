using Akalat.ViewModel;
using Aklat.Models;
using Aklat.Reposatories.OrderProductRepo;
using Aklat.Reposatories.OrderRepo;
using Microsoft.AspNetCore.Mvc;

namespace Aklat.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReposatory orderReposatory;
        private readonly IOrderProductcs orderProductcsReposatory;

        public OrderController(IOrderReposatory orderReposatory, IOrderProductcs orderProductcsReposatory)
        {
            this.orderReposatory = orderReposatory;
            this.orderProductcsReposatory = orderProductcsReposatory;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetPRO([FromBody] List<OrderProductHome> orderData)
        {
            // Handle the received data, e.g., save it to a database
            var count = 0;
            decimal orderprices = 0;
            Order order = new Order();
           

            foreach (var item in orderData)
            {
                
                  
                
                count += item.ProductQuantity;
                orderprices += item.Price;

            }
            //foreach (var item in orderData )
            //{
            //    order.OrderProducts.Add(new OrderProduct()
            //    {
            //        OrderID = order.ID,
            //        ProductId = item.ProductID,
            //        ProductQuantity = item.ProductQuantity,
            //    });
            //}

            order.Count = count;
            order.OrderNote = "no";
            order.TotalPrice = orderprices;


            order.Date = DateTime.Now;
            order.UserID = "434d767c-704d-4ed8-a96f-5b6952237f62";


            orderReposatory.Create(order);
            orderReposatory.Save();

            //// Return a response if needed
            //return Ok("Data received and processed successfully.");
            return View(orderData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create([FromBody] test viewModel)
        //{

        //    //for (int i = 0; i < 1; i++)
        //    //{
        //    //    orderViewModelPost.orderProductHomes.Add(new OrderProductHome
        //    //    {
        //    //        ProductID = 1,
        //    //        ProductQuantity = 2,
        //    //    });
        //    //}
        //    //if(ModelState.IsValid)
        //    //{
        //    //Order order = new Order()
        //    //{
        //    //    OrderNote = orderViewModelPost.OrderNote,
        //    //    TotalPrice = 5455,
        //    //    Date = DateTime.Now,
        //    //    UserID = "56259fa0-7cd9-4470-a5be-9ecf8af913dd",
        //    //};
        //    //foreach (var item in orderViewModelPost.orderProductHomes)
        //    //{
        //    //    order.Count += item.ProductQuantity;
        //    //}

        //    //foreach (var item in orderViewModelPost.orderProductHomes)
        //    //{
        //    //    order.OrderProducts.Add(new OrderProduct()
        //    //    {
        //    //        OrderID = order.ID,
        //    //        ProductId = item.ProductID,
        //    //        ProductQuantity = item.ProductQuantity,
        //    //    });
        //    //}
        //    //orderReposatory.Create(order);
        //    //orderReposatory.Save();
        //    //return RedirectToAction("Index");
        //    List<OrderProductHome> receivedObjects = viewModel.MyObjects;
        //    return View("test", receivedObjects);

        //    //}
        //    //else { return View(); }

        //}
        public IActionResult Edit(int ID)
        {
            return View(orderReposatory.GetById(ID));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                orderReposatory.Update(order);
                return RedirectToAction("Index");
            }
            else { return View(order); }
        }


    }
}
