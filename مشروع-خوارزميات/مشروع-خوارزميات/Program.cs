using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace مشروع_خوارزميات
{
    internal class Program
    {
        static void Main(string[] args)    
            {
                DoublyLinkedList studentsList = new DoublyLinkedList();

                Console.WriteLine("=== Student Data Manegement ===");

                // إدخال بيانات 5 طلاب كبداية
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"\n Enter Student''s Number {i}:");

                    Student student = new Student();

                    Console.Write("Enter Student's Id: ");
                    student.Id = ReadInt("");

                    Console.Write("Enter the full Name: ");
                    student.FullName = Console.ReadLine();

                    Console.Write("Enter the City: ");
                    student.Governorate = Console.ReadLine();

                    Console.Write("Enter the First test score: ");
                    student.Exam1 = ReadDouble("");

                    Console.Write("Enter the Second test score: ");
                    student.Exam2 = ReadDouble("");

                    student.CalculateAverageAndGrade();

                    // نضيف الطالب في نهاية اللائحة كبداية
                    studentsList.AddLast(student);
                }

                // قائمة خيارات للمستخدم
                int choice;
                do
                {
                    Console.WriteLine("\n=== Main Menue ===");
                    Console.WriteLine("1. Display all Student");
                    Console.WriteLine("2. Sort By Name");
                    Console.WriteLine("3. Sort bt Grades");
                    Console.WriteLine("4. Search By score");
                    Console.WriteLine("5. Add Student at First");
                    Console.WriteLine("6. Add Student at Last");
                    Console.WriteLine("0. Excite");
                    Console.Write("Choose: ");

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            studentsList.Display();
                            break;

                        case 2:
                            studentsList.SortByName();
                            Console.WriteLine("تم الفرز حسب الاسم.");
                            studentsList.Display();
                            break;

                        case 3:
                            studentsList.SortByAverage();
                            Console.WriteLine("Sorted By grades.");
                            studentsList.Display();
                            break;

                        case 4:
                            Console.Write("Enter A grade to Sort: ");
                            double mark = double.Parse(Console.ReadLine());
                            studentsList.SearchByMark(mark);
                            break;

                        case 5:
                            Student newStudentFirst = CreateStudent();
                            studentsList.AddFirst(newStudentFirst);
                            Console.WriteLine("Added at the First.");
                            break;

                        case 6:
                            Student newStudentLast = CreateStudent();
                            studentsList.AddLast(newStudentLast);
                            Console.WriteLine("Added At the end.");
                            break;

                        case 0:
                            Console.WriteLine("Excite...");
                            break;

                        default:
                            Console.WriteLine("Incorrect choice , try again.");
                            break;
                    }

                } while (choice != 0);
            }

            // دالة مساعدة لإنشاء طالب جديد
            static Student CreateStudent()
            {
                Student student = new Student();

                Console.Write("Enter the ID : ");
                student.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter full name : ");
                student.FullName = Console.ReadLine();

                Console.Write("Enter the City: ");
                student.Governorate = Console.ReadLine();

                Console.Write("Enter the first test score: ");
                student.Exam1 = double.Parse(Console.ReadLine());

                Console.Write("Enter the second test score: ");
                student.Exam2 = double.Parse(Console.ReadLine());

                student.CalculateAverageAndGrade();

                return student;
            }

            // helper methods
            static int ReadInt(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string s = Console.ReadLine();
                    if (int.TryParse(s, out int value)) return value;
                    Console.WriteLine("Invalid number. Please enter an integer.");
                }
            }

            static double ReadDouble(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string s = Console.ReadLine();
                    if (double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out double value)) return value;
                    Console.WriteLine("Invalid number. Please enter a valid decimal number.");
                }
            }
    }
}