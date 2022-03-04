using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class Menu
    {
        public PreferentialQueue preferenctialQueue { get; set; }
        public QuarentineQueue quarentineQueue { get; set; }
        public EmergencyQueue emergencyQueue { get; set; }
        public Queue queue { get; set; }
        public int count { get; set; }
        public int TicketService { get; set; }
        public Person person { get; set; }
        public Bed bed { get; set; }

        public Menu()
        {
            preferenctialQueue = new PreferentialQueue();
            quarentineQueue = new QuarentineQueue();
            emergencyQueue = new EmergencyQueue();
            queue = new Queue();
            bed = new Bed();
            count = 0;
            TicketService = 0;
        }

        public void StartProgram()
        {

            //Quantidade de leitos
            //Console.Write("Beds available: ");
            //bed.AmountBed = int.Parse(Console.ReadLine());
            int opc = -1;
            do
            {
                bool Flag = false;
                Console.WriteLine("============= Covidario do Papini (Nao saia vivo) ============= Service Ticket " + TicketService + "    " + bed.Get());
                Console.Write("1 - Register\n2 - Triage\n3 - View Preferential queue\n4 - View queue\n5 - View Quarentine queue\n6 - view emergency queue\n7 - Beds\n8 - Next person to bed\n9 - Discharge of bed\n0 - Next\n10 - Exit\nInsert an option: ");
                while (Flag != true)
                {
                    Flag = int.TryParse(Console.ReadLine(), out opc);
                    if (Flag == false)
                        Console.WriteLine("Insert a valid value");
                }
                switch (opc)
                {
                    case 1:

                        person = RegisterPerson();
                        if (person.Age >= 60)
                            preferenctialQueue.Push(person);
                        else
                            queue.Push(person);
                        break;
                    case 2:

                        if (count < 2 && !preferenctialQueue.Empty())
                        {
                            person = preferenctialQueue.Pop();
                            person.PushTriage(count);
                            count++;
                        }
                        else if (!queue.Empty())
                        {
                            person = queue.Pop();
                            person.PushTriage(count);
                            count = 0;
                        }


                        QuarentineOrEmergencyQueue(person);

                        break;
                    case 3:
                        Console.WriteLine(preferenctialQueue.ToString());
                        break;
                    case 4:
                        Console.WriteLine(queue.ToString());
                        break;
                    case 5:
                        Console.WriteLine(quarentineQueue.ToString());
                        break;
                    case 6:
                        Console.WriteLine(emergencyQueue.ToString());
                        break;
                    case 7:
                        Console.WriteLine(bed.ToString());
                        break;
                    case 8:
                        if (!emergencyQueue.Empty())
                            bed.Push(emergencyQueue.Pop());
                        else
                            Console.WriteLine(emergencyQueue.ToString());
                        break;
                    case 9:
                        if (!bed.Empty())
                            bed.Pop();
                        else
                            Console.WriteLine(bed.ToString());
                        break;
                    case 0:
                        TicketService++;
                        break;
                    case 10:
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            } while (opc != 10);
        }
        public void QuarentineOrEmergencyQueue(Person person)
        {
            person.StatsPerson();

            if (person.Stats == "2")
                quarentineQueue.Push(person);
            else if (person.triage.Emergency)
            {
                emergencyQueue.Push(person);
            }


        }
        public Person RegisterPerson()
        {
            bool Flag = false;
            DateTime date = new DateTime(2002, 09, 01);
            Console.Write("Insert CPF: ");
            string Cpf = Console.ReadLine();
            Console.Write("Insert name:");
            string name = Console.ReadLine();
            while (Flag != true)
            {
                Console.Write("Insert birth date: ");
                Flag = DateTime.TryParse(Console.ReadLine(), out date);
            }

            return new Person(name, date, Cpf);

        }
        public void OccupationBeds()
        {
            if (!emergencyQueue.Empty())
            {
                bed.Push(emergencyQueue.Pop());
            }
        }

    }
}
