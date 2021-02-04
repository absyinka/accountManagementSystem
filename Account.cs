namespace helloWorld
{
    class Account
    {
        private double savingAccountBalance;
        private double currentAccountBalance;
        private string userPin;

        public Account(double SavingAccountBalance, double CurrentAccountBalance, string UserPin)
        {
            savingAccountBalance = SavingAccountBalance;
            currentAccountBalance = CurrentAccountBalance;
            userPin = UserPin;
        }

        public string GetUserPin
        {
            get { return userPin; }
            set { userPin = value; }
        }

        public void Deposit(double amount, string acctType)
        {

            if (acctType == "Savings")
            {
                savingAccountBalance += amount;
            }
            else
            {
                currentAccountBalance += amount;
            }

        }
        public void Withdraw(double amount, string acctType)
        {

            if (acctType == "Savings")
            {
                savingAccountBalance -= amount;
            }
            else
            {
                currentAccountBalance -= amount;
            }
        }

        public double GetBalance(string acctType)
        {

            if (acctType == "Savings")
            {
                return savingAccountBalance;
            }
            else
            {
                return currentAccountBalance;
            }

        }

        public string GetAccountType(string readAccountType)
        {

            return readAccountType == "1" ? "Savings" : "Current";

        }
    }
}