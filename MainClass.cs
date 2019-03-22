
using System;
using System.Collections.Generic;

namespace C__LD
{
	class MainClass
	{
		public static List <Student> students = new List<Student>();
		public static void menu()
		{
			Console.WriteLine(("").PadLeft(55,'-'));
			Console.WriteLine("1 - irasyti nauja studenta");
			Console.WriteLine("2 - perziureta sarasa esamu studentu");
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