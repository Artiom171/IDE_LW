
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
			Student student1 = new Student();
			Console.WriteLine("Iveskite studento varda:");
			student1.Name = Console.ReadLine();
			Console.WriteLine("Iveskite studento pavarde:");
			student1.Surname = Console.ReadLine();
			
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
			
			student1.finalAvg = (homeWorkAvg * 0.3) + (examResult * 0.7);
			students.Add(student1);
	
			MainClass.showAll();
		}
	}
}
