
using System;
using System.Collections.Generic;



namespace C__LD
{

	public class Student
	{
//		fields
		public string Name{ get; set; }
		public string Surname{ get; set; }
		public static double finalAvg{ get; set; }
		public static double homeWorkAvg{ get; set; }
		public static double homeWorkSum{ get; set; }
		public static double AvgMed{get; set;}
		public static List <Student> students = new List<Student>();

//      creating new object Student and adding it in the students List
		public static void createNewStudent()
		{
			Student student = new Student();
			Console.WriteLine("Iveskite studento varda:");
			student.Name = Console.ReadLine();
			Console.WriteLine("Iveskite studento pavarde:");
			student.Surname = Console.ReadLine();
			
			Console.WriteLine();
			
			menuIn();
			//homeWorkAverageCountWithList();
			students.Add(student);
	
			showStudent();
		}
		
//      Print all the students from the sudents list
		public static void showAll()
		{
			Console.WriteLine("----------------------------------");
			foreach (var item in students) {
				// problema v etom finalAvg, ja ne mogu k nemu obrasiatsia cherez item., potomu chto on static, navernoe
				// poluciaetsia kogda vvozhu vtorogo studenta, on perepisyvaet staryj finalAvg i on stanovitsia odinkovym o oboih
				Console.WriteLine(string.Format("{0} {1} {2}", item.Name, item.Surname, finalAvg));
			}
		}

//		Print one student, last that is created, after it is created
		public static void showStudent()
		{
			Console.WriteLine("----------------------------------");
			Console.WriteLine(string.Format("{0} {1} {2}", students., createNewStudent.Surname, createNewStudent.finalAvg));
		}
		
//		Counting home work average with an array, when we know the amount of home work
		public static double homeWorkAverageCountWithArray()
		{
			Console.WriteLine("Dabar iveskite atliktu namu darbu skaiciu");
			int count = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius");
			var marks = new double[100];
			Student.homeWorkSum = 0;
			homeWorkAvg = 0;
			
			for (int i = 0; i < count; i++) {
				marks[i] = Convert.ToDouble(Console.ReadLine());
				homeWorkSum += marks[i];
			}
			homeWorkAvg = homeWorkSum / count;
			return homeWorkAvg;
		}
		
//		Counting homework with an List, when we don't know how much homework there was
//		public static double homeWorkAverageCountWithList()
//		{
//			var marks = new List<double>();
//			
//			Console.WriteLine();
//			Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius,\njeigu daugiau pazymiu nera iveskite 0");
//			double notZero = 0;
//			do {
//				notZero = Convert.ToInt32(Console.ReadLine());
//				marks.Add(notZero);
//			} while (notZero != 0.0);
//			marks.Sort();
//
//			foreach (var item in marks) {
//				homeWorkSum += item;
//			}
//			homeWorkAvg = homeWorkSum / marks.Count;
//			return homeWorkAvg;
//		}
//      median count here		
		public static double MedianAverageCountWithArray()
		{
			Console.WriteLine("Dabar iveskite atliktu namu darbu skaiciu");
			int count = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius");
			var marks = new double[100];
			Student.homeWorkSum = 0;
			homeWorkAvg = 0;
			
			for (int i = 0; i < count; i++) {
				marks[i] = Convert.ToDouble(Console.ReadLine());
			}
			Array.Sort(marks);
			int dir = 0;
			int secondDir = 0;
			AvgMed = 0;
			if(count %2 != 0){
				dir = (count/2);
				AvgMed = marks[99-dir];
			} else if(count %2 == 0){
				dir = (count/2);
				secondDir = dir - 1;
				AvgMed = ((marks[99-dir])+(marks[99-secondDir]))/2;
			}
			
			
//			dir is integer that show what element in the array will be the median
//			Console.WriteLine(finalAvgMed);
			return AvgMed;
		}
		
//		Summing up home work average to exam result, appears the finaAvg
		public static double sumExamResultWithHomeWorkAverage()
		{
			Console.WriteLine("Iveskite egzamino rezultata:");
			double examResult = Convert.ToDouble(Console.ReadLine());
			
			finalAvg = (homeWorkAvg * 0.3) + (examResult * 0.7);
			return finalAvg;
		}
		
		public static double sumExamResultWithMedian()
		{
			Console.WriteLine("Iveskite egzamino rezultata:");
			double examResult = Convert.ToDouble(Console.ReadLine());
			
			finalAvg = (AvgMed * 0.3) + (examResult * 0.7);
			return finalAvg;
		}
		
		public static double menuIn()
		{
			
			Console.WriteLine("Spauskite 1, jeigu norite kad programa isvestu vidurki");
			Console.WriteLine("Spauskite 2, jeigu norite kad programa isvestu mediana");
			int choice = Convert.ToInt32(Console.ReadLine());
			switch(choice){
				case 1:
					homeWorkAverageCountWithArray();
					sumExamResultWithHomeWorkAverage();
					break;
				case 2:
					MedianAverageCountWithArray();
					sumExamResultWithMedian();
					break;
				default:
					Console.WriteLine("Neteisingai ivestas pasirinkimas, bandykite dar karta");
					break;
			}
			return finalAvg;
		}
	}
}
