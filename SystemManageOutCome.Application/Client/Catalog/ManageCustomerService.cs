using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManageOutCome.Application.Client.Catalog;
using SystemManageOutCome.Application.Client.Catalog.CustomerService.Dtos;
using SystemManageOutCome.Application.Client.Catalog.Dtos.Manage;
using SystemManageOutCome.Application.Dtos;
using SystemManageOutCome.Data.EF;
using SystemManageOutCome.Data.Entities;
using SystemManageOutCome.Utilities.Exceptions;

namespace SystemManageOutCome.Application.Client.Customer
{
    class ManageCustomerService : IManageCustomerService
    {
        private readonly SystemManageDBContext _context;
        public ManageCustomerService(SystemManageDBContext context)
        {
            _context = context;
       
        }


        public async Task<int> Create(CustomerCreateRequest request)
        {
            var customer = new Customers()
            {
                FullName = request.FullName,
                CMT = request.CMT,
                Member = request.Member,
                DateIn = DateTime.Now,
                DateOut = DateTime.Now,
            };
            _context.customers.Add(customer);
           return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int CustomerID)
        {
            var customer = await _context.customers.FindAsync(CustomerID);
            if (customer == null) throw new SystemManageOutComeException($"can not find a customer: {CustomerID}");
            _context.customers.Remove(customer);
            return await _context.SaveChangesAsync();
        }

        public Task<List<CustomerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageViewModel<CustomerViewModel>> GetAllPaing(GetCustomerPaingRequest request)
        {
            // select 

           // var query = from p in _context.customers select new { p };
            var query = _context.customers.ToList();

            //filter

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.CMT.Contains(request.Keyword)).ToList();
                
            //3. Paing
            int totalRow = query.Count();
            var data = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize).Select( x => new CustomerViewModel()
            { 
                ID = x.ID,
                FullName = x.FullName,
                
            }).ToList();
            // select and projecttion

            var pageResult = new PageViewModel<CustomerViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;


        }

        public async Task<int>  Update(UpdateCustomerRequest request)
        {
            var customer = await _context.customers.FindAsync(request.ID);
            if(customer == null) throw new SystemManageOutComeException($"can't not find customer with id: {request.ID}");
            return await _context.SaveChangesAsync();
        }


    }
}
