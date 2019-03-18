
using System;


namespace C__LD
{
	class Program
	{
		public static void menu()
		{
			Console.WriteLine("Sveiki, \nŠia programą yra galutinio studento balo skaičiuokle");
			Console.WriteLine("Pasirinkite veiksma");
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("1 - irasyti nauja studenta");
			Console.WriteLine("2 - perziureta sarasa esamu studentu");
			Console.WriteLine("0 - baigti darba");
		}
		public static void newStudent()
		{
			Console.WriteLine();
			
			Console.WriteLine("Iveskite studento varda:");
			string studName = Console.ReadLine();
			
			Console.WriteLine("Iveskite studento pavarde:");
			string studSurname = Console.ReadLine();
			
			Console.WriteLine();
			Console.WriteLine("Dabar iveskite atliktu namu darbu skaiciu");
			int homeWorkCount = Convert.ToInt32(Console.ReadLine());
			
			double[] marks = new double[homeWorkCount];
			double homeWorkSum = 0;
			double homeWorkAvg = 0;
			
			Console.WriteLine();
			Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius");
			for (int i = 0; i < homeWorkCount; i++) {
				marks[i] = Convert.ToDouble(Console.ReadLine());
				homeWorkSum += marks[i];
			}
			homeWorkAvg = homeWorkSum / homeWorkCount;
			Console.WriteLine();
			
			Console.WriteLine("Iveskite egzamino rezultata:");
			double examResult = Convert.ToDouble(Console.ReadLine());
			
			double finalMark = 0;
			
			Console.WriteLine("{0,-20} {1,5}\n", "Vardas", "Pavarde");
			finalMark = (homeWorkAvg * 0.3) + (examResult * 0.7);
			Console.WriteLine(finalMark);
		}
		public static void showAll(){
			
		}
		
		public static void Main(string[] args)
		{
			menu();
			int choice = Convert.ToInt32(Console.ReadLine());
			while (choice != 0) {
				switch (choice) {
					case 1:
						newStudent();
						break;
					case 2:
						showAll();
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Netinkamai ivestas pasirinkimas,\nbandykite dar karta");
						Console.WriteLine();
						break;
				}
			}
		
			Console.ReadKey();
		}
	}
}