using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemManageOutCome.Data.Entities;
using SystemManageOutCome.Service;

namespace HeThongKiemSoatRaVao.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerService _ICustomerService; 
        public CustomerController(ICustomerService ICustomerService)
        {
            this._ICustomerService = ICustomerService;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
