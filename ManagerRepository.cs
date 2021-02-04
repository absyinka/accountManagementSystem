using System;
using System.Collections.Generic;

namespace helloWorld
{
    public class ManagerRepository
    {
        AccountHolderRepository accountHolder = new AccountHolderRepository();
        public List<Manager> Managers = new List<Manager>();

        public void CreateAccountManager(int id, string firstName, string lastName, string middleName, string email, string password, string confirmPassword)
        {
            Manager manager = new Manager(id, firstName, lastName, middleName, email, password);

            var managers = FindByIdOrEmail(id, email);

            if (password == confirmPassword)
            {
                if (managers == null)
                {
                    Managers.Add(manager);
                    
                    Console.WriteLine("Manager account created successfully!");
                }
                else
                {
                    Console.WriteLine("Manager account already Exist!");
                }
            }
            else
            {
                Console.WriteLine("Password do not match!");
            }

        }

        public void UpdateAccountManagerDetail(int id, string email, string firstName, string lastName, string middleName)
        {
            var update = FindByIdOrEmail(id, email);
            update.FirstName = firstName;
            update.LastName = lastName;
            update.MiddleName = middleName;
        }

        
        public void ReadManagerRecords(Manager manager)
        {
            Console.WriteLine($"{manager.Id} {manager.FirstName} {manager.LastName} {manager.MiddleName} {manager.Email}");
        }

        public void ShowManagerRecords()
        {
            foreach (Manager manager in Managers)
            {
                ReadManagerRecords(manager);
            }
        }

        public Manager FindByIdOrEmail(int id, string email)
        {
            return Managers.Find(i => i.Id == id || i.Email == email);
        }
    }
}