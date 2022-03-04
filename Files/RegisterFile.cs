//using HospitaTest.Entities;
//using System;
//using System.IO;

//namespace HospitaTest.Files
//{
//    internal class RegisterFile
//    {
//        public Person person { get; set; }

//        public RegisterFile()
//        {
//            person = GetRegister();
//        }
//        public void PushRegister(Person person)
//        {
//            Person personRegister;
//            string NameFile = @"C:\Users\LeonardoBorges\source\repos\ExerciciosAula\ListaDeExercicios\HospitaTest\SaveFiles\" + DateTime.Now.ToString("dd/MM/yyyy") + ".csv";

//            try
//            {
//                StreamWriter sw = new StreamWriter(NameFile);
//                while(())
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//        public Person GetRegister()
//        {
//            Person personRegister;
//            string NameFile = @"C:\Users\LeonardoBorges\source\repos\ExerciciosAula\ListaDeExercicios\HospitaTest\SaveFiles";
//            if (File.Exists(NameFile))
//            {
//                try
//                {
//                    StreamReader sr = new StreamReader(NameFile);
//                    string line;
//                    while ((line = sr.ReadLine()) != null)
//                    {

//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Type error: " + ex.Message);
//                }
//            }

//            return
//        }
//    }
//}
