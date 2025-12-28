using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace مشروع_خوارزميات
{
    public enum StudentGrade
    {
        Failed,
        Good,
        Very_Good,
        Bravo
    }

    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Governorate { get; set; }
        public double Exam1 { get; set; }
        public double Exam2 { get; set; }
        public double Average { get; set; }
        public StudentGrade Grade { get; set; }

        // دالة لحساب المحصلة والتقدير 
        public void CalculateAverageAndGrade()
        {
            Average = (Exam1 + Exam2) / 2.0;

            if (Average < 50)
            {
                Grade = StudentGrade.Failed;
            }
            else if (Average < 65)
            {
                Grade = StudentGrade.Good;
            }
            else if (Average < 85)

            {
                Grade = StudentGrade.Very_Good;
            }
            else
            {
                Grade = StudentGrade.Bravo;
            }
        }
    }

    public class Node
    {
        public Student Data { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

        public Node(Student data)
        {
            Data = data;
            Previous = null;
            Next = null;
        }
    }

    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        // إضافة طالب في البداية
        public void AddFirst(Student student)
        {
            Node newNode = new Node(student);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }

        // إضافة طالب في النهاية
        public void AddLast(Student student)
        {
            Node newNode = new Node(student);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        // عرض جميع الطلاب
        public void Display()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine($"ID: {current.Data.Id}, Name: {current.Data.FullName}, Governorate: {current.Data.Governorate}, Exam1: {current.Data.Exam1:F2}, Exam2: {current.Data.Exam2:F2}, Average: {current.Data.Average:F2}, Grade: {current.Data.Grade}");
                current = current.Next;
            }
        }

        // فرز حسب الاسم (A -> Z)
        public void SortByName()
        {
            if (head == null) return;

            for (Node i = head; i != null; i = i.Next)
            {
                for (Node j = i.Next; j != null; j = j.Next)
                {
                    if (string.Compare(i.Data.FullName, j.Data.FullName, StringComparison.CurrentCulture) > 0)
                    {
                        Student temp = i.Data;
                        i.Data = j.Data;
                        j.Data = temp;
                    }
                }
            }
        }

        // فرز حسب المحصلة (من الأدنى إلى الأعلى)
        public void SortByAverage()
        {
            if (head == null) return;

            for (Node i = head; i != null; i = i.Next)
            {
                for (Node j = i.Next; j != null; j = j.Next)
                {
                    if (i.Data.Average > j.Data.Average)
                    {
                        Student temp = i.Data;
                        i.Data = j.Data;
                        j.Data = temp;
                    }
                }
            }
        }

        // البحث العودي عن طالب بعلامة محددة
        private void RecursiveSearch(Node node, double mark)
        {
            if (node == null) return;

            const double TOL = 1e-9;
            if (Math.Abs(node.Data.Exam1 - mark) < TOL || Math.Abs(node.Data.Exam2 - mark) < TOL)
            {
                Console.WriteLine($"Found: {node.Data.FullName} (ID: {node.Data.Id}) with mark {mark}");
            }

            RecursiveSearch(node.Next, mark);
        }

        public void SearchByMark(double mark)
        {
            RecursiveSearch(head, mark);
        }   
    }
}
