using System;

namespace StudentsSystemProject
{
    public class Student : IPerson
    {
        protected string studentName;
        protected int studentID;
        protected int age;
        
        public Student() { }

        public Student(string studentName, int studentID, int age)
        {
            this.studentName = studentName;
            this.studentID = studentID;
            this.age = age;
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Tuple<string, int, int> GetStudentInfo()
        {
            Tuple<string, int, int> infoTuple = new Tuple<string, int, int>(studentName, studentID, age);

            return infoTuple;
        }

        public virtual void DisplayInformation()
        {
            Console.WriteLine($"Student Name : {studentName}, Student ID : {studentID}, Age : {age}.");
        }
    }
}