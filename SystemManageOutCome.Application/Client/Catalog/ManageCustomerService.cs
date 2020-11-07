using System;
using System.Collections.Generic;
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
        //public Task AddViewCount(int customerID)
        //{
        //    var Customer = await _context.customers.FindAsync(customerID);
        //    Customer.

        //}



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

        public async Task<List<CustomerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task<PageViewModel<CustomerViewModel>> GetAllPaing(GetCustomerPaingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int>  Update(UpdateCustomerRequest request)
        {
            throw new NotImplementedException();

        }


    }
}
