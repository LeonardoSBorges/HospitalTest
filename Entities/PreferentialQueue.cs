using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitaTest.Entities
{
    internal class PreferentialQueue
    {
        public Person head { get; set; }
        public Person tail { get; set; }

        public PreferentialQueue()
        {
            head = null;
            tail = null;
        }

        public void Push(Person newPerson)
        {
            if (Empty())
                head = tail = newPerson;
            else
            {
                tail.next = newPerson;
                tail = newPerson;
            }
        }
        public Person Pop()
        {
            Person removePerson = head;
            if(head == tail)
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
            return head == null && tail == null;
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
