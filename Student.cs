

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;



namespace C__LD
{

    public class Student
    {
        //		fields
        public string Name { get; set; }
        public string Surname { get; set; }
        public double finalAvg { get; set; }
        public double homeWorkAvg { get; set; }
        public double homeWorkSum { get; set; }
        public double AvgMed { get; set; }
        public double examResult { get; set; }
        public List<int> marks { get; set; }
        public double final { get; set; }




        public Student()
        {
        }
        public Student(string Name, string Surname, double final)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.final = final;
        }
        public Student(string Name, string Surname, double examResult, List<int> marks)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.final = final;
            this.marks = marks;
        }


        //      creating new object Student and adding it in the students List
        public void createNewStudent()
        {
            Student student = new Student();
            Console.WriteLine("Iveskite studento varda:");
            student.Name = Convert.ToString(Console.ReadLine());
            if (!(student.Name.All(char.IsLetter)))
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Vardo bei pavardes visi simboliai turi buti raides!");
                Console.WriteLine(("").PadLeft(55, '-'));
                createNewStudent();
            }
            Console.WriteLine("Iveskite studento pavarde:");
            student.Surname = Convert.ToString(Console.ReadLine());
            if (!(student.Surname.All(char.IsLetter)))
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Vardo bei pavardes visi simboliai turi buti raides!");
                Console.WriteLine(("").PadLeft(55, '-'));
                createNewStudent();
            }

            Console.WriteLine(("").PadLeft(55, '-'));

            menuIn(student, MainClass.students);
            MainClass.students.Add(student);

            showStudent(student);
        }

        //      Print all the students from the sudents list
        public void showAll(double final)
        {
            Console.Clear();
            Console.WriteLine(("").PadLeft(55, '-'));
            Console.WriteLine("{0,-10}{1,-20}{2,20}", "Vardas", "Pavarde", "Vid");
            Console.WriteLine(("").PadLeft(55, '-'));
            foreach (var item in MainClass.students)
            {
                Console.WriteLine("{0,-10}{1,-20}{2,20}", item.Name, item.Surname, item.final);
            }
        }

        //		Print one student, last that is created, after it is created
        public void showStudent(Student student)
        {
            Console.Clear();
            Console.WriteLine(("").PadLeft(55, '-'));
            Console.WriteLine("{0,-10}{1,-20}{2,20}", "Vardas", "Pavarde", "Vid");
            Console.WriteLine(("").PadLeft(55, '-'));
            Console.WriteLine("{0,-10}{1,-20}{2,20}", student.Name, student.Surname, student.final);
        }


        //		Counting homework with an List, when we don't know how much homework there was
        public double homeWorkAverageCountWithList()
        {
            marks = new List<int>();

            Console.WriteLine();
            Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius,\njeigu daugiau pazymiu nera iveskite 0");
            int notZero = 0;
            do
            {
                notZero = Convert.ToInt32(Console.ReadLine());
                marks.Add(notZero);
            } while (notZero != 0.0);
            marks.Sort();

            foreach (var item in marks)
            {
                homeWorkSum += item;
            }
            homeWorkAvg = homeWorkSum / marks.Count;
            return homeWorkAvg;
        }

        public double MedianAverageCountWithList()
        {
            marks = new List<int>();


            Console.WriteLine();
            Console.WriteLine("Dabar iveskite atliktu namu darbu pazymius,\njeigu daugiau pazymiu nera iveskite 0");
            int notZero = 0;
            do
            {
                notZero = Convert.ToInt32(Console.ReadLine());
                marks.Add(notZero);
            } while (notZero != 0.0);
            marks.Sort();

            homeWorkAvg = 0;
            int[] TempArr = marks.ToArray();
            Array.Sort(TempArr);
            if (TempArr.Length % 2 == 0)
            {
                homeWorkAvg = ((TempArr[(TempArr.Length / 2) - 1] + TempArr[(TempArr.Length / 2)]) / 2);
            }
            else
            {
                homeWorkAvg = TempArr[(TempArr.Length / 2 - 1)];
            }
            return homeWorkAvg;
        }


        //		Summing up home work average to exam result, appears the finaAvg
        public double sumExamResultWithHomeWorkAverage(Student student)
        {
            try
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Iveskite egzamino rezultata:");
                examResult = Convert.ToInt32(Console.ReadLine());

                student.final = (homeWorkAvg * 0.3) + (examResult * 0.7);
                return student.final;
            }
            catch (FormatException)
            {
                Console.WriteLine("There is no need for trying to do that, I need only digits");
                Console.WriteLine("Zodziu, bandykite dar karta");
                Thread.Sleep(3000);
                Console.Clear();
                sumExamResultWithHomeWorkAverage(student);
                return 0;
            }
        }


        public double sumExamResultWithMedian(Student student)
        {
            try
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Iveskite egzamino rezultata:");
                examResult = Convert.ToInt32(Console.ReadLine());

                student.final = (AvgMed * 0.3) + (examResult * 0.7);
                return student.final;
            }
            catch (FormatException)
            {
                Console.WriteLine("There is no need for trying to do that, I need only digits");
                Console.WriteLine("Zodziu, bandykite dar karta");
                Thread.Sleep(3000);
                Console.Clear();
                sumExamResultWithMedian(student);
                return 0;
            }
        }

        public double menuIn(Student student, List<Student> students)
        {
            Console.WriteLine(("").PadLeft(55, '-'));
            Console.WriteLine("Spauskite 1, jeigu norite kad programa isvestu vidurki");
            Console.WriteLine("Spauskite 2, jeigu norite kad programa isvestu mediana");

            Console.WriteLine(("").PadLeft(55, '-'));
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        homeWorkAverageCountWithList();
                        sumExamResultWithHomeWorkAverage(student);
                        break;
                    case 2:
                        MedianAverageCountWithList();
                        sumExamResultWithMedian(student);
                        break;
                    default:
                        Console.WriteLine(("").PadLeft(55, '-'));
                        Console.WriteLine("Neteisingai ivestas pasirinkimas, bandykite dar karta");
                        Console.WriteLine(("").PadLeft(55, '-'));
                        break;
                }
                return student.finalAvg;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Palaukite pora sekundziu, ir");
                Console.WriteLine("pasirinkite viena skaiciu prasau!");
                Thread.Sleep(1500);
                Console.WriteLine("ir jokiu kitokiu simboliu! :)");
                // program is punishin those, who attempt to crash it :D if so, you'll have to wait...
                for (int i = 1; i <= 3; i++)
                {
                    Console.Write(i);
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Clear();
                menuIn(student, students);
                return 0;
            }

        }
        public void choosing()
        {

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                while (choice != 0)
                {
                    switch (choice)
                    {
                        case 1:
                            createNewStudent();
                            break;
                        case 2:
                            showAll(final);
                            break;
                        case 3:
                            MainClass.students.AddRange(FileReader.readFile().OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList());
                            break;
                        case 4:
                            FileWriter.generateStudents();
                            break;
                        case 5:
                            SplitStudents.splitStudentFile();
                            break;
                        case 0:
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(("").PadLeft(55, '-'));
                            Console.WriteLine("Netinkamai ivestas pasirinkimas,\nbandykite dar karta");
                            Console.WriteLine(("").PadLeft(55, '-'));
                            Console.WriteLine();
                            break;
                    }
                    MainClass.menu();
                    choice = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Netinkamai ivestas pasirinkimas,\nbandykite dar karta");
                Console.WriteLine("Teks paleisti programa is naujo... :(");
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine();

            }

        }
    }
}
