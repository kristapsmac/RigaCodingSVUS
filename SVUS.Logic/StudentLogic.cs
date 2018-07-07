using SVUS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVUS.Logic
{
    public static class StudentLogic
    {
        private static List<Student> students = new List<Student>();
        public static void OpChoice()
        {
            Boolean ievade = true;
            while (ievade == true)
            {
                String Op = Console.ReadLine();
                switch (Op)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        Recover();
                        break;
                    case "4":
                        PrintAll();
                        break;
                    case "5":
                        Average();
                        break;
                    case "6":
                        Final();
                        break;
                    case "7":
                        High();
                        break;
                    case "8":
                        Low();
                        break;
                    case "9":
                        Find();
                        break;
                    case "stop":
                        ievade = false;
                        break;
                    default:
                        Console.WriteLine("Nezinama darbiba!");
                        return;

                }
            }
        }
        public static void AddStudent()
        {
            Console.Write("Ievadiet studenta vardu: ");
            String vards = Console.ReadLine();
            Console.Write("Ievadiet studenta uzvardu: ");
            String uzvards = Console.ReadLine();
            Console.Write("Ievadiet studenta pirmo atzimi: ");
            int atz1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ievadiet studenta otro atzimi: ");
            int atz2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ievadiet studenta treso atzimi: ");
            int atz3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ievadiet studenta ceturto atzimi: ");
            int atz4 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ievadiet studenta ceturto atzimi: ");
            int atzGala = Convert.ToInt32(Console.ReadLine());
            int galaatz = (atz1 + atz2 + atz3 + atz4 + atzGala) / 5;

            Student s1 = new Student();
            s1.StID++;
            s1.StN = vards;
            s1.StS = uzvards;
            s1.Gr1 = atz1;
            s1.Gr2 = atz2;
            s1.Gr3 = atz3;
            s1.Gr4 = atz4;
            s1.Final = atzGala;
            s1.GrFinal = galaatz;

            students.Add(s1);
        }
        public static void RemoveStudent()
        {
            Console.Write("Ievadiet studenta id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].StID == id)
                {
                    Console.WriteLine("Students " + id + " tika atrasts");
                    Console.WriteLine("Vai tiešām vēlaties dzēst studentu? ");
                    if (Console.ReadLine() == "ja")
                    {
                        students.RemoveAt(i);
                        Console.WriteLine("Students tika dzēsts!");
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("students nav atrasts!");
                }
            }
        }
        public static void Recover()
        {
            Console.Write("Ievadiet studenta id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].StID == id)
                {
                    Console.WriteLine("Students " + id + " tika atrasts");
                    Console.WriteLine(String.Format("Studenta patreizeja informacija id: {0} vards: {1} uzvards: {2}, pirma atzime:{3} " +
                        "otra atzime:{4} tresa atzime:{5} ceturta atzime:{6}, gala darba atzime: {7}, gala vertejums:{8} ",
                        students[i].StID, students[i].StN, students[i].StS, students[i].Gr1, students[i].Gr2, students[i].Gr3,
                        students[i].Gr4, students[i].Final, students[i].GrFinal));

                    Console.Write("Ievadiet studenta jauno vardu!");
                    string iev = Console.ReadLine();
                    if (IfEmpty(iev) == false)
                    {
                        students[i].StN = iev;
                    }
                    Console.Write("Ievadiet jauno studenta uzvardu!");
                    iev = Console.ReadLine();
                    if (IfEmpty(iev) == false)
                    {
                        students[i].StS = iev;
                    }
                    Change(i);
                    students[i].GrFinal = (students[i].Gr1 + students[i].Gr2 + students[i].Gr3 + students[i].Gr4) / 4;

                }
                else
                {
                    Console.WriteLine("students nav atrasts!");
                }
            }
        }
        public static void PrintAll()
        {
            Console.WriteLine("ID       Vards, uzvards       #1       #2       #3       #4       Gala vertejums");
            for (int i = 0; i < students.Count(); i++)
            {
                Console.WriteLine(String.Format("{0}       {1} {2}       {3}       {4}       {5}       {6}       {7}",
                        students[i].StID, students[i].StN, students[i].StS, students[i].Gr1, students[i].Gr2, students[i].Gr3,
                        students[i].Gr4, students[i].GrFinal));
            }
        }
        public static void Average()
        {
            string par = "GrFinal";
            Console.WriteLine("Studenti sakārtoti pēc vidējās atzīmes dilstošā secībā!");
            Console.WriteLine("ID       Vards, uzvards       #1       #2       #3       #4       Gala vertejums");
            BubbleSort(par);
            for (int i = 0; i < students.Count(); i++)
            {
                Console.WriteLine(students[i]);
            }
        }
        public static void Final()
        {
            string par = "Final";
            Console.WriteLine("Studenti sakārtoti pēc vidējās atzīmes dilstošā secībā!");
            Console.WriteLine("ID       Vards, uzvards       #1       #2       #3       #4       Gala vertejums");
            BubbleSort(par);
            for (int i = 0; i < students.Count(); i++)
            {
                Console.WriteLine(students[i]);
            }

        }
        public static string High()
        {
            string par = "high";
            BubbleSort(par);
            return String.Format("Studentu sauc  {0}  {1} , iegūtās atzīmes ir  {2}  {3}  {4}  {5}  {6}  {7}", students[0].StN, students[0].StS, students[0].Gr1,
                students[0].Gr2, students[0].Gr3, students[0].Gr4, students[0].GrFinal, students[0].GrFinal);
        }
        public static string Low()
        {
            string par = "high";
            BubbleSort(par);
            return String.Format("Studentu sauc  {0}  {1} , iegūtās atzīmes ir  {2}  {3}  {4}  {5}  {6}  {7}", students[students.Count() - 1].StN,
                students[students.Count() - 1].StS, students[students.Count() - 1].Gr1, students[students.Count() - 1].Gr2,
                students[students.Count() - 1].Gr3, students[students.Count() - 1].Gr4, students[students.Count() - 1].GrFinal,
                students[students.Count() - 1].GrFinal);

        }
        public static void Find()
        {
            Console.Write("Ievadiet studenta id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < students.Count(); i++)
            {
                if (students[i].StID == id)
                {
                    Console.WriteLine("Students " + id + " tika atrasts");
                    Console.WriteLine(String.Format("Studentu sauc  {0}  {1} , iegūtās atzīmes ir  {2}  {3}  {4}  {5}  {6}  {7}",
                students[i].StN, students[i].StS, students[i].Gr1, students[i].Gr2, students[i].Gr3, students[i].Gr4,
                students[i].GrFinal, students[i].GrFinal));

                }
                else
                {
                    Console.WriteLine("Students nav atrasts!");
                }
            }
        }
        public static bool IfEmpty(string iev)
        {
            if (string.IsNullOrEmpty(iev))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IfNull(int? ievSk)
        {

            if (ievSk == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Change(int i)
        {
            Console.Write("Ievadiet jauno studenta pirmo vertejumu!");
            int? ievSk = Convert.ToInt32(Console.ReadLine());
            if (IfNull(ievSk) == false)
            {
                int jaunAtz = ievSk.GetValueOrDefault();
                students[i].Gr1 = jaunAtz;
            }
            Console.Write("Ievadiet jauno studenta otro vertejumu!");
            ievSk = Convert.ToInt32(Console.ReadLine());
            if (IfNull(ievSk) == false)
            {
                int jaunAtz = ievSk.GetValueOrDefault();
                students[i].Gr2 = jaunAtz;
            }
            Console.Write("Ievadiet jauno studenta treso vertejumu!");
            ievSk = Convert.ToInt32(Console.ReadLine());
            if (IfNull(ievSk) == false)
            {
                int jaunAtz = ievSk.GetValueOrDefault();
                students[i].Gr3 = jaunAtz;
            }
            Console.Write("Ievadiet jauno studenta ceturto vertejumu!");
            ievSk = Convert.ToInt32(Console.ReadLine());
            if (IfNull(ievSk) == false)
            {
                int jaunAtz = ievSk.GetValueOrDefault();
                students[i].Gr4 = jaunAtz;
            }
        }
        public static void BubbleSort(string part)
        {
            Student temp;
            if (part == "GrFinal")
            {
                for (int i = 0; i < students.Count(); i++)
                {
                    for (int j = 0; j < students.Count() - 1; j++)
                    {
                        if (students[j].GrFinal < students[j + 1].GrFinal)
                        {
                            temp = students[j + 1];
                            students[j + 1] = students[j];
                            students[j] = temp;
                        }
                    }
                }
            }
            else if (part == "Final")
            {
                for (int i = 0; i < students.Count(); i++)
                {
                    for (int j = 0; j < students.Count() - 1; j++)
                    {
                        if (students[j].Final < students[j + 1].Final)
                        {
                            temp = students[j + 1];
                            students[j + 1] = students[j];
                            students[j] = temp;
                        }
                    }
                }
            }
            else if (part == "high")
            {
                for (int i = 0; i < students.Count(); i++)
                {
                    for (int j = 0; j < students.Count() - 1; j++)
                    {
                        if (students[j].Final > students[j + 1].Final)
                        {
                            temp = students[j + 1];
                            students[j + 1] = students[j];
                            students[j] = temp;
                        }
                    }
                }
            }
        }
    }
}


