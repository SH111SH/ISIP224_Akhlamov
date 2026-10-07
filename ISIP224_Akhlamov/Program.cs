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
        static List<Employee> students = new List<Employee>();
        static List<Employee> teachers = new List<Employee>();
        static List<Course> courses = new List<Course>();


        static Employee CreateStudent()
        {
            try
            {
                Console.WriteLine("Enter FirstName");
                string FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(FirstName))
                {
                    throw new Exception("You didn't write a value");

                }

                Console.WriteLine("Enter LastName");
                string LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    throw new Exception("You didn't write a value");
                }

                Console.WriteLine("Enter MiddleName");
                string MiddleName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(MiddleName))
                {
                    throw new Exception("You didn't write a value");
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
                    throw new Exception("You didn't write a value");

                }

                Console.WriteLine("Enter LastName");
                string LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    throw new Exception("You didn't write a value");
                }

                Console.WriteLine("Enter MiddleName");
                string MiddleName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(MiddleName))
                {
                    throw new Exception("You didn't write a value");
                }


                Console.WriteLine("Enter Major");
                string Major = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Major))
                {
                    throw new Exception("You didn't write a value");
                }



                Teacher s = new Teacher(FirstName, LastName, MiddleName, Major);

                students.Add(s);

                return s;
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
                    Console.WriteLine("     Menu:\n1 - create new student\n2 - see students info\n3 - create new teacher\n4 - see teachers info\n5 - create new course\n6 - see course info\n7 - enrol student to the course\n8 - set teacher to the course\n9 - exit");
                    user_input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(user_input))
                    {
                        throw new Exception("You didn't choose a value");
              
                    }

                    switch (user_input)
                    {
                        case "1":
                            CreateStudent();
                            break;

                        case "2":
                            Console.WriteLine("students: ");
                            foreach(var student in students)
                            {
                                Console.WriteLine($"student.FirstName");
                            }

                            break;

                        case "3":
                            CreateTeacher();
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                        case "8":
                            break;
                        case "9":
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
