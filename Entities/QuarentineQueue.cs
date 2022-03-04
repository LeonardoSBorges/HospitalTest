using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class QuarentineQueue
    {
        public Person head { get; set; }
        public Person tail { get; set; }

        public QuarentineQueue()
        {
            head = null;
            tail = null;
        }

        public void Push(Person person)
        {
            if (Empty())
            {
                person.Stats = "1";
                head = tail = person;
            }
            else
            {
                person.Stats = "1";
                tail.next = person;
                tail = person;
            }
        }

        public bool Empty()
        {
            return head == null || tail == null;
        }
        public Person Pop()
        {
            Person removePerson = head;
            if (head == tail)
            {

                removePerson.Stats = "3";
                head = null;
                tail = null;
            }
            else
            {
                removePerson.Stats = "3";
                head = head.next;
            }
            return removePerson;
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
