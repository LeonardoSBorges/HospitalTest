using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class EmergencyQueue
    {
        public Person head { get; set; }
        public Person tail { get; set; }

        public EmergencyQueue()
        {
            head = null;
            tail = null;
        }

        public void Push(Person person)
        {
            if (Empty())
                head = tail = person;
            else
            {
                tail.next = person;
                tail = person;
            }
        }
        public bool search(Person person)
        {
            Person auxPerson = head;
            do
            {
                if (person.triage.Comorbidities < auxPerson.triage.Comorbidities)
                {
                    return true;
                }


            } while (auxPerson != null);
            return false;
        }
        public Person Pop()
        {
            Person removePerson = head;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
            }
            return removePerson;
        }
        public bool Empty()
        {
            return head == null || tail == null;
        }

        public override string ToString()
        {
            Person value = head;
            string people = "";

            if (!Empty())
            {
                do
                {
                    people += $"{value.ToString()}";
                    value = value.next;
                } while (value != null);
            }
            return people == "" ? "Queue empty" : people;
        }
    }
}
