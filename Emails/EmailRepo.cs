using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Emails
{
    public enum TypeOfCustomer
    {
        Past,
        Current,
        Potential
    }
    public class EmailProp
    {
        public TypeOfCustomer TypeOfCustomer { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailProp() { }
        public EmailProp(TypeOfCustomer typeOfCustomer, string id, string firstName, string lastName)
        {
            TypeOfCustomer = typeOfCustomer;
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
    public class EmailRepo
    {
        public List<EmailProp> customer = new List<EmailProp>();
        public void AddCustomerToList() { }
        public bool AddCustomerToList(EmailProp newItem)
        {
            int StartCount = customer.Count;
            customer.Add(newItem);
            bool wasAdded = (customer.Count > StartCount) ? true : false;
            return wasAdded;
        }
        public List<EmailProp> FindCustomer()
        {
            return customer;
        }
        public EmailProp GetCustomerByID(string id)
        {
            foreach (EmailProp customer in customer)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public bool DeleteExisting(EmailProp existingCustomer)
        {
            bool deleteResult = customer.Remove(existingCustomer);
            return deleteResult;
        }
        public bool UpdateExistingCustomer(string firstID, EmailProp newCustomer)
        {
            EmailProp oldcustomer = GetCustomerByID(firstID);

            if (oldcustomer != null)
            {
                oldcustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
                oldcustomer.ID = newCustomer.ID;
                oldcustomer.FirstName = newCustomer.FirstName;
                oldcustomer.LastName = newCustomer.LastName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
