
using System;
using System.Collections.Generic;

namespace C__LD
{
	class MainClass
	{
		public static void menu()
		{
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("1 - irasyti nauja studenta");
			Console.WriteLine("2 - perziureta sarasa esamu studentu");
			Console.WriteLine("0 - baigti darba");
		}
		
		
		public static void Main(string[] args)
		{
			menu();
			int choice = Convert.ToInt32(Console.ReadLine());
			while (choice != 0) {
				switch (choice) {					
					case 1:
						Student.createNewStudent();
						break;
					case 2:
						Student.showAll();
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Netinkamai ivestas pasirinkimas,\nbandykite dar karta");
						Console.WriteLine();
						break;
				}
				menu();
				choice = Convert.ToInt32(Console.ReadLine());
			}
		
			Console.ReadKey();
		}
	}
}