
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
        object ViewBag { get; }

        List<Customers> getAll();
        Customers findById(int Id);
        int SaveCustomer(Customers model);
        int totalCustomer();
        int numberPage(int totalCustomer, int limit);
        IEnumerable<Customers> paginationCustomer(int start, int limit);

    }

    public class CustomerService : ICustomerService
    {
        readonly SystemManageDBContext _context;
        private List<Customers> customers = new List<Customers>();

        public CustomerService(SystemManageDBContext context)
        {
            this._context = context;
            this.customers = _context.customers.ToList();

        }

        public object ViewBag => throw new NotImplementedException();

        public Customers findById(int Id)
        {
            return _context.customers.Find(Id);
        }

        public List<Customers> getAll()
        {
            return _context.customers.ToList();
        }

        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);

        }

        public IEnumerable<Customers> paginationCustomer(int start, int limit)
        {
            var data = (from s in _context.customers select s);
            var dataProduct = data.OrderByDescending(x => x.ID).Skip(start).Take(limit);
            return dataProduct.ToList();

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

        public int totalCustomer()
        {
            return customers.Count;

        }

    }
}
