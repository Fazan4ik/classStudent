﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz07._03._2023
{
    public class Student
    {
        private string namesurname;
        private DateTime birthDate;
        private string homeAddress;
        private string phoneNumber;
        private List<int> gradesZachet = new List<int>();
        private List<int> gradesHomework = new List<int>();
        private List<int> gradesExam = new List<int>();

        public string Namesurname
        {
            get { return namesurname; }
            set { namesurname = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public List<int> GradesZachet
        {
            get { return gradesZachet; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "GradesZachet cannot be null");
                }
                if (value.Count == 0)
                {
                    throw new ArgumentException("GradesZachet cannot be empty", nameof(value));
                }
                if (value.Any(x => x < 2 || x > 12))
                {
                    throw new ArgumentException(nameof(value), "GradesZachet cannot be >12, <2");
                }
                gradesZachet = value; }
        }
        public List<int> GradesHomework
        {
            get { return gradesHomework; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "GradesHomework cannot be null");
                }
                if (value.Count == 0)
                {
                    throw new ArgumentException("GradesHomework cannot be empty", nameof(value));
                }
                if (value.Any(x => x < 2 || x > 12))
                {
                    throw new ArgumentException(nameof(value), "GradesHomework cannot >12, <2");
                }
                gradesHomework = value; }
        }
        public List<int> GradesExam
        {
            get { return gradesExam; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "GradesExam cannot be null");
                }
                if (value.Count == 0)
                {
                    throw new ArgumentException("GradesExam cannot be empty", nameof(value));
                }
                if (value.Any(x => x < 2 || x > 12))
                {
                    throw new ArgumentException(nameof(value), "GradesExam cannot be >12, <2");
                }
                gradesExam = value; }
        }
        public Student(string t_namesurname, DateTime t_birthDate, string t_homeAddress, string t_phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(t_namesurname))
            {
                throw new ArgumentException("Name cannot be empty", nameof(t_namesurname));
            }

            Namesurname = t_namesurname;
            BirthDate = t_birthDate;
            HomeAddress = t_homeAddress;
            PhoneNumber = t_phoneNumber;
        }
        public Student(string t_namesurname, DateTime t_birthDate, string t_homeAddress, string t_phoneNumber, List<int> t_gradesZachet, List<int> t_gradesHomework, List<int> t_gradesExam)
        {
            Namesurname = t_namesurname;
            BirthDate = t_birthDate;
            HomeAddress = t_homeAddress;
            PhoneNumber = t_phoneNumber;
            if (t_gradesZachet == null)
            {
                throw new ArgumentNullException(nameof(t_gradesZachet), "Grades for Zachet cannot be null");
            }

            if (t_gradesHomework == null)
            {
                throw new ArgumentNullException(nameof(t_gradesHomework), "Grades for Homework cannot be null");
            }

            if (t_gradesExam == null)
            {
                throw new ArgumentNullException(nameof(t_gradesExam), "Grades for Exam cannot be null");
            }
            GradesZachet = t_gradesZachet;
            GradesHomework = t_gradesHomework;
            GradesExam = t_gradesExam;
        }
        public override string ToString()
        {
            string result = string.Format("Name Surname: {0}\nDate birth: {1}\nAdress: {2}\nNumber phone: {3}\nOfsets: {4}\nHome Work: {5}\nExams: {6}",
                Namesurname, BirthDate.ToShortDateString(), HomeAddress, PhoneNumber, string.Join(", ", GradesZachet), string.Join(", ", GradesHomework), string.Join(", ", GradesExam));

            return result;
        }
    }

    public class Group
    {
        private List<Student> students;
        private string groupName;
        private string specialization;
        private int courseNumber;

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        public int CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value; }
        }

        public Group()
        {
            groupName = "New Group";
            specialization = "General";
            courseNumber = 1;
            students = new List<Student>();
        }

        public Group(string groupName, string specialization, int courseNumber)
        {
            students = new List<Student>();
            GroupName = groupName;
            Specialization = specialization;
            CourseNumber = courseNumber;
        }

        public Group(Group group)
        {
            Students = group.Students.Select(s => new Student(s.Namesurname, s.BirthDate, s.HomeAddress, s.PhoneNumber, s.GradesZachet, s.GradesHomework, s.GradesExam)).ToList();
            GroupName = group.GroupName;
            Specialization = group.Specialization;
            CourseNumber = group.CourseNumber;
        }

        public void ShowStudents()
        {
            Console.WriteLine($"Group: {GroupName}, Specialization: {Specialization}, Course: {CourseNumber}");
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Students[i].Namesurname}");
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Cannot add a null student to the group.");
            }
            Students.Add(student);
        }

        public void EditStudentData(Student student, string namesurname, DateTime birthDate, string homeAddress, string phoneNumber)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Cannot edit data of a null student.");
            }
            student.Namesurname = namesurname;
            student.BirthDate = birthDate;
            student.HomeAddress = homeAddress;
            student.PhoneNumber = phoneNumber;
        }

        public void EditGroupData(string groupName, string specialization, int courseNumber)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentException("Group name cannot be null or empty.", nameof(groupName));
            }
            if (string.IsNullOrWhiteSpace(specialization))
            {
                throw new ArgumentException("Specialization cannot be null or empty.", nameof(specialization));
            }
            if (courseNumber <= 0)
            {
                throw new ArgumentException("Course number must be a positive integer.", nameof(courseNumber));
            }
            GroupName = groupName;
            Specialization = specialization;
            CourseNumber = courseNumber;
        }

        public void TransferStudent(Student student, Group destinationGroup)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Cannot transfer a null student.");
            }
            if (destinationGroup == null)
            {
                throw new ArgumentNullException(nameof(destinationGroup), "Destination group cannot be null.");
            }
            Students.Remove(student);
            destinationGroup.AddStudent(student);
        }

        public void ExpelFailedStudents()
        {
            List<Student> failedStudents = new List<Student>();
            foreach (Student student in Students)
            {
                if (student.GradesZachet.Any(g => g < 4) || student.GradesHomework.Any(g => g < 4) || student.GradesExam.Any(g => g < 4))
                {
                    failedStudents.Add(student);
                }
            }
            foreach (Student failedStudent in failedStudents)
            {
                Students.Remove(failedStudent);
            }
        }

        public void ExpelWorstStudent()
        {
            Student worstStudent = Students.OrderByDescending(s => s.GradesZachet.Average() + s.GradesHomework.Average() + s.GradesExam.Average()).FirstOrDefault();
            if (worstStudent != null)
            {
                Students.Remove(worstStudent);
            }
        }
    }

    public class StudentNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return string.Compare(x.Namesurname, y.Namesurname  );
        }
    }
    class Program
    {
        static void Main()
        {
            Student studentEgor = new Student("Egor Safuanov", new DateTime(2006, 03, 26), "Odesa", "+38(097)-123-123-123");
            studentEgor.GradesZachet.Add(8);
            studentEgor.GradesZachet.Add(8);
            studentEgor.GradesHomework.Add(8);
            studentEgor.GradesHomework.Add(8);
            studentEgor.GradesExam.Add(8);
           
            Student studentNikita = new Student("Nikita Shevchenko", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
            studentNikita.GradesZachet.Add(6);
            studentNikita.GradesZachet.Add(6);
            studentNikita.GradesHomework.Add(6);
            studentNikita.GradesHomework.Add(6);
            studentNikita.GradesExam.Add(6);
            studentNikita.GradesExam.Add(6);

            Group groupStudentov = new Group("P11", "C#", 1);
            groupStudentov.AddStudent(studentEgor);
            groupStudentov.AddStudent(studentNikita);
            groupStudentov.ShowStudents();

            Student[] group = new Student[2];
            group[0]=new Student("Egor Safuanov", new DateTime(2006, 03, 26), "Odesa", "+38(097)-123-123-123");
            group[1] = new Student("Nikita Shevchenko", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
            Array.Sort(group,new StudentNameComparer());


            try
            {
                Student student = new Student("Test Test", new DateTime(2000, 1, 1), "Kiiv,Ukraine", "+911", new List<int>(), new List<int>(), new List<int>());

                student.GradesZachet.Add(1);
                student.GradesZachet.Add(13);
                student.GradesZachet.Add(1);
                student.GradesHomework.Add(6);
                student.GradesHomework.Add(15);
                student.GradesHomework.Add(9);
                student.GradesExam.Add(7);
                student.GradesExam.Add(8);
                student.GradesExam.Add(10);
                student.GradesExam.Add(14);

                student.GradesZachet.Add(1);
                student.GradesZachet.Add(6);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                Group groupstudent = new Group("Group name", "Specialization", 1);

                Student student = new Student(null, new DateTime(2000, 1, 1), "Kiiv,Ukraine", "+911", new List<int>(), new List<int>(), new List<int>());

                groupstudent.AddStudent(student);
                

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
