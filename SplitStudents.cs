using System;
using System.Linq;
using System.Collections.Generic;

namespace C__LD
{
    public class SplitStudents
    {
        public static void splitStudentFile()

        {
            int path = 10;
            Console.WriteLine(("").PadLeft(55, '-'));
            Console.WriteLine("Kiek studentu yra faile?");
            try
            {
                path = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Klaida, iveskite skaiciu");
                Console.WriteLine(("").PadLeft(55, '-'));
                splitStudentFile();
            }

            List<Student> students = new List<Student>();
            List<Student> studentsBad = new List<Student>();
            List<Student> studentsGood = new List<Student>();

            students = FileReader.readFile("../../kursiokai" + path + ".txt");

            foreach (Student stud in students)
            {
                if (stud.final < 5.0f)
                {
                    studentsBad.Add(stud);
                }
                else studentsGood.Add(stud);
            }
            students = null;
            studentsGood = studentsGood.OrderBy(x => x.final).ToList();
            studentsBad = studentsBad.OrderBy(x => x.final).ToList();
            System.IO.StreamWriter outfile = new System.IO.StreamWriter("../../gudruoliai" + path + ".txt", true);
            System.IO.StreamWriter outfile1 = new System.IO.StreamWriter("../../nuskriaustukai" + path + ".txt", true);
            outfile.WriteLine(("").PadLeft(55, '-'));
            outfile.WriteLine("{0,-15}{1,-15}{2,16}", "Vardas", "Pavarde", "Galutinis");
            outfile.WriteLine(("").PadLeft(55, '-'));
            foreach (Student stud in studentsGood)
            {
                outfile.WriteLine("{0,-15}{1,-15}{2,16}", stud.Name, stud.Surname, stud.final);
            }
            outfile1.WriteLine("{0,-15}{1,-15}{2,16}", "Vardas", "Pavarde", "Galutinis");
            foreach (Student stud in studentsBad)
            {
                outfile1.WriteLine("{0,-15}{1,-15}{2,16}", stud.Name, stud.Surname, stud.final);
            }
            outfile.Flush();
            outfile1.Flush();
            outfile.Close();
            outfile1.Close();
        }
    }
}
