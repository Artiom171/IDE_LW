
using System;
using System.Collections.Generic;



namespace C__LD
{

	public class Student
	{

		public string Name{get; set;}
		public string Surname{get; set;}
		public double finalAvg{get; set;}
//		public double finalAvgMed{get; set;}
		public static List <Student> students = new List<Student>();

		public static void createNewStudent()
		{
			Student student = new Student();
			Console.WriteLine("Iveskite studento varda:");
			student.Name = Console.ReadLine();
			Console.WriteLine("Iveskite studento pavarde:");
			student.Surname = Console.ReadLine();
			
			Console.WriteLine();
//			Naudojant paprasta masyva
//			-------------------------
//			Console.WriteLine("Dabar iveskite atliktu namu darbu skaiciu");
//			int homeWorkCount = Convert.ToInt32(Console.ReadLine());
			
//			double[] marks = new double[100];
			int homeWorkSum = 0;
			double homeWorkAvg = 0;
			var marks = new List<int>();
			
			Console.WriteLine();
			Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius,\njeigu daugiau pazymiu nera iveskite 0");
			int notZero = 0;
			do {
				notZero = Convert.ToInt32(Console.ReadLine());
				marks.Add(notZero);
			} while (notZero != 0);
			marks.Sort();

			foreach (var item in marks) {
				homeWorkSum += item;
			}
			
//          Naudojant paprasta masyva
//			-------------------------
//			int count = 0;
//			for (int i = 0; i < 100; i++) {
//				marks[i] = Convert.ToDouble(Console.ReadLine());
//				homeWorkSum += marks[i];
//				if(Convert.ToDouble(Console.ReadLine()).Equals(0)){
//					count = i+1;
//					break;
//				}
//			}
			homeWorkAvg = homeWorkSum / marks.Count;
			Console.WriteLine();
			
			Console.WriteLine("Iveskite egzamino rezultata:");
			double examResult = Convert.ToDouble(Console.ReadLine());
			
			student.finalAvg = (homeWorkAvg * 0.3) + (examResult * 0.7);
			students.Add(student);
	
			MainClass.showAll();
		}
	}
}
