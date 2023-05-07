using System;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz07._03._2023
{
    public class Person
    {
        private string namesurname;
        private DateTime birthDate;

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

        public Person(string t_namesurname, DateTime t_birthDate)
        {
            if (string.IsNullOrWhiteSpace(t_namesurname))
            {
                throw new ArgumentException("Name cannot be empty", nameof(t_namesurname));
            }

            Namesurname = t_namesurname;
            BirthDate = t_birthDate;
        }

        public override string ToString()
        {
            string result = string.Format("Name Surname: {0}\nDate birth: {1}",
                Namesurname, BirthDate.ToShortDateString());

            return result;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.Namesurname == p2.Namesurname && p1.BirthDate == p2.BirthDate;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
    }
    public class Student:Person
    {
        private string userID;
        private string homeAddress;
        private string phoneNumber;
        private List<int> gradesZachet = new List<int>();
        private List<int> gradesHomework = new List<int>();
        private List<int> gradesExam = new List<int>();

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
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
        public double AverageGrade
        {
            get
            {
                double sum = GradesZachet.Sum() + GradesHomework.Sum() + GradesExam.Sum();
                double count = GradesZachet.Count + GradesHomework.Count + GradesExam.Count;

                return count == 0 ? 0 : sum / count;
            }
        }

        public Student(string t_namesurname, string t_userID, DateTime t_birthDate, string t_homeAddress, string t_phoneNumber)
        : base(t_namesurname, t_birthDate)
        {
            if (string.IsNullOrWhiteSpace(t_namesurname))
            {
                throw new ArgumentException("Name cannot be empty", nameof(t_namesurname));
            }
            UserID = t_userID;
            HomeAddress = t_homeAddress;
            PhoneNumber = t_phoneNumber;
        }
        public Student(string t_namesurname, string t_userID, DateTime t_birthDate, string t_homeAddress, string t_phoneNumber, List<int> t_gradesZachet, List<int> t_gradesHomework, List<int> t_gradesExam)
        : base(t_namesurname, t_birthDate)
        {
            UserID = t_userID;
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

        public static bool operator ==(Student s1, Student s2)
        {
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
            {
                return false;
            }

            return s1.AverageGrade == s2.AverageGrade;
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        public double AverageHomeWork
        {
            get
            {
                return (GradesHomework.Sum() / GradesHomework.Count);
            }
        }
        public double AverageExam
        {
            get
            {
                if (GradesExam.Count <= 0)
                {
                    return 0;
                }
                else
                {
                    return (GradesExam.Sum() / GradesExam.Count);
                }
            }
        }

    }
    public class Aspirant : Student
    {
        private string dissertationTopic;

        public string DissertationTopic
        {
            get { return dissertationTopic; }
            set { dissertationTopic = value; }
        }

        public Aspirant(string t_name,string t_ID, DateTime t_birthDate, string t_homeAddress, string t_phoneNumber, string t_dissertationTopic)
            : base(t_name, t_ID, t_birthDate, t_homeAddress, t_phoneNumber)
        {
            DissertationTopic = t_dissertationTopic;
        }
    }
    public class Group : IEnumerable<Student>   
    {
        private List<Student> students;
        private string groupName;
        private string specialization;
        private int courseNumber;
        public int Count => students.Count;

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
        public static bool operator ==(Group group1, Group group2)
        {
            if (object.ReferenceEquals(group1, null))
            {
                return object.ReferenceEquals(group2, null);
            }
            return group1.Equals(group2);
        }

        public static bool operator !=(Group group1, Group group2)
        {
            return !(group1 == group2);
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
            Students = group.Students.Select(s => new Student(s.Namesurname, s.UserID,s.BirthDate, s.HomeAddress, s.PhoneNumber, s.GradesZachet, s.GradesHomework, s.GradesExam)).ToList();
            GroupName = group.GroupName;
            Specialization = group.Specialization;
            CourseNumber = group.CourseNumber;
        }
        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= students.Count)
                {
                    throw new IndexOutOfRangeException("Индекс находится за пределами допустимого диапазона.");
                }

                return students[index];
            }
            set
            {
                if (index < 0 || index >= students.Count)
                {
                    throw new IndexOutOfRangeException("Индекс находится за пределами допустимого диапазона.");
                }

                students[index] = value;
            }
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
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Group other = (Group)obj;
            return Students.Count == other.Students.Count;
        }

        public override int GetHashCode()
        {
            return Students.Count;
        }
        public IEnumerator<Student> GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class StudentEnumerator : IEnumerator<Student>
    {
        private Group grouptemp;
        private int currentIndex = -1;

        public StudentEnumerator(Group group)
        {
            this.grouptemp = group;
        }

        public Student Current => grouptemp[currentIndex];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < grouptemp.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {
        }
    }
    public class StudentNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return string.Compare(x.Namesurname, y.Namesurname  );
        }
    }

    public class StudentHomeWorkComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            return x.AverageHomeWork.CompareTo(y.AverageHomeWork);
        }

    }
    public class StudentExamComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            return x.AverageExam.CompareTo(y.AverageExam);
        }
    }

    class Program
    {
        static int RateCriteria(Student s1, Student s2) 
        { 
            return -s1.AverageGrade.CompareTo(s2.AverageGrade);
        }
        static void Main()
        {
            /*            Student studentEgor = new Student("Egor Safuanov", new DateTime(2006, 03, 26), "Odesa", "+38(097)-123-123-123");
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

                        Console.WriteLine(studentEgor == studentNikita);

                        Group groupStudentov = new Group("P11", "C#", 1);
                        groupStudentov.AddStudent(studentEgor);
                        groupStudentov.AddStudent(studentNikita);
                        groupStudentov.ShowStudents();

                        Group groupStudentov2 = new Group("P12", "C#", 1);
                        groupStudentov2.AddStudent(studentNikita);
                        Console.WriteLine(groupStudentov==groupStudentov2);

                        Group g134 = new Group("P134", "C#", 1);
                        Student stud123 = new Student("Egor Shevchenko", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                        g134.AddStudent(stud123);
                        Console.WriteLine(g134[0]);


                        Student[] studentSort = new Student[5];
                        studentSort[0] = new Student("Egor Shevchenko", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                        studentSort[1] = new Student("Egor Safuanov", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                        studentSort[2] = new Student("Egor Egorov", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                        studentSort[3] = new Student("Egor Egor", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                        studentSort[4] = new Student("Egor Egor123123", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");

                        studentSort[0].GradesHomework.Add(5);
                        studentSort[1].GradesHomework.Add(8);
                        studentSort[2].GradesHomework.Add(11);
                        studentSort[3].GradesHomework.Add(9);
                        studentSort[4].GradesHomework.Add(6);

                        Array.Sort(studentSort, new StudentHomeWorkComparer());
                        Console.WriteLine();

                        Console.WriteLine("Sort student list");
                        foreach (var student in studentSort)
                        {
                            Console.WriteLine($"Name: {student.Namesurname}, Average score with HW: {student.AverageHomeWork}");
                        }
                        Console.WriteLine();

                        Console.WriteLine("Students in the group:");
                        foreach (var student in studentSort)
                        {
                            Console.WriteLine($"Name: {student.Namesurname}, Average score with exam: {student.AverageExam}");
                        }
                        Console.WriteLine();
                        Array.Sort(studentSort, RateCriteria);
                        Console.WriteLine("Students in the group sort by score:");
                        foreach (var student in studentSort)
                        {
                            Console.WriteLine($"Name: {student.Namesurname}, Average score with all job: {student.AverageGrade}");
                        }*/
            File.WriteAllText("C:/Users/Egor/group.txt", string.Empty);
            FileStream fs = new FileStream("C:/Users/Egor/group.txt", FileMode.Append, FileAccess.Write);
            SortedDictionary<string, Student> students = new SortedDictionary<string, Student>();
           // Student[] students = new Student[3];
            Student studentEgor = new Student("Egor Safuanov","065", new DateTime(2006, 03, 26), "Odesa", "+38(097)-123-123-123");
            Student studentNikita = new Student("Nikita Shevchenko","052", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
            Student studentMikola = new Student("Mikola Shevchenko", "075", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student1 = new Student("Student1", "001", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student2 = new Student("Student2", "002", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student3 = new Student("Student3", "003", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student4 = new Student("Student4", "004", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student5 = new Student("Student5", "005", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student6 = new Student("Student6", "006", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student7 = new Student("Student7", "007", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
                Student student8 = new Student("Student8", "008 ", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");


            students.Add(studentEgor.UserID, studentEgor);
            students.Add(studentNikita.UserID, studentNikita);
            students.Add(studentMikola.UserID, studentMikola);
            students.Add(student1.UserID, student1);
            students.Add(student2.UserID, student2);
            students.Add(student3.UserID, student3);
            students.Add(student4.UserID, student4);
            students.Add(student5.UserID, student5);
            students.Add(student6.UserID, student6);
            students.Add(student7.UserID, student7);



            using (StreamWriter writer = new StreamWriter(fs))
            {
                foreach (KeyValuePair<string, Student> student in students)
                {
                    writer.WriteLine("Name -> {0}, ID -> {1}", student.Value.Namesurname, student.Value.UserID);
                }
            }
            Console.WriteLine("Data written to file.");


            /*            foreach (KeyValuePair<string, Student> student in students)
                        {
                            Console.WriteLine("Name -> {0}, ID -> {1}",student.Value.Namesurname,student.Value.UserID);
                        }*/

            /*  Student[] group = new Student[2];
              group[0]=new Student("Egor Safuanov", new DateTime(2006, 03, 26), "Odesa", "+38(097)-123-123-123");
              group[1] = new Student("Nikita Shevchenko", new DateTime(2006, 03, 29), "Odesa", "+38(097)-123-123-123");
              Array.Sort(group,new StudentNameComparer());*/


            /*            try
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
                        }*/
        }
    }
}
