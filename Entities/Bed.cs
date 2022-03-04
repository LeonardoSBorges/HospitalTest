using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class Bed
    {

        public int AmountBed { get; set; }
        public int Count { get; set; }
        public Person head { get; set; }
        public Person tail { get; set; }

        public Bed()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public string Get()
        {
            return "Beds available: " + AmountBed;
        }
        public void Push(Person person)
        {
            if (person.Stats == "0")
            {
                if (Empty())
                {
                    head = tail = person;
                    Count++;
                }
                else if (Count < AmountBed)
                {
                    tail.next = person;
                    tail = person;
                    Count++;
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
                    Count--;
                }
                else
                {
                    if (patient1 == head)
                    {
                        head.Stats = "3";
                        head = patient1.next;
                        Count--;
                    }
                    else if (patient1 == tail)
                    {

                        patient1.Stats = "3";
                        tail = patient2;
                        patient2 = null;
                        Count--;
                    }
                    else
                    {
                        patient1.Stats = "3";
                        patient2 = patient1.next;
                        Count--;
                    }
                }

                if (patient1 == patient2)
                    patient1 = patient1.next;
                else
                {
                    patient1 = patient1.next;
                    patient2 = patient2.next;
                }

            } while (value < AmountBed);
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
                } while (i < AmountBed);
            }
            return people == "" ? "All is beds available" : people;
        }

    }
}
