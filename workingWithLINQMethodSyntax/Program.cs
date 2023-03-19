using System;

namespace ergnmpergn
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }
    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }
    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 1, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 2, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 3, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 5, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
            };
            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
            IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" }, //PTK?
            };
            // group by gpa and display ids
            Console.WriteLine("Group by GPA then display IDs");
            var result = studentGPAList.GroupBy(g => g.GPA);
            foreach (var r in result) { foreach (StudentGPA s in r) { Console.WriteLine(s.StudentID); } }
            Console.WriteLine("[ END OF SECTION ]");
            // sort by club and display ids
            Console.WriteLine("Group by Club then display IDs");
            var result2 = studentClubList.GroupBy(g => g.ClubName);
            foreach (var r in result2) { foreach (StudentClubs s in r) { Console.WriteLine(s.StudentID); } }
            Console.WriteLine("[ END OF SECTION ]");
            // count of students with a GPA between 2.5 and 4
            var count = 0;
            Console.WriteLine("Display count of students with GPAs between 2.5 and 4");
            var result3 = studentGPAList.Where(g => g.GPA >= 2.5 && g.GPA <= 4.0);
            foreach (var r in result3) { count++; }
            Console.WriteLine(count);
            Console.WriteLine("[ END OF SECTION ]");
            // average of all students tuition
            Console.WriteLine("Display all student tuition average");
            var result4 = studentList.Average(g => g.Tuition);
            Console.WriteLine(result4);
            Console.WriteLine("[ END OF SECTION ]");
            // highest paying student and display name, major and tuition
            Console.WriteLine("Find highest paying student and display name, major and tuition");
            var result5 = studentList.Max(g => g.Tuition);
            foreach (var r in studentList) { if (r.Tuition == result5) { { Console.WriteLine($"{r.StudentName} | {r.Major} | {r.Tuition}"); } } }
            Console.WriteLine("[ END OF SECTION ]");
            // join student and GPA list on Id and display students name, major and GPA
            Console.WriteLine("Combine Student and GPA list on ID and display name, major and GPA");
            var result6 = studentList.Join(studentGPAList, stuid => stuid.StudentID, gpaid => gpaid.StudentID, (stuid, gpaid) => new { studentName = stuid.StudentName, major = stuid.Major, gpa = gpaid.GPA});
            foreach (var r in result6) { Console.WriteLine(r.studentName); Console.WriteLine(r.major); Console.WriteLine(r.gpa); }
            Console.WriteLine("[ END OF SECTION ]");
            // join student and club list and display names of those in game club
            Console.WriteLine("Combine Student and Club list and display names of those in game club");
            var result7 = studentList.Join(studentClubList, stuid => stuid.StudentID, clubid => clubid.StudentID, (stuid, clubid) => new { studentName = stuid.StudentName, club = clubid.ClubName });
            foreach (var r in result7) { if (r.club == "Game") { Console.WriteLine(r.studentName); } }
            Console.WriteLine("[ END OF SECTION ]");
            // finally 
        }
    }
}