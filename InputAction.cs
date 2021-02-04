//using System;

//namespace helloWorld
//{

//    class InputAction
//    {
//        static Account account = new Account(1000000, 500000, "5100");

//        InputConverter inputConverter = new InputConverter ();

//        public string EnterName()
//        {
//            Console.WriteLine (Constants.EnterYourName);
//            var user = Console.ReadLine();
//            return user;
//        }

//        public string EnterPin()
//        {
//            Console.WriteLine(Constants.EnterPin);
//            var pin = Console.ReadLine();
//            return pin;
//        }

//        public bool CheckPin(string pin, string userPin = account.GetUserPin)
//        {
//            var result = pin == userPin;

//            return result;
//        }


//        // public int ReadAccountType () {
//        //     var result = 0;
//        //     try {
//        //         do {

//        //             Console.Clear ();
//        //             Console.WriteLine ("Choose account type: ");
//        //             Console.WriteLine ();
//        //             Console.WriteLine ("1. Savings");
//        //             Console.WriteLine ("2. Current");

//        //             result = inputConverter.ConvertInputToInteger (Console.ReadLine ());

//        //             if(result != 1 || result != 2)
//        //             {
//        //                 throw new Exception("Invalid option selected!");
//        //             }
                    
//        //             var moreOperationOption = string.Empty;

//        //             do
//        //             {
//        //                 Console.Write(Constants.MoreOperationOptionPrompt);
//        //                 moreOperationOption = (Console.ReadLine() ?? string.Empty);

//        //             } while (!moreOperationOption.Equals(Constants.YesOption, StringComparison.OrdinalIgnoreCase) &&
//        //                 !moreOperationOption.Equals(Constants.NoOption, StringComparison.OrdinalIgnoreCase)
//        //             );

//        //             correctAcctType = !result.Equals (1) || !result.Equals (2);

//        //         } while (correctAcctType);
//        //     }
//        //     catch (Exception ex) {
//        //         Console.WriteLine ("Invalid input: " + ex.Message);
//        //     }
//        //     return result;
//        // }

//        public void AddFund (string subOption) {
//            var result = string.Empty;
//            try {
//                Console.WriteLine ("Enter the amount to save: ");
//                var fund = inputConverter.ConvertInputToDouble (Console.ReadLine ());
//                var accountType = account.GetAccountType(subOption);
//                var currentBalance = account.GetBalance(accountType); 

//                if(subOption == "0"){
//                    return;
//                } else if (subOption == "1"){
//                    account.Deposit(fund, accountType);
//                    result = $"{Constants.AccountBalanceStatement} {accountType} {currentBalance}";
//                } else {
//                    account.Deposit(fund, "2");
//                    result = $"{Constants.AccountBalanceStatement} {accountType} {currentBalance}";
//                }
//            }
//            catch (Exception ex) {
//                Console.WriteLine ("Invalid input: " + ex.Message);
//            }

//            Console.WriteLine(result);
//        }

//        public double WithdrawFund () {
//            double amountToWithdraw = 0;
//            try {
//                Console.Clear ();
//                Console.WriteLine ("Enter the amount to withdraw: ");
//                amountToWithdraw = inputConverter.ConvertInputToDouble (Console.ReadLine ());
//            }
//            catch (Exception ex) {
//                Console.WriteLine ("Invalid input: " + ex.Message);
//            }

//            return amountToWithdraw;
//        }
//    }
//}