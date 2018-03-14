using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Engine
{
    private DraftManager maneger;
    public Engine()
    {
        this.maneger = new DraftManager();
    }
    public void Run()
    {
        string input = Console.ReadLine();
        while (input != "Shutdown")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(maneger.RegisterHarvester(tokens.Skip(1).ToList()));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(maneger.RegisterProvider(tokens.Skip(1).ToList()));
                    break;
                case "Day": Console.WriteLine(maneger.Day());
                    break;
                case "Mode":
                    Console.WriteLine(maneger.Mode(tokens.Skip(1).ToList()));
                    break;
                case "Check":
                    Console.WriteLine(maneger.Check(tokens.Skip(1).ToList()));
                    break;
                default:
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine(maneger.ShutDown());
    }
}

