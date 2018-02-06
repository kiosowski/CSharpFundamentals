using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {

            var input = string.Empty;
            var hospital = new Dictionary<string, Dictionary<string, string>>();
            while ((input = Console.ReadLine()) != "Output")
            {
                var splitted = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var departament = splitted[0];
                var doctor = splitted[1] + " " + splitted[2];
                var patient = splitted[3];

                if (!hospital[departament].ContainsKey(doctor))
                {
                    hospital[departament] = new Dictionary<string, string>();
                }
                hospital[departament][doctor] = patient;
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();


            }

        }
    }
}

