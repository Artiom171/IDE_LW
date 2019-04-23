using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C__LD
{
    public static class FileReader
    {
        public static Student toObjectFromLine(string Line)
        {
            string[] separatedWords = Line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int examResult = int.Parse(separatedWords[(separatedWords.Length - 1)]);
            List<int> marks = new List<int>();
            try
            {
                if (separatedWords.Length >= 4)
                {
                    for (int i = 2; i <= separatedWords.Length; i++)
                    {
                        marks.Add(int.Parse(separatedWords[i]));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Bad file format");
                Environment.Exit(0);
            }
            Student StudentObject = new Student(separatedWords[0], separatedWords[1], examResult, marks);
            return StudentObject;
        }

        public static List<Student> toObjectFromLines(string[] LinesFromFile)
        {
            List<Student> students = new List<Student>();

            foreach (string stud in LinesFromFile)
            {
                students.Add(toObjectFromLine(stud));
            }
            return students;
        }

        public static List<Student> readFile()
        {
            List<Student> students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines("..\\..\\kursiokai.txt");
                lines = lines.Skip(1).ToArray();

                students.AddRange(toObjectFromLines(lines));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return students;
        }

        public static Student toObjectFromLineGen(string Line)
        {
            string[] separatedWords = Line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            double final = 6;
            try
            {
                if (separatedWords.Length == 3)
                {
                    final = double.Parse(separatedWords[2]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("Format is not right");
                Environment.Exit(0);
            }
            Student Student = new Student(separatedWords[0], separatedWords[1], final);
            return Student;
        }

        public static List<Student> toObjectFromLinesGen(string[] LinesFromFile)
        {
            List<Student> students = new List<Student>();
            foreach (string stud in LinesFromFile)
            {
                students.Add(toObjectFromLineGen(stud));
            }
            return students;
        }

        public static List<Student> readFile(string path)
        {
            List<Student> students = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                lines = lines.Skip(2).ToArray();
                students.AddRange(toObjectFromLinesGen(lines));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(("").PadLeft(55, '-'));
                Console.WriteLine("File not found. Press any key to close the program");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return students;
        }

    }
}
