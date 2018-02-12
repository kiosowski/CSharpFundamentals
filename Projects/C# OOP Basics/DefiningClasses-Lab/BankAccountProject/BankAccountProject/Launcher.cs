using System;
using System.Collections.Generic;

class Launcher
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var cmdArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cmdType = cmdArgs[0];
            switch (cmdType)
            {
                case "Create":
                    Create(cmdArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, accounts);
                    break;
                case "Print":
                    Print(cmdArgs, accounts);
                    break;
                default:
                    break;
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id].ToString());
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = int.Parse(cmdArgs[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(amount);
            }
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = int.Parse(cmdArgs[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Deposit(amount);
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = id;
            accounts.Add(id, acc);
        }
    }
}
