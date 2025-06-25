using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsSystemProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            string studentName = null;
            Student wantedStudent = null;
            List<Student> students = new List<Student>();

            while (choice != 5)
            {
                Console.Write("1 - Add A Student\n2 - Add A College Student\n3 - Change Student's Information\n4 - Display Student's Information\n5 - Stop The Program\nEnter your choice : ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Student newStudent = new Student();
                    CreateStudent(newStudent);

                    if (IsStudentInSchool(students, newStudent))
                        Console.WriteLine("This student is already in the school !");
                    else
                    {
                        students.Add(newStudent);
                        Console.WriteLine("The student was added successfully to the school !");
                    }
                }
                else if (choice == 2)
                {
                    CollegeStudent newCollegeStudent = new CollegeStudent();
                    CreateCollegeStudent(newCollegeStudent);

                    if (IsStudentInSchool(students, newCollegeStudent))
                        Console.WriteLine("This college student is already in the school !");
                    else
                    {
                        students.Add(newCollegeStudent);
                        Console.WriteLine("The college student was added successfully to the school !");
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter the student's name : ");
                    studentName = Console.ReadLine();

                    if (!IsStudentInSchool(students, studentName))
                        Console.WriteLine($"There is no student named {studentName} in the school !");
                    else
                    {
                        wantedStudent = students.Where(student => student.StudentName == studentName).ToList()[0];
                        if (ChangeStudentsInfo(students, wantedStudent))
                            Console.WriteLine("The information was changed successfully !");
                        else
                            Console.WriteLine("The information wasn't changed !");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter the student's name : ");
                    studentName = Console.ReadLine();

                    if (!IsStudentInSchool(students, studentName))
                        Console.WriteLine($"There is no student named {studentName} in the school !");
                    else
                    {
                        wantedStudent = students.Where(student => student.StudentName == studentName).ToList()[0];
                        wantedStudent.DisplayInformation();
                    }
                }
            }

            Console.WriteLine("The program has been finished !");
        }

        public static void CreateStudent(Student student)
        {
            Console.Write("Enter student's name : ");
            student.StudentName = Console.ReadLine();

            Console.Write("Enter student's age : ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter student's ID : ");
            student.StudentID = int.Parse(Console.ReadLine());
        }

        public static void CreateCollegeStudent(CollegeStudent collegeStudent)
        {
            CreateStudent(collegeStudent);

            Console.Write("Enter student's subject : ");
            collegeStudent.Subject = Console.ReadLine();

            Console.Write("Enter student's average : ");
            collegeStudent.Average = int.Parse(Console.ReadLine());
        }

        public static bool IsStudentInSchool(List<Student> students, Student newStudent)
        {
            int newId = newStudent.StudentID;
            string newName = newStudent.StudentName;

            List<Student> sameStudentsId = students.Where(student => student.StudentID == newId).ToList();
            List<Student> sameStudentsName = students.Where(student => student.StudentName == newName).ToList();

            return sameStudentsId.Count > 0 || sameStudentsName.Count > 0;
        }

        public static bool IsStudentInSchool(List<Student> students, string studentName)
        {
            List<Student> sameStudents = students.Where(student => student.StudentName == studentName).ToList();

            return sameStudents.Count > 0;
        }

        public static bool ChangeStudentsInfo(List<Student> students, Student student)
        {
            int choice = -1, newId;
            string newName;
            CollegeStudent collegeStudent = null;

            Console.Write("1 - Change Student's Name\n2 - Change Student's Id\n3 - Change Student's Age\n");

            if (student is CollegeStudent)
                Console.Write("4 - Change Student's Subject\n5 - Change Student's Average\n");

            Console.Write("6 - to not change\nEnter your choice : ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 6)
                return false;

            if (choice == 1)
            {
                Console.Write("Enter student's new name : ");
                newName = Console.ReadLine();

                if (students.Where(student_ => student_.StudentName == newName).ToList().Count == 0)
                    student.StudentName = newName;
                else
                    return false;
            }
            else if (choice == 2)
            {
                Console.Write("Enter student's new ID : ");
                newId = int.Parse(Console.ReadLine());

                if (students.Where(student_ => student_.StudentID == newId).ToList().Count == 0)
                    student.StudentID = int.Parse(Console.ReadLine());
                else
                    return false;
            }
            else if (choice == 3)
            {
                Console.Write("Enter student's new age : ");
                student.Age = int.Parse(Console.ReadLine());
            }

            if (choice >= 1 && choice <= 3)
                return true;

            if (student is CollegeStudent)
            {
                collegeStudent = (CollegeStudent)student;

                if (choice == 4)
                {
                    Console.Write("Enter student's new subject : ");
                    collegeStudent.Subject = Console.ReadLine();
                }
                else if (choice == 5)
                {
                    Console.Write("Enter student's new average : ");
                    collegeStudent.Average = int.Parse(Console.ReadLine());
                }

                if (choice == 4 || choice == 5)
                    return true;
            }

            Console.WriteLine("Incorrect Input !");
            return false;
        }
    }
}
