using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeThongKiemSoatRaVao.Parameter;
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
        public IActionResult Index(BaseParameter param)
        {
            var listModel = _ICustomerService.getAll(); 
            return View(listModel);
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
