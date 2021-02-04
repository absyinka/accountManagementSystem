using System;


namespace helloWorld
{
    public class DataProcess
    {
        static InputConverter inputConverter = new InputConverter();
        static AccountHolderRepository accountHolder = new AccountHolderRepository();

        static ManagerRepository managerAccount = new ManagerRepository();
        public static void RegisterAccountHolder()
        {
            Console.WriteLine("CREATE AN ACCOUNT");

            Console.WriteLine("Enter ID: ");
            int id = inputConverter.ConvertInputToInteger(Console.ReadLine());

            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Middle Name: ");
            string middleName = Console.ReadLine();

            Console.WriteLine("Enter Date of Birth(yyyy/mm/dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Email Address: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Address: ");
            string address = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password: ");
            string confirmPassword = Console.ReadLine();

            string accountNumber = "0049070317";

            DateTime createdAt = DateTime.Now;

            accountHolder.CreateAccountHolder(id, firstName, lastName, middleName, email, password, dateOfBirth, phoneNumber, address, confirmPassword, accountNumber, createdAt);

        }

        public static void RegisterManager()
        {
            Console.WriteLine("Enter ID: ");
            int id = inputConverter.ConvertInputToInteger(Console.ReadLine());

            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Middle Name: ");
            string middleName = Console.ReadLine();

            Console.WriteLine("Enter Email Address: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password: ");
            string confirmPassword = Console.ReadLine();

            managerAccount.CreateAccountManager(id, firstName, lastName, middleName, email, password, confirmPassword);
        }

        public static void ListAccountHolders()
        {
            accountHolder.List();
        }

    }
}
