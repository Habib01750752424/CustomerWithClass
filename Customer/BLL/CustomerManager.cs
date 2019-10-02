using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Model;
using Customer.Repository;

namespace Customer.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customers customers)
        {
            return _customerRepository.Add(customers);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public bool Update(Customers customers, int id)
        {
            return _customerRepository.Update(customers,id);
        }

        public DataTable Search(Customers customers)
        {
            return _customerRepository.Search(customers);
        }
    }
}
