using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class CustomerRepository
    {
        private List<Customer> customerList = new List<Customer>();

        public List<Customer> ReturnCustomers()
        {
            return customerList;
        }

        public void AddToList(Customer customer)
        {
            customerList.Add(customer);
        }                
    }
}
