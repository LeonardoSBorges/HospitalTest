using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class Bed
    {

        public Person head { get; set; }
        public Person tail { get; set; }

        public Bed()
        {
            head = null;
            tail = null;
        }
        public string Get()
        {
            return "Beds available: " ;
        }
        public void Push(Person person)
        {
            if (person.Stats == "0")
            {
                if (Empty())
                {
                    head = tail = person;
                }
                else 
                {
                    tail.next = person;
                    tail = person;
                }
            }
        }
        public void Pop()
        {
            Person patient1 = head, patient2 = head;
            ToString();
            Console.Write("Insert the bed number to discharge: ");
            bool Flag = int.TryParse(Console.ReadLine(), out int value);
            do
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    if (patient1 == head)
                    {
                        head.Stats = "3";
                        head = patient1.next;
                        break;
                    }
                    else if (patient1 == tail)
                    {

                        patient1.Stats = "3";
                        tail = patient2;
                        patient2 = null;
                        break;
                    }
                    else
                    {
                        patient1.Stats = "3";
                        patient2 = patient1.next;
                        break;
                    }
                }

                if (patient1 == patient2)
                    patient1 = patient1.next;
                else
                {
                    patient1 = patient1.next;
                    patient2 = patient2.next;
                }

            } while (patient1 != null);
        }
        public bool Empty()
        {
            return head == null || tail == null;
        }

        public override string ToString()
        {
            Person value = head;
            string people = "";
            int i = 0;
            if (!Empty())
            {
                do
                {
                    people += $"Bed #{i + 1} \n{value.ToString()}";
                    value = value.next;
                } while (value != null);
            }
            return people == "" ? "All is beds available" : people;
        }

    }
}
