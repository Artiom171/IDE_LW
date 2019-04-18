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
            int examResult = int.Parse(SeparatedWords[7]);
            List<int> marks = new List<int>(){
                int.Parse(SeparatedWords[2]),
                int.Parse(SeparatedWords[3]),
                int.Parse(SeparatedWords[4]),
                int.Parse(SeparatedWords[5]),
                int.Parse(SeparatedWords[6])
            };
            Student StudentObject = new Student(SeparatedWords[0], SeparatedWords[1], examResult, marks);
            return StudentObject;
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
        	List<Student> students = new List<Student>();
        	try{
            string[] lines = File.ReadAllLines("../../kursiokai.txt");
            lines = lines.Skip(1).ToArray();
            students.AddRange(ToObjectFromLines(lines));
        	} catch (System.IO.FileNotFoundException ex)
            {
        		Console.Clear();
                Console.WriteLine("File not found");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return students;
        }
    }
}
