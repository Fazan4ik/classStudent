using System;
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
            set { gradesZachet = value; }
        }
        public List<int> GradesHomework
        {
            get { return gradesHomework; }
            set { gradesHomework = value; }
        }
        public List<int> GradesExam
        {
            get { return gradesExam; }
            set { gradesExam = value; }
        }
        public Student(string t_namesurname, DateTime t_birthDate, string t_homeAddress, string t_phoneNumber)
        {
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
    class Program
    {
        static void Main()
        {
            Student student = new Student("Egor Safuanov", new DateTime(2006, 03, 26), "Odesa", "+38(097)-123-123-123");
            student.GradesZachet.Add(8);
            student.GradesZachet.Add(8);
            student.GradesHomework.Add(8);
            student.GradesHomework.Add(8);
            student.GradesExam.Add(8);
            Console.WriteLine(student);
        }
    }
}
