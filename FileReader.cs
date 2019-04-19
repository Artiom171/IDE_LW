using C__LD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C__LD
{
    public static class FileReader
    {
        public static Student ToObjectFromLine(string Line)
        {
            string[] SeparatedWords = Line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int examResult = int.Parse(SeparatedWords[9]);
            List<int> marks = new List<int>(){
                int.Parse(SeparatedWords[4]),
                int.Parse(SeparatedWords[5]),
                int.Parse(SeparatedWords[6]),
                int.Parse(SeparatedWords[7]),
                int.Parse(SeparatedWords[8])
            };
            int sumOfList = 0;
            foreach(var item in marks)
            {
                sumOfList += item;
            }
            double marksAvg = sumOfList / marks.Count;
            double final = (marksAvg * 0.3) + (examResult * 0.7);
            Student Student = new Student(SeparatedWords[0], SeparatedWords[1], final);
            return Student;
        }

        public static List<Student> ToObjectFromLines(string[] LinesFromFile)
        {
            List<Student> students = new List<Student>();

            foreach (string stud in LinesFromFile)
            {
                students.Add(ToObjectFromLine(stud));
            }
            return students;
        }

        public static List<Student> ReadFile()
        {
            List<Student> studentai = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines("..\\..\\kursiokai.txt");
                lines = lines.Skip(1).ToArray();

                studentai.AddRange(ToObjectFromLines(lines));
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Failas nerastas. Sukurkite arba teisingai pavadinkite faila i \"kursiokai.txt\"\n Paspauskite bet kuri mygtuka, kad uzdaryti programa");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return studentai;
        }
    }
}
