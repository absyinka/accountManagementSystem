using System;
using Humanizer;

namespace helloWorld
{
    public class Menu
    {
        public static void MenuSwitch()
        {
            bool check = true;

            do
            {
                ShowMainMenu();

                string option = Console.ReadLine();

                if (option.Equals("0"))
                {
                    check = false;
                    Console.WriteLine(Constants.ThankYouMessage);
                }
                else
                {
                    ShowSubMenu(option);
                }

                // var continueDecision = string.Empty;

                // do
                // {
                //     Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                //     continueDecision = (Console.ReadLine() ?? string.Empty);


                // } while (!continueDecision.Equals(Constants.YesOption, StringComparison.OrdinalIgnoreCase) &&
                //     !continueDecision.Equals(Constants.NoOption, StringComparison.OrdinalIgnoreCase));

                // check = continueDecision.Equals(Constants.YesOption, StringComparison.OrdinalIgnoreCase);

            } while (check);

        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("1. Account Holder Menu");
            Console.WriteLine("2. Account Manager Menu");
            Console.WriteLine("0. Quit");
        }

        public static void ShowAccountHolderMenu()
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Return");
        }

        public static void ShowAccountManagerMenu()
        {
            Console.WriteLine("1. Register Manager");
            Console.WriteLine("2. Login as Manager");
            Console.WriteLine("3. List AccountHolders");
            Console.WriteLine("0. Return");
        }

        public static void ShowAccountHolderDashboardMenu()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Save");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Request Loan");
            Console.WriteLine("6. Overdraft");
            Console.WriteLine("7. Update Details");
            Console.WriteLine("8. Change Password");
            Console.WriteLine("9. Set Pin/Change Pin");
        }

        public static void ShowSubMenu(string option)
        {
            var subOption = string.Empty;

            try
            {
                if (option.Equals("0"))
                {
                    return;
                }
                else if (option.Equals("1"))
                {
                    ShowAccountHolderMenu();
                    subOption = Console.ReadLine();
                    HandleAccountHolderMenu(subOption);
                }
                else if (option.Equals("2"))
                {
                    ShowAccountManagerMenu();
                    subOption = Console.ReadLine();
                    HandleAccountManagerMenu(subOption);
                }
                else
                {
                    throw new Exception(Constants.ActionNotRecognized);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public static void HandleAccountHolderDashboard(string miniOption)
        {
            if (miniOption.Equals("0"))
            {
                ShowSubMenu("1");

            }
            else if (miniOption.Equals("1"))
            {
                Console.WriteLine("We are here now!");

            }
            else
            {
                throw new Exception(Constants.ActionNotRecognized);
            }
        }

        public static void HandleAccountHolderMenu(string subOption)
        {
            if (subOption.Equals("0"))
            {
                return;
            }
            else if (subOption.Equals("1"))
            {
                DataProcess.RegisterAccountHolder();
                ShowSubMenu("1");
            }
            else if (subOption.Equals("2"))
            {
                AccountHolderRepository accountHolder = new AccountHolderRepository();
                Console.WriteLine("LOGIN");

                bool login = false;
                int tries = 3;

                do
                {
                    Console.Write("Enter your email: ");
                    string userEmail = Console.ReadLine();

                    Console.Write("Enter Password: ");
                    string userPassword = Console.ReadLine();

                    var isLogin = accountHolder.Login(userEmail, userPassword);

                    if (isLogin)
                    {
                        login = true;
                        ShowAccountHolderDashboardMenu();
                        var miniOption = Console.ReadLine();
                        HandleAccountHolderDashboard(miniOption);
                    }
                    else
                    {
                        if (tries > 1)
                        {
                            Console.WriteLine($"Incorrect email or passsword. You have {"tries".ToQuantity(--tries)} left");
                        }
                        else
                        {
                            Console.WriteLine("Account Locked!. Contact The Admin");
                            break;
                        }
                    }

                } while (!login);

            }
            else if (subOption.Equals("3"))
            {
                DataProcess.ListAccountHolders();
                ShowSubMenu("1");
            }
            else
            {
                throw new Exception(Constants.ActionNotRecognized);
            }
        }

        public static void HandleAccountManagerMenu(string subOption)
        {
            if (subOption.Equals("0"))
            {
                return;
            }
            else if (subOption.Equals("1"))
            {
                DataProcess.RegisterManager();
                ShowSubMenu("2");
            }
            else if (subOption.Equals("2"))
            {
                Console.WriteLine("Hey, manager you successfully logged in!");
                ShowSubMenu("1");
            }
            else if (subOption.Equals("3"))
            {
                DataProcess.ListAccountHolders();
                ShowSubMenu("2");
            }
            else
            {
                throw new Exception(Constants.ActionNotRecognized);
            }
        }
    }
}
