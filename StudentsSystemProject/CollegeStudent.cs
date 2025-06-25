using System;

namespace StudentsSystemProject
{
    public class CollegeStudent : Student
    {
        protected string subject;
        protected int average;

        public CollegeStudent() { }

        public CollegeStudent(string studentName, int studentID, int age, string subject, int average) : base(studentName, studentID, age)
        {
            this.subject = subject;
            this.average = average;
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public int Average
        {
            get { return average; }
            set { average = value; }
        }

        public override void DisplayInformation()
        {
            base.DisplayInformation();
            Console.WriteLine($"Subject : {subject}, Average : {average}");
        }
    }
}
