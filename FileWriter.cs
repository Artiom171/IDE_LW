using System;

namespace C__LD
{
    class FileWriter
    {
        public static void generateStudents()

        {
            Console.WriteLine("Iveskite generuojamu studentu kieki:");
            try
            {
                Random random = new Random();
                string tempName, tempSurn;
                int studentCount = Convert.ToInt32((Console.ReadLine()));
                System.IO.StreamWriter outfile = new System.IO.StreamWriter("../../kursiokai" + studentCount + ".txt", true);
                outfile.WriteLine(("").PadLeft(55, '-'));
                outfile.WriteLine("{0,-15}{1,-15}{2,16}", "Vardas", "Pavarde", "Galutinis");
                outfile.WriteLine(("").PadLeft(55, '-'));
                for (int i = 1; i <= studentCount; i++)
                {
                    tempName = "Vardas" + i;
                    tempSurn = "Pavarde" + i;
                    Student TempStud = new Student(tempName, tempSurn, Math.Round(random.NextDouble() * (10.0f - 2.0f) + 2.0f));
                    outfile.WriteLine("{0,-15}{1,-15}{2,16}", TempStud.Name, TempStud.Surname, TempStud.final);
                }
                outfile.Flush();
                outfile.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Klaida, iveskite skaiciu");
                generateStudents();
            }
        }
    }
}
