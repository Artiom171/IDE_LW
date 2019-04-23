
using System;
using System.Collections.Generic;

namespace C__LD
{
	class MainClass
	{
		public static List <Student> students = new List<Student>();
        Student stud = new Student();
        public static void menu()
		{
			Console.WriteLine(("").PadLeft(55,'-'));
			Console.WriteLine("1 - irasyti nauja studenta");
			Console.WriteLine("2 - perziureta sarasa esamu studentu");
			Console.WriteLine("3 - nuskaito iš failo");
            Console.WriteLine("4 - sugeneruoti studentus i atskirus failus");
			Console.WriteLine("0 - baigti darba");
			Console.WriteLine(("").PadLeft(55,'-'));
        }
		
		
		public static void Main(string[] args)
		{
			menu();
            Student stud = new Student();
            stud.choosing();
			Console.ReadKey();
		}
		
	}
}