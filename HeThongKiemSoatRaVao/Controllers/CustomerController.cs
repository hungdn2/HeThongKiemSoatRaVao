using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeThongKiemSoatRaVao.Parameter;
using Microsoft.AspNetCore.Mvc;
using SystemManageOutCome.Data.Entities;
using SystemManageOutCome.Service;
//using PagedList;

namespace HeThongKiemSoatRaVao.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _ICustomerService; 
        public CustomerController(ICustomerService ICustomerService)
        {
            this._ICustomerService = ICustomerService;
        }
        public IActionResult Index(int? page = 0)
        {
            int limit = 2;
            int start;
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;

            int totalCustomer = _ICustomerService.totalCustomer();

            ViewBag.totalCustomer = totalCustomer;

            ViewBag.numberPage = _ICustomerService.numberPage(totalCustomer, limit);

            var data = _ICustomerService.paginationCustomer(start, limit);


            //var listModel = _ICustomerService.getAll(); 
            return View(data);
        }

        public IActionResult ShowEditView()
        {
            var listCustomer = _ICustomerService.getAll();
            return PartialView("EditCustomer",listCustomer);
        }

        [HttpPost]
        public int SaveCustomer(Customers param)
        {
            return _ICustomerService.SaveCustomer(param);
        }

        public Customers getById(int id)
        {
            return _ICustomerService.findById(id);
        }

     
    }
}
