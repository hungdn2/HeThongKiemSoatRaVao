using ReflectionIT.Mvc.Paging;
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

        PagingList<Customers> getPagination(int page, int size);
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
            return _context.customers.Find(Id);
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
                model.IsOut = 1;
                _context.SaveChanges();
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
                    modelDB.CMT = model.CMT;
                    modelDB.DateIn = model.DateIn;
                    modelDB.DateOut = model.DateOut;

                    if(modelDB.IsOut == 1)
                    {
                        var lastHistoryOfCustomer = _context.historyComeOuts.OrderByDescending(x => x.TimeCome).FirstOrDefault(x => x.IdCustomer == modelDB.ID
                        );

                        lastHistoryOfCustomer.TimeOut = model.DateOut;
                        modelDB.IsOut = 2;
                    } 
                    else if(modelDB.IsOut == 2)
                    {
                        _context.historyComeOuts.Add(new HistoryComeOut
                        {
                            IdCustomer = model.ID,
                            TimeCome = model.DateIn,
                            TimeOut = model.DateOut
                        });

                        modelDB.IsOut = 1;
                    }    
                }    
                else
                {
                    return 0;
                }    
            }
            return _context.SaveChanges();
        }

        public PagingList<Customers> getPagination(int page, int size)
        {
            // return _context.customers.
            return null;
        }
    }
}
