using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Humanizer;

namespace helloWorld
{
    public class AccountHolderRepository
    {
        public List<AccountHolder> AccountHolders;

        public AccountHolderRepository()
        {
            AccountHolders = new List<AccountHolder>();

            try
            {
                if (!File.Exists("accountholders.txt"))
                {
                }
                else
                {
                    var lines = File.ReadAllLines("accountholders.txt");

                    foreach (var line in lines)
                    {
                        var account = AccountHolder.TextSplitter(line);
                        AccountHolders.Add(account);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Read(AccountHolder accountHolder)
        {
            Console.WriteLine($"{accountHolder.Id} {accountHolder.FirstName} {accountHolder.LastName} {accountHolder.MiddleName} {accountHolder.Email} {accountHolder.Password} {accountHolder.DateOfBirth.Humanize()} {accountHolder.PhoneNumber} {accountHolder.Address} {accountHolder.AccountNumber} {accountHolder.Pin} {accountHolder.CreatedAt.ToOrdinalWords()}");
        }

        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }

        public void List()
        {
            bool isEmpty = IsEmpty(AccountHolders);

            if (isEmpty)
            {
                Console.WriteLine("No records found!");
            }

            foreach (AccountHolder accountHolder in AccountHolders)
            {
                Read(accountHolder);
            }
        }

        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("accountholders.txt");
            foreach (var accounts in AccountHolders)
            {
                writer.WriteLine(accounts);
            }
            writer.Flush();
            writer.Close();
        }

        public void CreateAccountHolder(int id, string firstName, string lastName, string middleName, string email, string password, DateTime dateOfBirth, string phoneNumber, string address, string confirmPassword, string accountNumber, DateTime createdAt)
        {

            AccountHolder accountHolder = new AccountHolder(id, firstName, lastName, middleName, email, password, dateOfBirth, phoneNumber, address, accountNumber, createdAt);


            if (password == confirmPassword)
            {
                var accountHolders = FindByIdOrEmail(id, email);

                if (accountHolders == null)
                {
                    AccountHolders.Add(accountHolder);

                    TextWriter writer = new StreamWriter("accountholders.txt", true);

                    writer.WriteLine(accountHolder.ReturnToString());

                    writer.Close();

                    Console.WriteLine("Account created successfully!");

                }
                else
                {
                    Console.WriteLine("Account already Exist!");
                }
            }
            else
            {
                Console.WriteLine(Constants.PasswordDoesNotMatch);
            }

        }

        public AccountHolder FindByIdOrEmail(int id, string email)
        {
            return AccountHolders.Find(i => i.Id == id || i.Email == email);
        }

        public AccountHolder FindByEmail(string email)
        {
            return AccountHolders.Find(i => i.Email == email);
        }


        public void UpdateAccountHolder(int id, string firstName, string lastName, string middleName, string phoneNumber, string address, string email)
        {
            var update = FindByIdOrEmail(id, email);
            update.FirstName = firstName;
            update.LastName = lastName;
            update.MiddleName = middleName;
            RefreshFile();
        }

        public void UpdateAccountHolderPassword(int id, string email, string password, string oldPassword, string confirmPassword)
        {
            var update = FindByIdOrEmail(id, email);

            try
            {
                if (oldPassword == update.Password)
                {

                    if (password == confirmPassword)
                    {
                        update.Password = password;
                        RefreshFile();
                    }
                    else
                    {
                        throw new Exception(Constants.PasswordDoesNotMatch);
                    }

                }
                else
                {
                    throw new Exception("Password provided does not match the current password");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveAccountHolder(int id, string email)
        {
            var delete = FindByIdOrEmail(id, email);
            AccountHolders.Remove(delete);
            RefreshFile();
        }

        public void GenerateTenUniqueRandomDigits()
        {

        }

        public bool Login(string userEmail, string userPassword)
        {

            bool isloggedIn = false;

            foreach (AccountHolder account in AccountHolders)
            {
                if (userEmail == account.Email && userPassword == account.Password)
                {
                    isloggedIn = true;
                }
            }

            return isloggedIn;
        }

    }
}
