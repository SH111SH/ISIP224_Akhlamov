using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ISIP224_Akhlamov
{
    internal class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();
        static List<Course> courses = new List<Course>();


        static Employee CreateStudent()
        {
            try
            {
                Console.WriteLine("Enter FirstName");
                string FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    while(string.IsNullOrWhiteSpace(FirstName))
                    {
                        Console.WriteLine("Enter FirstName");
                        FirstName = Console.ReadLine();
                    }

                }

                Console.WriteLine("Enter LastName");
                string LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    while (String.IsNullOrWhiteSpace(LastName))
                    {
                        Console.WriteLine("Enter LastName");
                        LastName = Console.ReadLine();

                    }
                }

                Console.WriteLine("Enter MiddleName");
                string MiddleName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(MiddleName))
                {
                    while(String.IsNullOrWhiteSpace(MiddleName))
                    {
                        Console.WriteLine("Enter MiddleName");
                        MiddleName = Console.ReadLine();
                    }    
                }

                Student s = new Student(FirstName, LastName, MiddleName);

                students.Add(s);

                return s;


            }

            catch (Exception ex) { throw ex; }




        }
        static Employee CreateTeacher()
        {
            try
            {
                Console.WriteLine("Enter FirstName");
                string FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    while (string.IsNullOrWhiteSpace(FirstName))
                    {
                        Console.WriteLine("Enter FirstName");
                        FirstName = Console.ReadLine();
                    }

                }

                Console.WriteLine("Enter LastName");
                string LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    while (string.IsNullOrWhiteSpace(FirstName))
                    {
                        Console.WriteLine("Enter LastName");
                        LastName = Console.ReadLine();
                    }
                }

                Console.WriteLine("Enter MiddleName");
                string MiddleName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(MiddleName))
                {
                    while (string.IsNullOrWhiteSpace(MiddleName))
                    {
                        Console.WriteLine("Enter LastName");
                       MiddleName = Console.ReadLine();
                    }
                }


                Console.WriteLine("Enter Major");
                string Major = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Major))
                {
                    while(string.IsNullOrWhiteSpace(Major))
                    {
                        Console.WriteLine("Enter Major");
                        Major = Console.ReadLine();
                    }
                }



                Teacher s = new Teacher(FirstName, LastName, MiddleName, Major);

                teachers.Add(s);

                return s;
            }
            catch (Exception ex) { throw ex; }





        }

        static Course CreateCourse()
        {
            try
            {
                Console.WriteLine("Enter a Name");
                string Name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Name))
                {
                    while (string.IsNullOrWhiteSpace(Name))
                    {
                        Console.WriteLine("Enter a Name");
                        Name = Console.ReadLine();
                    }

                }
                Console.WriteLine("Enter a Description");
                string Description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Description))
                {
                    while( string.IsNullOrWhiteSpace(Description))
                    {
                        Console.WriteLine("Enter a Description");
                        Description = Console.ReadLine();
                    }

                }

                Course c  = new Course(Name, Description, new List<Employee>(), new List<Employee>());

                return c;

            }
            catch (Exception ex) { throw ex; }
        }

        static void Main(string[] args)
        {
            string user_input = "d";

            while (user_input != "e")
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("     Menu:\n1 - create new student\n2 - see students info\n3 - create new teacher\n4 - see teachers info\n5 - create new course\n6 - see course info\n7 - enrol student to the course\n8 - set teacher to the course\n9 - exit");
                    user_input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(user_input))
                    {
                        while(string.IsNullOrWhiteSpace(user_input))
                        {
                            Console.WriteLine("     Menu:\n1 - create new student\n2 - see students info\n3 - create new teacher\n4 - see teachers info\n5 - create new course\n6 - see course info\n7 - enrol student to the course\n8 - set teacher to the course\n9 - exit");
                            user_input = Console.ReadLine();
                        }
              
                    }

                    switch (user_input)
                    {
                        case "1":
                            CreateStudent();
                            break;

                        case "2":
                            try
                            {
                                Console.WriteLine("students: ");

                                foreach (var student in students)
                                {
                                    Console.WriteLine($"{students.IndexOf(student)} - {student.FirstName} {student.LastName} {student.MiddleName} | {student.TicketID}");

                                }

                                Console.WriteLine("Enter student number to show more info about student");
                                string inp = Console.ReadLine();
                                if(String.IsNullOrWhiteSpace(inp))
                                {
                                    while(String.IsNullOrWhiteSpace(inp))
                                    {
                                        Console.WriteLine("Enter student number to show more info about student");
                                        inp = Console.ReadLine();
                                    }
                                }
                                bool parsed = Int32.TryParse(inp, out int val);
                                if (parsed)
                                {
                                    Console.WriteLine($"Student\nFrist name: {students[val].FirstName}\nLast name: {students[val].LastName}\nMiddle name: {students[val].MiddleName}\nTicketID {students[val].TicketID}");
                                    Console.WriteLine("Courses: ");
                                    foreach(var c in students[val].courses)
                                    {
                                        Console.WriteLine(c.Name);
                                    }
                                }
                                else 
                                {
                                    throw new Exception("You need write digital value");
                                }



                            }
                            catch(Exception ex) { throw ex; }
                            break;

                        case "3":
                            CreateTeacher();
                            break;

                        case "4":
                            try
                            {
                                Console.WriteLine("teachers: ");

                                foreach (var teacher in teachers)
                                {
                                    Console.WriteLine($"{teachers.IndexOf(teacher)} - {teacher.FirstName} {teacher.LastName} {teacher.MiddleName} | {teacher.Major}");

                                }

                                Console.WriteLine("Enter number to show more info about teacher");
                                string inp = Console.ReadLine();
                                if(String.IsNullOrWhiteSpace(inp))
                                {
                                    while( String.IsNullOrWhiteSpace(inp))
                                    {
                                        Console.WriteLine("Enter  number to show more info about teacher");
                                        inp = Console.ReadLine();
                                    }
                                }
                                bool parsed = Int32.TryParse(inp, out int val);
                                if (parsed)
                                {
                                    Console.WriteLine($"teacher\nFrist name: {teachers[val].FirstName}\nLast name: {teachers[val].LastName}\nMiddle name: {teachers[val].MiddleName}\nMajor {teachers[val].Major}");
                                    Console.WriteLine("Courses: ");
                                    foreach(var c in teachers[val].courses)
                                    {
                                        Console.WriteLine(c.Name);
                                    }
                                }
                                else 
                                {
                                    throw new Exception("You need write digital value");
                                }



                            }
                            catch(Exception ex) { throw ex; }
                            break;

                        case "5":
                            CreateCourse();
                            break;

                        case "6":
                            try
                            {
                                Console.WriteLine("Courses: ");

                                foreach (var course in courses)
                                {
                                    Console.WriteLine($"{courses.IndexOf(course)} - {course.Name}");

                                }

                                Console.WriteLine("Enter student number to show more info about course");
                                string inp = Console.ReadLine();
                                if(String.IsNullOrWhiteSpace(inp))
                                {
                                    while (String.IsNullOrWhiteSpace(inp))
                                    {
                                        Console.WriteLine("Enter student number to show more info about course");
                                        inp = Console.ReadLine();
                                    }

                                }
                                bool parsed = Int32.TryParse(inp, out int val);
                                if (parsed)
                                {
                                    Console.WriteLine($"course\nName: {courses[val].Name}\nDescription: {courses[val].Description}");
                                    Console.WriteLine("Students: ");
                                    foreach(var student in courses[val].students)
                                    {
                                        Console.WriteLine($"Frist name: {students[val].FirstName} | Last name: {students[val].LastName} | Middle name: {students[val].MiddleName} | TicketID {students[val].TicketID}");
                                    }

                                    foreach(var teacher  in courses[val].teachers)
                                    {
                                        Console.WriteLine($"Frist name: {teachers[val].FirstName} | Last name: {teachers[val].LastName} | Middle name: {teachers[val].MiddleName} | Major {teachers[val].Major}");
                                    }
                                }
                                else 
                                {
                                    throw new Exception("You need write digital value");
                                }



                            }
                            catch(Exception ex) { throw ex; }

                            break;

                        case "7":
                            try 
                            {
                                foreach (var student in students)
                                {
                                    Console.WriteLine($"{students.IndexOf(student)} - {student.FirstName} {student.LastName} {student.MiddleName} | {student.TicketID}");

                                }

                                Console.WriteLine("Enter student number to enroll this student to the course");
                                string inp = Console.ReadLine();
                                if (String.IsNullOrWhiteSpace(inp))
                                {
                                    while (String.IsNullOrWhiteSpace(inp))
                                    {
                                        Console.WriteLine("Enter student number to enroll this student to the course");
                                        inp = Console.ReadLine();
                                    }
                                }
                                bool parsed = Int32.TryParse(inp, out int val);
                                if (parsed)
                                {
                                    Console.WriteLine("Courses: ");

                                    foreach (var course in courses)
                                    {
                                        Console.WriteLine($"{courses.IndexOf(course)} - {course.Name}");

                                    }

                                    Console.WriteLine("Enter student number to show more info about course");
                                    string inpu = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(inpu))
                                    {
                                        while(String.IsNullOrWhiteSpace(inpu))
                                        {
                                            Console.WriteLine("Enter student number to show more info about course");
                                            inpu = Console.ReadLine();
                                        }
                                    }
                                    bool parssed = Int32.TryParse(inp, out int valu);
                                    if (parssed)
                                    {
                                        students[val].Enrol(courses[valu]);
                                        Console.WriteLine($"Student {students[val].FirstName} {students[val].LastName} enrolled to the course {courses[valu].Name} sucsess");
                                    }
                                    else 
                                    {
                                        throw new Exception("WRONG VALUE");
                                    }

                                }
                                else
                                {
                                    throw new Exception("Wrong value need number");
                                }
                            }
                            catch(Exception ex) { throw ex; }
                            break;

                        case "8":
                            try
                            {
                                foreach (var teacher in teachers)
                                {
                                    Console.WriteLine($"{teachers.IndexOf(teacher)} - {teacher.FirstName} {teacher.LastName} {teacher.MiddleName} | {teacher.Major}");

                                }

                                Console.WriteLine("Enter teacher number to enroll this student to the course");
                                string inp = Console.ReadLine();
                                if (String.IsNullOrWhiteSpace(inp))
                                {
                                    while(String.IsNullOrWhiteSpace(inp))
                                    {
                                        Console.WriteLine("Enter teacher number to enroll this student to the course");
                                        inp = Console.ReadLine();
                                    }
                                }
                                bool parsed = Int32.TryParse(inp, out int val);
                                if (parsed)
                                {
                                    Console.WriteLine("Courses: ");

                                    foreach (var course in courses)
                                    {
                                        Console.WriteLine($"{courses.IndexOf(course)} - {course.Name}");

                                    }

                                    Console.WriteLine("Enter teacher number to show more info about course");
                                    string inpu = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(inpu))
                                    {
                                        throw new Exception("You didn't choose a value");
                                    }
                                    bool parssed = Int32.TryParse(inp, out int valu);
                                    if (parssed)
                                    {
                                        students[val].Enrol(courses[valu]);
                                        Console.WriteLine($"Teacher {teachers[val].FirstName} {teachers[val].LastName} set to the course {courses[valu].Name} sucsess");
                                    }
                                    else
                                    {
                                        throw new Exception("WRONG VALUE");
                                    }

                                }
                                else
                                {
                                    throw new Exception("Wrong value need number");
                                }
                            }
                            catch (Exception ex) { throw ex; }
                            break;

                        case "e":
                            break;
                    }

                }
                catch (Exception ex) { throw ex; }
            }



        }
    }


    public class Course
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Employee> students { get;  private set; }
        public List<Employee> teachers { get; private set; }

        public Course(string Name, string Description,List<Employee> students, List<Employee> teachers)
        {
            this.Name = Name;
            this.Description = Description;
            this.students = students;
            this.teachers = teachers;
        }

        public void AddStudent(Employee student)
        {
            students.Add(student);
        }

        public void AddTeacher(Employee teacher)
        { 
            teachers.Add(teacher); 
        }

    }


    interface IEnrolliable
    {
       void Enrol(Course course);
    }


    public class Employee
        {
            public string FirstName; 
            public string LastName; 
            public string MiddleName; 
            public List<Course> courses; 

        public Employee(string FirstName, string LastName, string MiddleName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.courses = new List<Course>();
        }


        }

    public class Student:Employee, IEnrolliable
    {
        public int TicketID { get; private set; }
        private static int Max_students = 0;

        public Student(string FirstName, string LastName, string MiddleName)
            : base(FirstName,LastName,MiddleName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.courses = new List<Course>();
            this.TicketID = Max_students + 19821;
            






        }

        public void Enrol(Course course)
        {
            course.AddStudent(this);
            courses.Add(course);
        }

    }

    public class Teacher : Employee,IEnrolliable
    {
        public string Major { get; private set; }

        public Teacher(string FirstName, string LastName, string MiddleName, string Major)
            : base(FirstName, LastName, MiddleName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.courses = new List<Course>();
            this.Major = Major;
        }

        public void Enrol(Course course)
        {
            course.AddTeacher(this);
            courses.Add(course);
        }

    }
}
