using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemManageOutCome.Data.EF;
using SystemManageOutCome.Data.Entities;

namespace SystemManageOutCome.Service
{
    public interface ICustomerService
    {
        List<Customers> getAll();
        Customers findById(int Id);
        int SaveCustomer(Customers model);
    }

    public class CustomerService : ICustomerService
    {
        readonly SystemManageDBContext _context;
        public CustomerService(SystemManageDBContext context)
        {
            this._context = context;
        }
        public Customers findById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Customers> getAll()
        {
            return _context.customers.ToList();
        }

        public int SaveCustomer(Customers model)
        {
            if(model.ID <= 0)
            {
                _context.customers.Add(model);
                _context.historyComeOuts.Add(new HistoryComeOut
                {
                    IdCustomer = model.ID,
                    TimeCome = model.DateIn,
                    TimeOut = model.DateOut,
                });
            }
            else
            {
                var modelDB = _context.customers.Find(model.ID);
                if(modelDB != null)
                {
                    modelDB.DateIn = model.DateIn;
                    modelDB.DateOut = model.DateOut;
                }    
                else
                {
                    return 0;
                }    
            }
            return _context.SaveChanges();
        }
    }
}
