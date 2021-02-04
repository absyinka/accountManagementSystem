using System;

namespace helloWorld
{
    public class AccountHolder : Details
    {
        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string AccountNumber { get; set; }

        public double AccountBalance { get; set; }

        public int AccountStatus { get; set; }

        public int Pin { get; set; }

        public DateTime CreatedAt { get; set; }


        public AccountHolder(int id, string firstName, string lastName, string middleName, string email, string password, DateTime dateOfBirth, string phoneNumber, string address, string accountNumber, DateTime createdAt, double accountBalance = 0.00, int accountStatus = 1, int pin = 0) : base(id, firstName, lastName, middleName, email, password)
        {

            DateOfBirth = dateOfBirth;

            PhoneNumber = phoneNumber;

            Address = address;

            AccountNumber = accountNumber;

            AccountBalance = accountBalance;

            AccountStatus = accountStatus;

            Pin = pin;

            CreatedAt = createdAt;
        }

        internal static AccountHolder TextSplitter(string line)
        {
            var props = line.Split("\t");

            int id = int.Parse(props[0]);

            DateTime dateOfBirth = DateTime.Parse(props[6]);

            DateTime createdAt = DateTime.Parse(props[13]);

            double accountBalance = double.Parse(props[10]);

            int accountStatus = int.Parse(props[11]);

            int pin = int.Parse(props[12]);
            
            return new AccountHolder(id, props[1], props[2], props[3], props[4], props[5], dateOfBirth, props[7], props[8], props[9], createdAt, accountBalance, accountStatus, pin);
        }

        public string ReturnToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{MiddleName}\t{Email}\t{Password}\t{DateOfBirth}\t{PhoneNumber}\t{Address}\t{AccountNumber}\t{AccountBalance}\t{AccountStatus}\t{Pin}\t{CreatedAt}";
        }

    }
}
