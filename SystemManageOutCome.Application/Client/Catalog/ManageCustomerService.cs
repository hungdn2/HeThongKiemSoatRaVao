using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SystemManageOutCome.Application.Client.Catalog;

using SystemManageOutCome.Data.EF;
using SystemManageOutCome.Data.Entities;
using SystemManageOutCome.Utilities.Exceptions;
using SystemManageSolution.ViewModel.Catalog.Customer;
using SystemManageSolution.ViewModel.Catalog.Customer.Manage;
using SystemManageSolution.ViewModel.Common;

namespace SystemManageOutCome.Application.Client.Customer
{
    class ManageCustomerService : IManageCustomerService
    {
        private readonly SystemManageDBContext _context;
        public ManageCustomerService(SystemManageDBContext context)
        {
            _context = context;
       
        }


        public async Task<int> Create(CustomerCreateRequest request )
        {
            var customer = new Customers()
            {
                FullName = request.FullName,
                CMT = request.CMT,
                Member = request.Member,
                Description = request.Description,
                DateIn = DateTime.Now,
                DateOut = DateTime.Now,

            };
            //save image 
            if(request.ThumbnailImage != null)
            {
                
           
            }

    
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

        //private async Task<string> SaveFile(IFormFile file)
        //{
        //    var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('""');
        //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        //    await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
        //    return fileName;
        //}


    }
}
