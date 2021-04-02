using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emails
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmailUI ui = new EmailUI();
            ui.Run();
        }
        public class EmailUI
        {
            public EmailRepo repo = new EmailRepo();
            public void Run()
            {
                MenuUI();
            }
            public List<EmailProp> customer = new List<EmailProp>();
            private void MenuUI()
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the number you want to select:\n" +
                            "1. Show all customers\n" +
                            "2. Show customer by ID\n" +
                            "3. Add new customer\n" +
                            "4. Update existing customer\n" +
                            "5. Show customer email table\n" +
                            "6. Remove customer\n" +
                            "7. Exit");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            ShowCustomer();
                            break;
                        case "2":
                            ShowCustomerByID();
                            break;
                        case "3":
                            AddNewCustomer();
                            break;
                        case "4":
                            UpdateExistingCustomer();
                            break;
                        case "5":
                            showCustomerEmailTable();
                            break;
                        case "6":
                            DeleteCustomerByID();
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            public void ShowCustomers(EmailProp customer)
            {
                Console.WriteLine(customer.TypeOfCustomer);
                Console.WriteLine(customer.ID);
                Console.WriteLine(customer.FirstName);
                Console.WriteLine(customer.LastName);
                if (customer.TypeOfCustomer == TypeOfCustomer.Past)
                {
                    Console.WriteLine("It's been a long time since we've heard from you, we want you back");
                }
                else if (customer.TypeOfCustomer == TypeOfCustomer.Current)
                {
                    Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                }
                else if (customer.TypeOfCustomer == TypeOfCustomer.Potential)
                {
                    Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                }
            }
            public void ShowCustomer()
            {
                Console.Clear();
                List<EmailProp> listOfCustomers = repo.FindCustomer();
                foreach (EmailProp customer in listOfCustomers)
                {
                    ShowCustomers(customer);
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            private void ShowCustomerByID()
            {
                Console.Clear();
                Console.WriteLine("Enter the cusotmer id you'd like to find.");
                string id = Console.ReadLine();

                EmailProp customer = repo.GetCustomerByID(id);

                if (customer != null)
                {
                    ShowCustomers(customer);
                }
                else
                {
                    Console.WriteLine("That customer doesn't exist.");
                }
                Console.ReadKey();
            }
            private void AddNewCustomer()
            {
                EmailProp newCustomer = new EmailProp();
                Console.Clear();
                Console.WriteLine("Enter the number for the type of customer you wish to add:\n" +
                       "1. Past\n" +
                       "2. Current\n" +
                       "3. Potential\n");
                string input = Console.ReadLine();
                bool stopRunning = false;
                while (!stopRunning)
                {

                    switch (input)
                    {
                        case "1":
                            newCustomer.TypeOfCustomer = TypeOfCustomer.Past;
                            stopRunning = true;
                            break;
                        case "2":
                            newCustomer.TypeOfCustomer = TypeOfCustomer.Current;
                            stopRunning = true;
                            break;
                        case "3":
                            newCustomer.TypeOfCustomer = TypeOfCustomer.Potential;
                            stopRunning = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            stopRunning = false;
                            break;
                    }
                }
                Console.WriteLine("Please enter the customer's ID.");
                newCustomer.ID = Console.ReadLine();
                Console.WriteLine("Please enter the customer's first name.");
                newCustomer.FirstName = Console.ReadLine();
                Console.WriteLine("Please enter the customer's last name.");
                newCustomer.LastName = Console.ReadLine();

                bool wasAdded = repo.AddCustomerToList(newCustomer);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your Customer was succesfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your Customer was not added.");
                }
            }
            private void UpdateExistingCustomer()
            {
                ShowCustomer();
                Console.WriteLine("Enter the customer id you want to change.");
                string idUpdate = Console.ReadLine();
                EmailProp customerToUpdate = repo.GetCustomerByID(idUpdate);

                Console.WriteLine("Enter the number of the customer type:\n" +
                       "1. Past\n" +
                       "2. Current\n" +
                       "3. Potential\n");
                string input = Console.ReadLine();
                bool stopRunning = false;
                while (!stopRunning)
                {
                    switch (input)
                    {
                        case "1":
                            customerToUpdate.TypeOfCustomer = TypeOfCustomer.Past;
                            stopRunning = true;
                            break;
                        case "2":
                            customerToUpdate.TypeOfCustomer = TypeOfCustomer.Current;
                            stopRunning = true;
                            break;
                        case "3":
                            customerToUpdate.TypeOfCustomer = TypeOfCustomer.Potential;
                            stopRunning = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            stopRunning = false;
                            break;
                    }
                }
                Console.WriteLine("Please enter the customer's ID.");
                customerToUpdate.ID = Console.ReadLine();
                Console.WriteLine("Please enter the customer's first name.");
                customerToUpdate.FirstName = Console.ReadLine();
                Console.WriteLine("Please enter the customer's last name.");
                customerToUpdate.LastName = Console.ReadLine();
                bool wasChanged = repo.AddCustomerToList(customerToUpdate); ;

                if (wasChanged)
                {
                    Console.WriteLine("This customer was successfully changed.");
                }
                else
                {
                    Console.WriteLine("Customer could not be changed");
                }
            }
            private void showCustomerEmailTable()
            {
                Console.Clear();
                List<EmailProp> AtoZCustomers = repo.FindCustomer();
                AtoZCustomers.Sort((left, right) => string.Compare(left.LastName, right.LastName));
                Console.Write("{0,-15}", "CustomerType");
                Console.Write("{0,-15}", "FirstName");
                Console.Write("{0,-15}", "LastName");
                Console.WriteLine("Email");
                foreach (EmailProp customer in AtoZCustomers)
                {
                    Console.Write("{0,-15}", customer.TypeOfCustomer);
                    Console.Write("{0,-15}", customer.FirstName);
                    Console.Write("{0,-15}", customer.LastName);
                    if (customer.TypeOfCustomer == TypeOfCustomer.Past)
                    {
                        Console.WriteLine("It's been a long time since we've heard from you, we want you back");
                    }
                    else if (customer.TypeOfCustomer == TypeOfCustomer.Current)
                    {
                        Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                    }
                    else if (customer.TypeOfCustomer == TypeOfCustomer.Potential)
                    {
                        Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                    }
                }
                Console.ReadLine();
            }
            private void DeleteCustomerByID()
            {
                ShowCustomer();
                Console.WriteLine("Enter the ID for the customer you would like to delete.");
                string DeleteCustomerByID = Console.ReadLine();

                EmailProp customerToDelete = repo.GetCustomerByID(DeleteCustomerByID);
                bool wasDeleted = repo.DeleteExisting(customerToDelete);

                if (wasDeleted)
                {
                    Console.WriteLine("This Customer was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Customer could not be deleted");
                }
            }
        }
    }
}
