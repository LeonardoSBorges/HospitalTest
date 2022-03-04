using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class Triage
    {
        public string AllSymptoms { get; set; }
        public int DaysSymptomatic { get; set; }
        public int Comorbidities { get; set; }
        public bool Emergency { get; set; }
        public bool ChanceCovid { get; set; }

        public Triage(int count)
        {
            AllSymptoms = Symptoms();
            DaysSymptomatic = Days();
            Comorbidities = AmountComorbidities();
            ChanceCovid = Confirm();
        }
        
        // proxima pessoa da fila
        public bool IsEmergecy()
        {
            if (!Confirm())
            {
                return false;
            }
            bool Flag = false;
            int Value = 0;
            while (Flag != true)
            {
                Console.WriteLine("Is Emergency? [1 - Yes/2 - No]");
                Flag = int.TryParse(Console.ReadLine(), out Value);
            }
            Emergency = Flag;
            return  Value == 1 ? true : false;
        }

        public string Symptoms()
        {
            int option = -1;
            Console.WriteLine("Chose the pacient symptoms: \n1-Fever\n2-Loss of taste\n3-Loss of smell\n4-Headache\n0-Exit");
            do
            {
                string AllSymptoms = "";
                bool Flag = false;
                
                while (Flag != true) 
                {
                    Flag = int.TryParse(Console.ReadLine(), out option);
                    if(Flag == false)
                        Console.WriteLine("Insert a valid value");
                }
                if (Flag)
                {
                    if (option != 0 && AllSymptoms != "")
                        AllSymptoms += ", ";
                    switch (option)
                    {
                        case 1:
                            AllSymptoms += "Fever";
                            break;
                        case 2:
                            AllSymptoms += "Loss of taste";
                            break;
                        case 3:
                            AllSymptoms += "Loss of smell";
                            break;
                        case 4:
                            AllSymptoms += "Headache";
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                else
                    Console.WriteLine("Invalid option!");

                
            } while (option != 0);

            return AllSymptoms == "" ? "Nothing symptom" : AllSymptoms;
        }

        public int Days()
        {
            bool Flag = false;
            int value = -1;
            while (Flag != true)
            {
                Console.Write("How many days are you have symptoms:");
                Flag = int.TryParse(Console.ReadLine(), out value);

                if (Flag == false)
                    Console.WriteLine("Insert a valid value");
            }
            return value;
        }

        public int AmountComorbidities()
        {
           
            if (Confirm())
            {
                bool Flag = false;
                int Value = -1;
                while (Flag != true)
                {
                    Console.Write("How many comorbidities:");
                    Flag = int.TryParse(Console.ReadLine(), out Value);
                    if (Flag == false)
                        Console.WriteLine("Insert a valid value");
                }
                return Value;
            }
            return 0;
        }

        public bool Confirm()
        {
            if (DaysSymptomatic < 3)
                return false;
            else
            {
                return AllSymptoms != "Nothing symptom"? true : false;
            }
            
        }

        public override string ToString()
        {
            return $@"
{AllSymptoms}
{DaysSymptomatic}
{Comorbidities}
{Emergency}
{ChanceCovid}
";
        }
    }
}
