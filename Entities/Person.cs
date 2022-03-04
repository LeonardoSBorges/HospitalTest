using System;

namespace HospitaTest.Entities
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string Stats { get; set; }
        public Triage triage { get; set; }
        public Person next { get; set; }
        public Person(string name, DateTime birthDate, string cPF)
        {
            Name = name;
            Age = AgeCalculator(birthDate);
            CPF = cPF;
            BirthDate = birthDate;
            next = null;
        }
        public void StatsPerson()
        {
            if (!triage.IsEmergecy())
            {
                if (triage.Confirm())
                {
                    Console.WriteLine($"[0 - HospitalBed / 2 - Quarentine/ 3 - Discharge]");
                    string Value = Console.ReadLine();
                    Stats = Value;

                }
                else
                    Stats = "0";
            }
            else
            {
                Stats = "0";
            }
        }
        private int AgeCalculator(DateTime birthDate)
        {
            DateTime aux = DateTime.Now;
            int years = (aux.Year - birthDate.Year);
            return aux.Month < birthDate.Month ? years-- : years;
        }

        public void PushTriage(int count)
        {
            Console.WriteLine(Name);
            triage = new Triage(count);
        }

        public override string ToString()
        {
            string Value = "";

            if (triage != null)
            {
                Value = $@"
{Name}
{BirthDate.ToString("dd/MM/yyyy")}
{CPF}
{triage.ToString()}
";
            }
            else
            {
                Value = $@"
{Name}
{BirthDate.ToString("dd/MM/yyyy")}
{CPF}
";
            }

            return Value;

        }

    }
}
