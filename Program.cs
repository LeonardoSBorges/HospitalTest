using HospitaTest.Entities;
using System;

namespace HospitaTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.StartProgram();
            Console.WriteLine(menu.ToString());
        }
    }
}
